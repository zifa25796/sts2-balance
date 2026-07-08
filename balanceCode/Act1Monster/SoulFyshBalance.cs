using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;


public class SoulFyshBalance
{
    [HarmonyPatch(typeof(SoulFysh), nameof(SoulFysh.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 216 : 206;
            return false;
        }
    }

    [HarmonyPatch(typeof(SoulFysh), nameof(SoulFysh.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 216 : 206;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(SoulFysh), "ScreamDamage", MethodType.Getter)]
    public class ScreamDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 13: 11;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(SoulFysh), "GazeDamage", MethodType.Getter)]
    public class GazeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
}