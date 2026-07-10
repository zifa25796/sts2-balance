using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class MagiKnightBalance
{
    // Balance: PowerShieldDamage 6(7) → 5(6)
    [HarmonyPatch(typeof(MagiKnight), "PowerShieldDamage", MethodType.Getter)]
    public class PowerShieldDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }

    // Balance: PowerShieldBlock 7(8) → 6(7)
    [HarmonyPatch(typeof(MagiKnight), "PowerShieldBlock", MethodType.Getter)]
    public class PowerShieldBlock
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }
}
