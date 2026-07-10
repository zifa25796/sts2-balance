using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class TurretOperatorBalance
{
    // Balance: MinHp 45 → 35
    [HarmonyPatch(typeof(TurretOperator), nameof(TurretOperator.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 45 : 35;
            return false;
        }
    }

    // Balance: MaxHp 45 → 35
    [HarmonyPatch(typeof(TurretOperator), nameof(TurretOperator.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 45 : 35;
            return false;
        }
    }
}
