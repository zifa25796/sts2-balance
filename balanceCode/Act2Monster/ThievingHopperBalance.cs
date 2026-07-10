using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class ThievingHopperBalance
{
    // Balance: TheftDamage 16(18) → 14(16)
    [HarmonyPatch(typeof(ThievingHopper), "TheftDamage", MethodType.Getter)]
    public class TheftDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 14;
            return false;
        }
    }

    // Balance: NabDamage 14(16) → 12(14)
    [HarmonyPatch(typeof(ThievingHopper), "NabDamage", MethodType.Getter)]
    public class NabDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 14: 12;
            return false;
        }
    }

    // Balance: HatTrickDamage 22(24) → 20(22)
    [HarmonyPatch(typeof(ThievingHopper), "HatTrickDamage", MethodType.Getter)]
    public class HatTrickDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 22: 20;
            return false;
        }
    }
}
