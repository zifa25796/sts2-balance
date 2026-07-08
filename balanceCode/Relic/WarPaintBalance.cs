using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Extensions;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

[HarmonyPatch(typeof(WarPaint), nameof(WarPaint.AfterObtained))]
public class WarPaintBalance
{
    public static bool Prefix(WarPaint __instance)
    {
        var owner = __instance.Owner;

        List<CardModel> skills = PileType.Deck
            .GetPile(owner)
            .Cards
            .Where(c =>
                c != null &&
                c.Type == CardType.Skill &&
                c.IsUpgradable)
            .ToList();

        if (skills.Count == 0)
            return false;


        CardModel first = skills
            .StableShuffle(owner.RunState.Rng.Niche)
            .First();

        CardCmd.Upgrade(first);
        skills.Remove(first);


        if (skills.Count > 0)
        {
            var nonBasic = skills
                .Where(c => c.Rarity != CardRarity.Basic)
                .ToList();

            CardModel second = (nonBasic.Count > 0 ? nonBasic : skills)
                .StableShuffle(owner.RunState.Rng.Niche)
                .First();

            CardCmd.Upgrade(second);
        }

        return false; // 阻止原版执行
    }
}