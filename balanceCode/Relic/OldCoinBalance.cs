using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.ValueProps;

namespace balance.balanceCode.Relic;

// Balance: Gold reduced to 333
[HarmonyPatch(typeof(GalacticDust), "get_CanonicalVars")]
public class OldCoinBalance
{
    static IEnumerable<DynamicVar> Postfix(IEnumerable<DynamicVar> __result)
    {
        yield return new GoldVar(333);
    }
}
