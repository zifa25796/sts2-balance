using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class ScrollOfBitingBalance
{
    [HarmonyPatch(typeof(ScrollOfBiting), "ChompDamage", MethodType.Getter)]
    public class ChompDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 13;
            return false;
        }
    }
}