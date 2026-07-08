using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class KnowledgeDemonBalance
{
    [HarmonyPatch(typeof(KnowledgeDemon), nameof(KnowledgeDemon.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 389 : 369;
            return false;
        }
    }

    [HarmonyPatch(typeof(KnowledgeDemon), nameof(KnowledgeDemon.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 389 : 369;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(KnowledgeDemon), "SlapDamage", MethodType.Getter)]
    public class SlapDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 15;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(KnowledgeDemon), "KnowledgeOverwhelmingDamage", MethodType.Getter)]
    public class KnowledgeOverwhelmingDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 8: 7;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(KnowledgeDemon), "PonderDamage", MethodType.Getter)]
    public class PonderDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(KnowledgeDemon), "PonderStrength", MethodType.Getter)]
    public class PonderStrength
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 4: 3;
            return false;
        }
    }
}