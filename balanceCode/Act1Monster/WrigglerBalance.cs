using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class WrigglerBalance
{
    // Balance: MinHp 16-19(17-20) → lowered
    [HarmonyPatch(typeof(Wriggler), nameof(Wriggler.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 17 : 16;
            return false;
        }
    }

    // Balance: MaxHp 16-19(17-20) → lowered
    [HarmonyPatch(typeof(Wriggler), nameof(Wriggler.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 20 : 19;
            return false;
        }
    }

    // Balance: BiteDamage 6(7) → 5(6)
    [HarmonyPatch(typeof(Wriggler), "BiteDamage", MethodType.Getter)]
    public class BiteDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
}
