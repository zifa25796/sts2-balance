using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class CalcifiedCultistBalance
{
    [HarmonyPatch(typeof(CalcifiedCultist), "DarkStrikeDamage", MethodType.Getter)]
    public class DarkStrikeDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 8;
            return false;
        }
    }
}