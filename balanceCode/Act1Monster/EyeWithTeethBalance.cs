
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class EyeWithTeethBalance
{
    [HarmonyPatch(typeof(EyeWithTeeth), nameof(EyeWithTeeth.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 5 : 5;
            return false;
        }
    }

    [HarmonyPatch(typeof(EyeWithTeeth), nameof(EyeWithTeeth.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 5 : 5;
            return false;
        }
    }
}