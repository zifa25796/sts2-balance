using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class TwoTailedRatBalance
{
    // Balance: MinHp 18-21 → 17-20
    [HarmonyPatch(typeof(TwoTailedRat), nameof(TwoTailedRat.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 18 : 17;
            return false;
        }
    }

    // Balance: MaxHp 18-21 → 17-20
    [HarmonyPatch(typeof(TwoTailedRat), nameof(TwoTailedRat.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 21 : 20;
            return false;
        }
    }
}
