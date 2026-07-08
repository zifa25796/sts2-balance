using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class CeremonialBeastBalance
{
    [HarmonyPatch(typeof(CeremonialBeast), "PlowDamage", MethodType.Getter)]
    public class PlowDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 19: 17;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(CeremonialBeast), "StompDamage", MethodType.Getter)]
    public class StompDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 14;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(CeremonialBeast), "CrushDamage", MethodType.Getter)]
    public class CrushDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 18: 16;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(CeremonialBeast), "CrushStrength", MethodType.Getter)]
    public class CrushStrength
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 3: 3;
            return false;
        }
    }
}