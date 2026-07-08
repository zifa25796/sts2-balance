using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class ExoskeletonBalance
{
    [HarmonyPatch(typeof(Exoskeleton), nameof(Exoskeleton.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 25 : 24;
            return false;
        }
    }

    [HarmonyPatch(typeof(Exoskeleton), nameof(Exoskeleton.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 27 : 26;
            return false;
        }
    }
}