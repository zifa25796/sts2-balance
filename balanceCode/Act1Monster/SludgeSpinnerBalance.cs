using System.Reflection;
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;

namespace balance.balanceCode.Act1Monster;

public class SludgeSpinnerBalance
{
    private static readonly PropertyInfo RageDamageProperty =
        typeof(SludgeSpinner).GetProperty("RageDamage", BindingFlags.NonPublic | BindingFlags.Instance);

    static int GetRageDamage(SludgeSpinner monster)
    {
        return (int)RageDamageProperty.GetValue(monster);
    }

    // Balance: Rage grants 2 Strength (was 3)
    [HarmonyPatch]
    public class RageMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(SludgeSpinner).GetMethod("RageMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(SludgeSpinner __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunRageMove(__instance, targets);
            return false;
        }

        static async Task RunRageMove(SludgeSpinner monster, IReadOnlyList<Creature> targets)
        {
            AttackCommand attackCommand = await DamageCmd.Attack((Decimal) GetRageDamage(monster)).FromMonster((MonsterModel) monster).WithAttackerAnim("Attack", 0.5f).WithAttackerFx(sfx: "event:/sfx/enemy/enemy_attacks/sludge_spinner/sludge_spinner_attack_dash").WithHitFx("vfx/vfx_attack_blunt").Execute((PlayerChoiceContext) null);
            StrengthPower strengthPower = await PowerCmd.Apply<StrengthPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 2M, monster.Creature, (CardModel) null);
        }
    }
}
