using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class NoisebotBalance
{
    // Balance: MinHp 22-23(23-24) → 17-22(18-23)
    [HarmonyPatch(typeof(Noisebot), nameof(Noisebot.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 18 : 17;
            return false;
        }
    }

    // Balance: MaxHp 22-23(23-24) → 17-22(18-23)
    [HarmonyPatch(typeof(Noisebot), nameof(Noisebot.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 23 : 22;
            return false;
        }
    }
}
