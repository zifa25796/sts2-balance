using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class TheLostBalance
{
    // Balance: MinHp 105 → 99
    [HarmonyPatch(typeof(TheLost), nameof(TheLost.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 105 : 99;
            return false;
        }
    }

    // Balance: MaxHp 105 → 99
    [HarmonyPatch(typeof(TheLost), nameof(TheLost.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 105 : 99;
            return false;
        }
    }
}
