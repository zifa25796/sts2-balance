using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace balance.balanceCode.Act1Monster;

public class CubexConstructBalance
{
    private static readonly PropertyInfo BlastDamageProperty =
        typeof(CubexConstruct).GetProperty("BlastDamage", BindingFlags.NonPublic | BindingFlags.Instance);

    static int GetBlastDamage(CubexConstruct monster)
    {
        return (int)BlastDamageProperty.GetValue(monster);
    }

    // Balance: RepeaterBlast strength gain 2 → 1
    [HarmonyPatch]
    public class RepeaterBlastMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(CubexConstruct).GetMethod("RepeaterBlastMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(CubexConstruct __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunRepeaterBlast(__instance, targets);
            return false;
        }

        static async Task RunRepeaterBlast(CubexConstruct monster, IReadOnlyList<Creature> targets)
        {
            SfxCmd.SetParam("event:/sfx/enemy/enemy_attacks/cubex_construct/cubex_construct_charge_attack", "loop", 1f);
            await Cmd.Wait(0.4f);
            AttackCommand attackCommand = await DamageCmd.Attack((decimal)GetBlastDamage(monster))
                .FromMonster(monster)
                .WithAttackerAnim("Attack", 0.0f)
                .WithHitFx("vfx/vfx_attack_blunt", tmpSfx: "blunt_attack.mp3")
                .Execute(null);
            SfxCmd.SetParam("event:/sfx/enemy/enemy_attacks/cubex_construct/cubex_construct_charge_attack", "loop", 0.0f);
            await Cmd.Wait(0.2f);
            // 原版是 2M，改成 1M
            StrengthPower strengthPower = await PowerCmd.Apply<StrengthPower>(
                new ThrowingPlayerChoiceContext(),
                monster.Creature, 1M, monster.Creature, null);
            await CreatureCmd.TriggerAnim(monster.Creature, "AttackEnd", 0.0f);
        }
    }
}
