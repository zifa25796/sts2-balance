using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class OwlMagistrateBalance
{
    // Balance: MinHp 240 → 225
    [HarmonyPatch(typeof(OwlMagistrate), nameof(OwlMagistrate.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 240 : 225;
            return false;
        }
    }

    // Balance: MaxHp 240 → 225
    [HarmonyPatch(typeof(OwlMagistrate), nameof(OwlMagistrate.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 240 : 225;
            return false;
        }
    }
}
