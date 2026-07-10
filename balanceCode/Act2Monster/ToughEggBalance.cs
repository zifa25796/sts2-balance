using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class ToughEggBalance
{
    // Balance: MinHp 17-18(18-19) → 15-17(16-18)
    [HarmonyPatch(typeof(ToughEgg), nameof(ToughEgg.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 16 : 15;
            return false;
        }
    }

    // Balance: MaxHp 17-18(18-19) → 15-17(16-18)
    [HarmonyPatch(typeof(ToughEgg), nameof(ToughEgg.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 18 : 17;
            return false;
        }
    }

    // Balance: HatchlingMinHp 17-18(18-19) → 15-17(16-18)
    [HarmonyPatch(typeof(ToughEgg), "HatchlingMinHp", MethodType.Getter)]
    public class HatchlingMinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 15;
            return false;
        }
    }

    // Balance: HatchlingMaxHp 17-18(18-19) → 15-17(16-18)
    [HarmonyPatch(typeof(ToughEgg), "HatchlingMaxHp", MethodType.Getter)]
    public class HatchlingMaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 18: 17;
            return false;
        }
    }
}
