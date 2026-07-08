using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class RocketBalance
{
    [HarmonyPatch(typeof(Rocket), "PrecisionBeamDamage", MethodType.Getter)]
    public class PrecisionBeamDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 17: 15;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Rocket), "LaserDamage", MethodType.Getter)]
    public class LaserDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 34: 32;
            return false;
        }
    }
}