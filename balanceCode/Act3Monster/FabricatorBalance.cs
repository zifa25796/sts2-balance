using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act3Monster;

public class FabricatorBalance
{
    // Balance: FabricatingStrikeDamage 16(18) → 13(16)
    [HarmonyPatch(typeof(Fabricator), "FabricatingStrikeDamage", MethodType.Getter)]
    public class FabricatingStrikeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 16: 13;
            return false;
        }
    }
}
