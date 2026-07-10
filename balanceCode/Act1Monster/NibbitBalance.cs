using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;
public class NibbitBalance
{

    // Balance: ButtDamage 12(13) → 9(10)
    [HarmonyPatch(typeof(Nibbit), "ButtDamage", MethodType.Getter)]
    public class ButtDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 9;
            return false;
        }
    }
    
    // Balance: SliceDamage 6(7) → 5(6)
    [HarmonyPatch(typeof(Nibbit), "SliceDamage", MethodType.Getter)]
    public class SliceDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
}