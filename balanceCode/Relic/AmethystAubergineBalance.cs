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

// Balance: AmethystAubergine grants gold on pickup
[HarmonyPatch(typeof(RelicModel), nameof(RelicModel.AfterObtained))]
public static class AmethystAubergineBalance
{
    static async Task Postfix(Task __result, RelicModel __instance)
    {
        await __result;
        if (__instance is AmethystAubergine relic)
        {
            await PlayerCmd.GainGold(__instance.DynamicVars.Gold.BaseValue, __instance.Owner);
        }
    }
}
