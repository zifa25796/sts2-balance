using System.Reflection;
using Godot;
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;

namespace balance.balanceCode.Act2Monster;

public class DecimillipedeSegmentBalance
{
    // Balance: MinHp 44-48(48-52) → 38-44(42-48)
    [HarmonyPatch(typeof(DecimillipedeSegment), nameof(DecimillipedeSegment.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 42 : 38;
            return false;
        }
    }

    // Balance: MaxHp 44-48(48-52) → 38-44(42-48)
    [HarmonyPatch(typeof(DecimillipedeSegment), nameof(DecimillipedeSegment.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 48 : 44;
            return false;
        }
    }

    // Balance: ConstrictDamage 7(8) → 6(7)
    [HarmonyPatch(typeof(DecimillipedeSegment), "ConstrictDamage", MethodType.Getter)]
    public class ConstrictDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }

    // Balance: BulkDamage 6(7) → 5(6)
    [HarmonyPatch(typeof(DecimillipedeSegment), "BulkDamage", MethodType.Getter)]
    public class BulkDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
}
