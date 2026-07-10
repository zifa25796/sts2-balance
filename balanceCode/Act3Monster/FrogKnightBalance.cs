using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class FrogKnightBalance
{
    // Balance: TongueLashDamage 10(11) → 9(10)
    [HarmonyPatch(typeof(FrogKnight), "TongueLashDamage", MethodType.Getter)]
    public class TongueLashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 9;
            return false;
        }
    }

    // Balance: StrikeDownEvilDamage 22(24) → 20(22)
    [HarmonyPatch(typeof(FrogKnight), "StrikeDownEvilDamage", MethodType.Getter)]
    public class StrikeDownEvilDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 22: 20;
            return false;
        }
    }
}
