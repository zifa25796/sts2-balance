using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class FlyconidBalance
{
    // Balance: SporeDamage 8(9) → 7(8)
    [HarmonyPatch(typeof(Flyconid), "SporeDamage", MethodType.Getter)]
    public class SporeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 8: 7;
            return false;
        }
    }
    
    // Balance: SmashDamage 11(12) → 10(11)
    [HarmonyPatch(typeof(Flyconid), "SmashDamage", MethodType.Getter)]
    public class SmashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 11: 10;
            return false;
        }
    }
}