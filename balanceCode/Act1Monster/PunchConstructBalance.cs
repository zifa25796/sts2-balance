using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class PunchConstructBalance
{
    [HarmonyPatch(typeof(PunchConstruct), "FastPunchDamage", MethodType.Getter)]
    public class FastPunchDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 5: 4;
            return false;
        }
    }
}