using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class MechaKnightBalance
{
    // Balance: ChargeDamage 25(30) → 20(25)
    [HarmonyPatch(typeof(MechaKnight), "ChargeDamage", MethodType.Getter)]
    public class ChargeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 25: 20;
            return false;
        }
    }
}
