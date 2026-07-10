using System.Reflection;
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;

namespace balance.balanceCode.Act1Monster;

public class SewerClamBalance
{
    // Balance: JetDamage 7(8) → 6(7)
    [HarmonyPatch(typeof(SewerClam), "JetDamage", MethodType.Getter)]
    public class JetDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 6;
            return false;
        }
    }

    // Balance: Pressurize grants 6 Strength
    [HarmonyPatch]
    public class PressurizeMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(SewerClam).GetMethod("PressurizeMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(SewerClam __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunPressurizeMove(__instance, targets);
            return false;
        }

        static async Task RunPressurizeMove(SewerClam monster, IReadOnlyList<Creature> targets)
        {
            SfxCmd.Play("event:/sfx/enemy/enemy_attacks/sewer_clam/sewer_clam_buff");
            await CreatureCmd.TriggerAnim(monster.Creature, "Cast", 1f);
            StrengthPower strengthPower = await PowerCmd.Apply<StrengthPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 6M, monster.Creature, (CardModel) null);
        }
    }
}
