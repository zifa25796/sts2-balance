using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;


public class LagavulinMatriarchBalance
{
    [HarmonyPatch(typeof(LagavulinMatriarch), "SlashDamage", MethodType.Getter)]
    public class SlashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 20: 18;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(LagavulinMatriarch), "Slash2Damage", MethodType.Getter)]
    public class Slash2Damage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 13: 11;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(LagavulinMatriarch), "Slash2Block", MethodType.Getter)]
    public class Slash2Block
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 13: 11;
            return false;
        }
    }
}