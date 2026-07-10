using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.ValueProps;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Models;

namespace balance.balanceCode.Act1Monster;

public class SlitheringStranglerBalance
{
    // Balance: ThwackDamage 6(7) → 5(6)
    [HarmonyPatch(typeof(SlitheringStrangler), "ThwackDamage", MethodType.Getter)]
    public class ThwackDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 6: 5;
            return false;
        }
    }
    
    // Balance: LashDamage 11(12) → 10(11)
    [HarmonyPatch(typeof(SlitheringStrangler), "LashDamage", MethodType.Getter)]
    public class LashDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 11: 10;
            return false;
        }
    }

    private static readonly PropertyInfo ThwackDamageProperty =
        typeof(SlitheringStrangler).GetProperty("ThwackDamage", BindingFlags.NonPublic | BindingFlags.Instance);

    static int GetThrawkDamage(SlitheringStrangler monster)
    {
        return (int)ThwackDamageProperty.GetValue(monster);
    }
    
    // Balance: ThwackMove now grants 4 block
    [HarmonyPatch]
    public class ThwackMovePatch
    {
        static MethodBase TargetMethod()
        {
            return typeof(SlitheringStrangler).GetMethod("ThwackMove",
                BindingFlags.Instance | BindingFlags.NonPublic);
        }

        static bool Prefix(SlitheringStrangler __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunThwackMove(__instance, targets);
            return false;
        }

        static async Task RunThwackMove(SlitheringStrangler monster, IReadOnlyList<Creature> targets)
        {
            AttackCommand attackCommand = await DamageCmd.Attack((Decimal) GetThrawkDamage(monster)).FromMonster((MonsterModel) monster).WithAttackerAnim("AttackDefendTrigger", 0.2f).WithAttackerFx(sfx: "event:/sfx/enemy/enemy_attacks/slithering_strangler/slithering_strangler_attack_headbutt").WithHitFx("vfx/vfx_attack_slash").Execute((PlayerChoiceContext) null);
            Decimal num = await CreatureCmd.GainBlock(monster.Creature, 4M, ValueProp.Move, (CardPlay) null);
        }
    }
}