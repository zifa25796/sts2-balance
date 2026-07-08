using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;


public class PhantasmalGardenerBalance
{
    [HarmonyPatch(typeof(PhantasmalGardener), nameof(PhantasmalGardener.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 28 : 26;
            return false;
        }
    }

    [HarmonyPatch(typeof(PhantasmalGardener), nameof(PhantasmalGardener.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 30 : 29;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(PhantasmalGardener), "BiteDamage", MethodType.Getter)]
    public class BiteDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 4: 4;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(PhantasmalGardener), "LashDamage", MethodType.Getter)]
    public class LashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 6;
            return false;
        }
    }
}