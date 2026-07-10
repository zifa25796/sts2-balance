using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class TorchHeadAmalgamBalance
{
    // Balance: WeakTackleDamage 12(13) → 11(12)
    [HarmonyPatch(typeof(TorchHeadAmalgam), "WeakTackleDamage", MethodType.Getter)]
    public class WeakTackleDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 12: 11;
            return false;
        }
    }
}
