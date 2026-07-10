using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.ValueProps;

namespace balance.balanceCode.Event;

// Balance: Breathing 50g, Emotional 125g, Arachnid 230g
[HarmonyPatch(typeof(ZenWeaver), "get_CanonicalVars")]
public class ZenWeaverBalance
{
    static IEnumerable<DynamicVar> Postfix(IEnumerable<DynamicVar> __result)
    {
        yield return new DynamicVar("BreathingTechniquesCost", 50M);
        yield return new DynamicVar("EmotionalAwarenessCost", 125M);
        yield return new DynamicVar("ArachnidAcupunctureCost", 230M);
    }
}
