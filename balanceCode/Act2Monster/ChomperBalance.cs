using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class ChomperBalance
{
    // Balance: MinHp 62-65 → 58-65
    [HarmonyPatch(typeof(Chomper), nameof(Chomper.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 61 : 58;
            return false;
        }
    }

    // Balance: MaxHp 62-65 → 58-65
    [HarmonyPatch(typeof(Chomper), nameof(Chomper.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 65 : 62;
            return false;
        }
    }
}
