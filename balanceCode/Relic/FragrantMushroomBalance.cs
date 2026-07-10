using HarmonyLib;
using System.Reflection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

[HarmonyPatch(typeof(GalacticDust), "get_CanonicalVars")]
public class FragrantMushroomBalance
{
    static IEnumerable<DynamicVar> Postfix(IEnumerable<DynamicVar> __result)
    {
        yield return new HpLossVar(12M);
    }
}