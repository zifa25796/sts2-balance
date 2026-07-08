using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class GlobeHeadBalance
{
    [HarmonyPatch(typeof(GlobeHead), "ShockingSlapDamage", MethodType.Getter)]
    public class ShockingSlapDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 11: 10;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(GlobeHead), "GalvanicBurstDamage", MethodType.Getter)]
    public class GalvanicBurstDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 14;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(GlobeHead), "ThunderStrikeDamage", MethodType.Getter)]
    public class ThunderStrikeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 8: 7;
            return false;
        }
    }
}