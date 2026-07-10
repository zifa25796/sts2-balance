using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using System.Reflection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.ValueProps;


namespace balance.balanceCode.Relic;

public class IntimidatingHelmetBalance
{
    // Balance: Grants 2× energy as block for cards costing 2+ energy
    [HarmonyPatch]
    public class BeforeCardPlayed
    {
        static MethodBase TargetMethod()
        {
            return typeof(IntimidatingHelmet).GetMethod("BeforeCardPlayed",
                BindingFlags.Public | BindingFlags.Instance);
        }

        static bool Prefix(IntimidatingHelmet __instance, CardPlay cardPlay, ref Task __result)
        {
            __result = RunBeforeCardPlayed(__instance, cardPlay);
            return false;
        }

        static async Task RunBeforeCardPlayed(IntimidatingHelmet intimidatingHelmet, CardPlay cardPlay)
        {
            if (cardPlay.Card.Owner != intimidatingHelmet.Owner || cardPlay.Resources.EnergyValue < intimidatingHelmet.DynamicVars.Energy.IntValue)
                return;
            intimidatingHelmet.Flash();
            Decimal num = await CreatureCmd.GainBlock(intimidatingHelmet.Owner.Creature, new BlockVar(cardPlay.Resources.EnergyValue * 2, ValueProp.Unpowered), (CardPlay) null);
        }
    }
}
