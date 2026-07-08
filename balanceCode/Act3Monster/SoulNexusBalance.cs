using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class SoulNexusBalance
{
    [HarmonyPatch(typeof(SoulNexus), nameof(SoulNexus.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 248 : 228;
            return false;
        }
    }

    [HarmonyPatch(typeof(SoulNexus), nameof(SoulNexus.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 248 : 228;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(SoulNexus), "DrainLifeDamage", MethodType.Getter)]
    public class DrainLifeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 14;
            return false;
        }
    }
}