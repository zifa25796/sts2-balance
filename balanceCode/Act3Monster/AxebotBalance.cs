using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class AxebotBalance
{
    // Balance: HammerUppercutDamage 11(13) → 9(11)
    [HarmonyPatch(typeof(Axebot), "HammerUppercutDamage", MethodType.Getter)]
    public class HammerUppercutDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 11: 9;
            return false;
        }
    }
}
