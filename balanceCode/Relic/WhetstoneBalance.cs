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

// Balance: Upgrades 2 attacks (prefers non-Basic for 2nd)
[HarmonyPatch(typeof(Whetstone), nameof(Whetstone.AfterObtained))]
public class WhetstoneBalance
{
    public static bool Prefix(Whetstone __instance)
    {
        var owner = __instance.Owner;

        List<CardModel> attacks = PileType.Deck
            .GetPile(owner)
            .Cards
            .Where(c =>
                c != null &&
                c.Type == CardType.Attack &&
                c.IsUpgradable)
            .ToList();

        if (attacks.Count == 0)
            return false;


        CardModel first = attacks
            .StableShuffle(owner.RunState.Rng.Niche)
            .First();

        CardCmd.Upgrade(first);
        attacks.Remove(first);


        if (attacks.Count > 0)
        {
            var nonBasic = attacks
                .Where(c => c.Rarity != CardRarity.Basic)
                .ToList();

            CardModel second = (nonBasic.Count > 0 ? nonBasic : attacks)
                .StableShuffle(owner.RunState.Rng.Niche)
                .First();

            CardCmd.Upgrade(second);
        }

        return false; // 阻止原版执行
    }
}
