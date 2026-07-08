using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class GasBombBalance
{
    [HarmonyPatch(typeof(GasBomb), nameof(GasBomb.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 6 : 5;
            return false;
        }
    }

    [HarmonyPatch(typeof(GasBomb), nameof(GasBomb.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 6 : 5;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(GasBomb), "ExplodeDamage", MethodType.Getter)]
    public class ExplodeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 9;
            return false;
        }
    }
}