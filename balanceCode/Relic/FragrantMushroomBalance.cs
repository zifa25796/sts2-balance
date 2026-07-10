using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

// Balance: Fragrant Mushroom loses 12 HP
[HarmonyPatch(typeof(FragrantMushroom), "get_CanonicalVars")]
public class FragrantMushroomBalance
{
    static IEnumerable<DynamicVar> Postfix(IEnumerable<DynamicVar> __result)
    {
        yield return new HpLossVar(12M);
    }
}
