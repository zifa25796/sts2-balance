using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class RocketBalance
{
    // Balance: PrecisionBeamDamage 17(19) → 15(17)
    [HarmonyPatch(typeof(Rocket), "PrecisionBeamDamage", MethodType.Getter)]
    public class PrecisionBeamDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 17: 15;
            return false;
        }
    }

    // Balance: LaserDamage 34(36) → 32(34)
    [HarmonyPatch(typeof(Rocket), "LaserDamage", MethodType.Getter)]
    public class LaserDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 34: 32;
            return false;
        }
    }
}
