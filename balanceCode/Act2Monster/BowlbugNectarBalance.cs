using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class BowlbugNectarBalance
{
    // Balance: MinHp 36-37(37-38) → 33-36(34-37)
    [HarmonyPatch(typeof(BowlbugNectar), nameof(BowlbugNectar.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 34 : 33;
            return false;
        }
    }

    // Balance: MaxHp 36-37(37-38) → 33-36(34-37)
    [HarmonyPatch(typeof(BowlbugNectar), nameof(BowlbugNectar.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 37 : 36;
            return false;
        }
    }
}
