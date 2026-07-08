using System.Reflection;
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class VineShamblerBalance
{
    [HarmonyPatch(typeof(VineShambler))]
    public class ChompDamage
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.PropertyGetter(
                typeof(VineShambler),
                "ChompDamage"
            );
        }

        static bool Prefix(ref int __result)
        {
            __result =
                AscensionHelper.HasAscension(
                    AscensionLevel.DeadlyEnemies
                )
                    ? 17
                    : 15;

            return false;
        }
    }
}