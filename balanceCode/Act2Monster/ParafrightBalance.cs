using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class ParafrightBalance
{
    [HarmonyPatch(typeof(Parafright), nameof(Parafright.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 15 : 15;
            return false;
        }
    }

    [HarmonyPatch(typeof(Parafright), nameof(Parafright.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 15 : 15;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Parafright), "SlamDamage", MethodType.Getter)]
    public class SlamDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 14;
            return false;
        }
    }
}