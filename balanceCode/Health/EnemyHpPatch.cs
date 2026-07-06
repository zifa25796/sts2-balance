using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Singleton;
using System.Reflection;
using MegaCrit.Sts2.Core.Rooms;

namespace balance.balanceCode.Health;

[HarmonyPatch]
public class MultiplayerScalingPatch
{
    static MethodBase TargetMethod()
    {
        return typeof(MultiplayerScalingModel).GetMethod("GetMultiplayerScaling",
            BindingFlags.Static | BindingFlags.Public);
    }

    static bool Prefix(EncounterModel? encounter, int actIndex, ref decimal __result)
    {
        switch (actIndex)
        {
            case 0: // Act 1
                __result = 1.0M;
                return false;
            case 1: // Act 2
                __result = 1.1M;
                return false;
            case 2: // Act 3
                __result = encounter?.RoomType == RoomType.Boss ? 1.2M : 1.2M;
                return false;
            default:
                return true;
        }
    }
}