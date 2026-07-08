using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class ByrdonisBalance
{
    [HarmonyPatch(typeof(Byrdonis), "SwoopDamage", MethodType.Getter)]
    public class SwoopDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 18: 16;
            return false;
        }
    }
}