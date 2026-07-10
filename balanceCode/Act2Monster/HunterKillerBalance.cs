using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class HunterKillerBalance
{
    [HarmonyPatch(typeof(HunterKiller), nameof(HunterKiller.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 116 : 111;
            return false;
        }
    }

    [HarmonyPatch(typeof(HunterKiller), nameof(HunterKiller.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 116 : 111;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(HunterKiller), "BiteDamage", MethodType.Getter)]
    public class BiteDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 14;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(HunterKiller), "PunctureDamage", MethodType.Getter)]
    public class PunctureDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }
}