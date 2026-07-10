using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.ValueProps;

namespace balance.balanceCode.Event;

[HarmonyPatch(typeof(LuminousChoir), "get_CanonicalVars")]
public class LuminousChoirBalance
{
    static IEnumerable<DynamicVar> Postfix(IEnumerable<DynamicVar> __result)
    {
        yield return new GoldVar(129);
    }
}