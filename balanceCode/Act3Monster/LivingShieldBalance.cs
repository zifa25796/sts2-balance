using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class LivingShieldBalance
{
    // Balance: MinHp 70 → 60
    [HarmonyPatch(typeof(LivingShield), nameof(LivingShield.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 70 : 60;
            return false;
        }
    }

    // Balance: MaxHp 70 → 60
    [HarmonyPatch(typeof(LivingShield), nameof(LivingShield.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 70 : 60;
            return false;
        }
    }
}
