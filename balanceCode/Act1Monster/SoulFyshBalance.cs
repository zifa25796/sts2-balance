using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;


public class SoulFyshBalance
{
    // Balance: MinHp 216(216) → 206(216)
    [HarmonyPatch(typeof(SoulFysh), nameof(SoulFysh.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 216 : 206;
            return false;
        }
    }

    // Balance: MaxHp 216(216) → 206(216)
    [HarmonyPatch(typeof(SoulFysh), nameof(SoulFysh.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 216 : 206;
            return false;
        }
    }

    // Balance: ScreamDamage 13(15) → 11(13)
    [HarmonyPatch(typeof(SoulFysh), "ScreamDamage", MethodType.Getter)]
    public class ScreamDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 13: 11;
            return false;
        }
    }

    // Balance: GazeDamage 6(7) → 5(6)
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
