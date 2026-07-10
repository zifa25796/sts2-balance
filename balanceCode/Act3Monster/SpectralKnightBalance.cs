using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class SpectralKnightBalance
{
    // Balance: MinHp 93 → 89
    [HarmonyPatch(typeof(SpectralKnight), nameof(SpectralKnight.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 93 : 89;
            return false;
        }
    }

    // Balance: MaxHp 93 → 89
    [HarmonyPatch(typeof(SpectralKnight), nameof(SpectralKnight.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 93 : 89;
            return false;
        }
    }
}
