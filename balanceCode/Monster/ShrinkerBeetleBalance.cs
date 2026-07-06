using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Monster;

public class ShrinkerBeetleBalance
{
    [HarmonyPatch(typeof(ShrinkerBeetle), nameof(Nibbit.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 36 : 34;
            return false;
        }
    }

    [HarmonyPatch(typeof(ShrinkerBeetle), nameof(Nibbit.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 38 : 36;
            return false;
        }
    }
}