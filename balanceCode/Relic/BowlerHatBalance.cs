using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;


namespace balance.balanceCode.Relic;

[HarmonyPatch(typeof(RelicModel), nameof(RelicModel.AfterObtained))]
public class BowlerHatBalance
{
    static async Task Postfix(Task __result, RelicModel __instance)
    {
        await __result;
        if (__instance is BowlerHat relic)
        {
            await PlayerCmd.GainGold(16, __instance.Owner);
        }
    }
}