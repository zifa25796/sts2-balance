using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class BowlbugSilkBalance
{
    // Balance: MinHp 40-41(41-42) → 38-40(39-41)
    [HarmonyPatch(typeof(BowlbugSilk), nameof(BowlbugSilk.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 39 : 38;
            return false;
        }
    }

    // Balance: MaxHp 40-41(41-42) → 38-40(39-41)
    [HarmonyPatch(typeof(BowlbugSilk), nameof(BowlbugSilk.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 41 : 40;
            return false;
        }
    }
}
