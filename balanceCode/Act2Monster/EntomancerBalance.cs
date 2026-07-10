using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class EntomancerBalance
{
    // Balance: MinHp 152(152) → 142(152)
    [HarmonyPatch(typeof(Entomancer), nameof(Entomancer.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 152 : 142;
            return false;
        }
    }

    // Balance: MaxHp 152(152) → 142(152)
    [HarmonyPatch(typeof(Entomancer), nameof(Entomancer.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 152 : 142;
            return false;
        }
    }

    // Balance: SpearMoveDamage 18(20) → 16(18)
    [HarmonyPatch(typeof(Entomancer), "SpearMoveDamage", MethodType.Getter)]
    public class SpearMoveDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 18: 16;
            return false;
        }
    }
}
