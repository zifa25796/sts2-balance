using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class KinFollowerBalance
{
    // Balance: MinHp 54-55(58-59) → lowered
    [HarmonyPatch(typeof(KinFollower), nameof(KinFollower.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 58 : 54;
            return false;
        }
    }

    // Balance: MaxHp 54-55(58-59) → lowered
    [HarmonyPatch(typeof(KinFollower), nameof(KinFollower.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 59 : 55;
            return false;
        }
    }


}
