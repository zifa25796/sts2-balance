using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;


public class SkulkingColonyBalance
{
    [HarmonyPatch(typeof(SkulkingColony), "InertiaStrengthGain", MethodType.Getter)]
    public class InertiaStrengthGain
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 3: 2;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(SkulkingColony), "PiercingStabsDamage", MethodType.Getter)]
    public class PiercingStabsDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }
}