using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class FlailKnightBalance
{
    // Balance: FlailDamage 9(10) → 8(9)
    [HarmonyPatch(typeof(FlailKnight), "FlailDamage", MethodType.Getter)]
    public class FlailDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 9 : 8;
            return false;
        }
    }
}
