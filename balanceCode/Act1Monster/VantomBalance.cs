using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class VantomBalance
{
    // Balance: MinHp 168(178) → 168(178)
    [HarmonyPatch(typeof(Vantom), nameof(Vantom.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 178 : 168;
            return false;
        }
    }

    // Balance: MaxHp 168(178) → 168(178)
    [HarmonyPatch(typeof(Vantom), nameof(Vantom.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 178 : 168;
            return false;
        }
    }

    // Balance: InkyLanceDamage 6(7) → 5(6)
    [HarmonyPatch(typeof(Vantom), "InkyLanceDamage", MethodType.Getter)]
    public class InkyLanceDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
}
