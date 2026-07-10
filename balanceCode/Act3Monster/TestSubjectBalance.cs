using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class TestSubjectBalance
{
    // Balance: FirstFormHp 105 → 100
    [HarmonyPatch(typeof(TestSubject), "FirstFormHp", MethodType.Getter)]
    public class FirstFormHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 105: 100;
            return false;
        }
    }

    // Balance: SecondFormHp 210 → 200
    [HarmonyPatch(typeof(TestSubject), "SecondFormHp", MethodType.Getter)]
    public class SecondFormHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 210: 200;
            return false;
        }
    }

    // Balance: ThirdFormHp 315 → 300
    [HarmonyPatch(typeof(TestSubject), "ThirdFormHp", MethodType.Getter)]
    public class ThirdFormHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 315: 300;
            return false;
        }
    }

    // Balance: SkullBashDamage 12(14) → 10(12)
    [HarmonyPatch(typeof(TestSubject), "SkullBashDamage", MethodType.Getter)]
    public class SkullBashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 12: 10;
            return false;
        }
    }

    // Balance: MultiClawDamage 10(11) → 9(10)
    [HarmonyPatch(typeof(TestSubject), "MultiClawDamage", MethodType.Getter)]
    public class MultiClawDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 9;
            return false;
        }
    }

    [HarmonyPatch(typeof(TestSubject), "BigPounceDamage", MethodType.Getter)]
    public class BigPounceDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 40: 40;
            return false;
        }
    }
}
