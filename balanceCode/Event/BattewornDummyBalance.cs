using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Event;

public class BattewornDummyBalance
{
    // Balance: HP set to 250
    [HarmonyPatch(typeof(BattleFriendV3), nameof(BattleFriendV3.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 250 : 250;
            return false;
        }
    }

    // Balance: HP set to 250
    [HarmonyPatch(typeof(BattleFriendV3), nameof(BattleFriendV3.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 250 : 250;
            return false;
        }
    }
}
