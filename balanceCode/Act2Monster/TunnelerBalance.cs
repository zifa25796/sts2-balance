using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class TunnelerBalance
{
    [HarmonyPatch(typeof(Tunneler), "BiteDamage", MethodType.Getter)]
    public class BiteDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 13: 11;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(Tunneler), "BelowDamage", MethodType.Getter)]
    public class BelowDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 27: 24;
            return false;
        }
    }
}