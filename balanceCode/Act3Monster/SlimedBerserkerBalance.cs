using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class SlimedBerserkerBalance
{
    // Balance: MinHp 273 → 255
    [HarmonyPatch(typeof(SlimedBerserker), nameof(SlimedBerserker.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 273 : 255;
            return false;
        }
    }

    // Balance: MaxHp 273 → 255
    [HarmonyPatch(typeof(SlimedBerserker), nameof(SlimedBerserker.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 273 : 255;
            return false;
        }
    }
}
