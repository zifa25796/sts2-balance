using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class SpinyToadBalance
{
    // Balance: LashDamage 17(19) → 15(17)
    [HarmonyPatch(typeof(SpinyToad), "LashDamage", MethodType.Getter)]
    public class LashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 17 : 15;
            return false;
        }
    }
}
