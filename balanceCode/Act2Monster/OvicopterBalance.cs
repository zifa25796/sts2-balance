using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class OvicopterBalance
{
    // Balance: SmashDamage 16(18) → 15(16)
    [HarmonyPatch(typeof(Ovicopter), "SmashDamage", MethodType.Getter)]
    public class SmashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 15;
            return false;
        }
    }

    // Balance: TenderizerDamage 7(8) → 6(7)
    [HarmonyPatch(typeof(Ovicopter), "TenderizerDamage", MethodType.Getter)]
    public class TenderizerDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }
}
