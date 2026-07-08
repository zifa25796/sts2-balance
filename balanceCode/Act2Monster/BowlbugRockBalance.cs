using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class BowlbugRockBalance
{
    [HarmonyPatch(typeof(BowlbugRock), "HeadbuttDamage", MethodType.Getter)]
    public class HeadbuttDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 14;
            return false;
        }
    }
}