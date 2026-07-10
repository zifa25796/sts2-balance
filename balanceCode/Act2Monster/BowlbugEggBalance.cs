using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class BowlbugEggBalance
{
    // Balance: BiteDamage adjusted
    [HarmonyPatch(typeof(BowlbugEgg), "BiteDamage", MethodType.Getter)]
    public class BiteDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }

    // Balance: ProtectBlock adjusted
    [HarmonyPatch(typeof(BowlbugEgg), "ProtectBlock", MethodType.Getter)]
    public class ProtectBlock
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 9: 8;
            return false;
        }
    }
}
