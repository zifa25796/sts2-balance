using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models.Relics;


namespace balance.balanceCode.Relic;

public class BookOfFiveRingsBalance
{
    // Balance: Heal reduced 20 → 5, also grants Max HP on trigger
    [HarmonyPatch(typeof(BookOfFiveRings), "CanonicalVars", MethodType.Getter)]
    public static class BookOfFiveRings_HealNerf_Patch
    {
        static void Postfix(ref IEnumerable<DynamicVar> __result)
        {
            __result = new DynamicVar[]
            {
                new CardsVar(5),
                new HealVar(5M) // 20 -> 5
            };
        }
    }

    [HarmonyPatch(typeof(BookOfFiveRings), nameof(BookOfFiveRings.AfterCardChangedPiles))]
    public static class BookOfFiveRings_MaxHpBoost_Patch
    {
        static void Prefix(BookOfFiveRings __instance, out int __state)
        {
            __state = __instance.CardsAdded;
        }

        static async Task Postfix(Task __result, BookOfFiveRings __instance, int __state)
        {
            await __result;

            int before = __state;
            int after = __instance.CardsAdded;
            int threshold = __instance.DynamicVars.Cards.IntValue;

            bool actuallyTriggered = after != before && after % threshold == 0;
            if (actuallyTriggered)
            {
                await CreatureCmd.GainMaxHp(__instance.Owner.Creature, __instance.DynamicVars.Heal.BaseValue);
            }
        }
    }
}
