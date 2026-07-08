using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class FogmogBalance
{
    [HarmonyPatch(typeof(Fogmog), "SwipeDamage", MethodType.Getter)]
    public class SwipeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 8: 7;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Fogmog), "HeadbuttDamage", MethodType.Getter)]
    public class HeadbuttDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 13;
            return false;
        }
    }
}