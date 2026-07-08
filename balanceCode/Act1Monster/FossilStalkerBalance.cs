using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;


public class FossilStalkerBalance
{
    [HarmonyPatch(typeof(FossilStalker), "TackleDamage", MethodType.Getter)]
    public class TackleDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 9: 7;
            return false;
        }
    }
}