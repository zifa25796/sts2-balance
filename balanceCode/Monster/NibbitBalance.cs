using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Monster;

public class NibbitBalance
{

    [HarmonyPatch(typeof(Nibbit), "ButtDamage", MethodType.Getter)]
    public class ButtDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 9;
            return false;
        }
    }
    
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