using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class SlumberingBeetlesBalance
{
    // Balance: PlatingAmount 16(18) → 13(16)
    [HarmonyPatch(typeof(SlumberingBeetle), "PlatingAmount", MethodType.Getter)]
    public class PlatingAmount
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 13;
            return false;
        }
    }
}
