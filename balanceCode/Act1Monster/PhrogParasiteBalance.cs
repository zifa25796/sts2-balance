using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class PhrogParasiteBalance
{
    // Balance: MinHp 56-59(61-63) → lowered
    [HarmonyPatch(typeof(PhrogParasite), nameof(PhrogParasite.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 61 : 56;
            return false;
        }
    }

    // Balance: MaxHp 56-59(61-63) → lowered
    [HarmonyPatch(typeof(PhrogParasite), nameof(PhrogParasite.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 63 : 59;
            return false;
        }
    }
}
