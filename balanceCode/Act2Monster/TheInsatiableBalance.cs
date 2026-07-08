using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act2Monster;

public class TheInsatiableBalance
{
    [HarmonyPatch(typeof(TheInsatiable), "BiteDamage", MethodType.Getter)]
    public class BiteDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 29: 26;
            return false;
        }
    }
}