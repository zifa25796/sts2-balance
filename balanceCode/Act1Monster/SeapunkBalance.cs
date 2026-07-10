using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class SeapunkBalance
{
    // Balance: BubbleBlock 6(7) → 5(6)
    [HarmonyPatch(typeof(Seapunk), "BubbleBlock", MethodType.Getter)]
    public class BubbleBlock
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }


}
