using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class GremlinMercBalance
{
    [HarmonyPatch(typeof(GremlinMerc), "DoubleSmashDamage", MethodType.Getter)]
    public class DoubleSmashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(GremlinMerc), "HeheDamage", MethodType.Getter)]
    public class HeheDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }
}