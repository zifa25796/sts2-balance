using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Act1Monster;

public class ToadpoleBalance
{
    // Balance: MinHp 20-24(20-24) → 19-23
    [HarmonyPatch(typeof(Toadpole), nameof(Toadpole.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 20 : 19;
            return false;
        }
    }

    // Balance: MaxHp 20-24(20-24) → 19-23
    [HarmonyPatch(typeof(Toadpole), nameof(Toadpole.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 24 : 23;
            return false;
        }
    }

    [HarmonyPatch(typeof(Toadpole), "SpikeSpitDamage", MethodType.Getter)]
    public class SpikeSpitDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 3: 3;
            return false;
        }
    }

    // Balance: WhirlDamage 7(8) → 6(7)
    [HarmonyPatch(typeof(Toadpole), "WhirlDamage", MethodType.Getter)]
    public class WhirlDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }

    [HarmonyPatch(typeof(Toadpole), "SpikenAmount", MethodType.Getter)]
    public class SpikenAmount
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 3: 3;
            return false;
        }
    }
}
