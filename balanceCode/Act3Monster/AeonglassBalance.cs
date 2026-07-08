using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class AeonglassBalance
{
    [HarmonyPatch(typeof(Aeonglass), "EbbDamage", MethodType.Getter)]
    public class EbbDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 30: 25;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Aeonglass), "EbbBlock", MethodType.Getter)]
    public class EbbBlock
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 30: 25;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Aeonglass), "IncreasingIntensityBaseStrength", MethodType.Getter)]
    public class IncreasingIntensityBaseStrength
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 3: 3;
            return false;
        }
    }
}