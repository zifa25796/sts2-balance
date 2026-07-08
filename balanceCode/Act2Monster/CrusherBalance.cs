using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class CrusherBalance
{
    [HarmonyPatch(typeof(Crusher), "ThrashDamage", MethodType.Getter)]
    public class ThrashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 14;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Crusher), "BugStingDamage", MethodType.Getter)]
    public class BugStingDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Crusher), "GuardedStrikeDamage", MethodType.Getter)]
    public class GuardedStrikeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 12: 10;
            return false;
        }
    }
}