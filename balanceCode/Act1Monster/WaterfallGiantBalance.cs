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

public class WaterfallGiantBalance
{
    [HarmonyPatch(typeof(WaterfallGiant), "StompDamage", MethodType.Getter)]
    public class StompDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 10: 9;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(WaterfallGiant), "RamDamage", MethodType.Getter)]
    public class RamDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 15: 14;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(WaterfallGiant), "PressureUpDamage", MethodType.Getter)]
    public class PressureUpDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 12: 11;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(WaterfallGiant), "BasePressureGunDamage", MethodType.Getter)]
    public class BasePressureGunDamage
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 18: 15;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(WaterfallGiant), "PressureGunIncrease", MethodType.Getter)]
    public class PressureGunIncrease
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.DeadlyEnemies) ? 7: 7;
            return false;
        }
    }

    static void IncrementBuildUpAnimationTrack(WaterfallGiant monster)
    {
        typeof(WaterfallGiant)
            .GetMethod("IncrementBuildUpAnimationTrack", BindingFlags.NonPublic | BindingFlags.Instance)
            .Invoke(monster, null);
    }
    
    static int GetPressureUpDamage(WaterfallGiant monster)
    {
        return (int)typeof(WaterfallGiant)
            .GetProperty("PressureUpDamage", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(monster);
    }
    
    static int GetStompDamage(WaterfallGiant monster)
    {
        return (int)typeof(WaterfallGiant)
            .GetProperty("StompDamage", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(monster);
    }
    
    static int GetRamDamage(WaterfallGiant monster)
    {
        return (int)typeof(WaterfallGiant)
            .GetProperty("RamDamage", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(monster);
    }
    
    static int GetCurrentPressureGunDamage(WaterfallGiant monster)
    {
        return (int)typeof(WaterfallGiant)
            .GetProperty("CurrentPressureGunDamage", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(monster);
    }

    static void SetCurrentPressureGunDamage(WaterfallGiant monster, int value)
    {
        typeof(WaterfallGiant)
            .GetProperty("CurrentPressureGunDamage", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(monster, value);
    }
    
    static int GetPressureGunIncrease(WaterfallGiant monster)
    {
        return (int)typeof(WaterfallGiant)
            .GetProperty("PressureGunIncrease", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(monster);
    }
    
    [HarmonyPatch]
    public class PressureUpMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(WaterfallGiant).GetMethod("PressureUpMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(WaterfallGiant __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunPressureUpMove(__instance, targets);
            return false;
        }

        static async Task RunPressureUpMove(WaterfallGiant monster, IReadOnlyList<Creature> targets)
        {
            AttackCommand attackCommand = await DamageCmd.Attack((Decimal) GetPressureUpDamage(monster)).FromMonster((MonsterModel) monster).WithAttackerAnim("AttackBuff", 0.15f).WithAttackerFx(sfx: "event:/sfx/enemy/enemy_attacks/waterfall_giant/waterfall_giant_attack_stomp").WithHitFx("vfx/vfx_attack_blunt").Execute((PlayerChoiceContext) null);
            SteamEruptionPower steamEruptionPower = await PowerCmd.Apply<SteamEruptionPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 6M, monster.Creature, (CardModel) null);
            IncrementBuildUpAnimationTrack(monster);
        }
    }
    
    [HarmonyPatch]
    public class StompMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(WaterfallGiant).GetMethod("StompMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(WaterfallGiant __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunStompMove(__instance, targets);
            return false;
        }

        static async Task RunStompMove(WaterfallGiant monster, IReadOnlyList<Creature> targets)
        {
            AttackCommand attackCommand = await DamageCmd.Attack((Decimal) GetStompDamage(monster)).FromMonster((MonsterModel) monster).WithAttackerAnim("AttackDebuff", 0.3f).WithAttackerFx(sfx: "event:/sfx/enemy/enemy_attacks/waterfall_giant/waterfall_giant_attack_stomp").WithHitFx("vfx/vfx_attack_blunt").Execute((PlayerChoiceContext) null);
            IReadOnlyList<WeakPower> weakPowerList = await PowerCmd.Apply<WeakPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), (IEnumerable<Creature>) targets, 1M, monster.Creature, (CardModel) null);
            SteamEruptionPower steamEruptionPower = await PowerCmd.Apply<SteamEruptionPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 1M, monster.Creature, (CardModel) null);
            IncrementBuildUpAnimationTrack(monster);
        }
    }
    
    [HarmonyPatch]
    public class RamMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(WaterfallGiant).GetMethod("RamMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(WaterfallGiant __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunRamMove(__instance, targets);
            return false;
        }

        static async Task RunRamMove(WaterfallGiant monster, IReadOnlyList<Creature> targets)
        {
            AttackCommand attackCommand = await DamageCmd.Attack((Decimal) GetRamDamage(monster)).FromMonster((MonsterModel) monster).WithAttackerAnim("Attack", 0.3f).WithAttackerFx(sfx: "event:/sfx/enemy/enemy_attacks/waterfall_giant/waterfall_giant_attack_kick").WithHitFx("vfx/vfx_attack_blunt").Execute((PlayerChoiceContext) null);
            SteamEruptionPower steamEruptionPower = await PowerCmd.Apply<SteamEruptionPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 1M, monster.Creature, (CardModel) null);
            IncrementBuildUpAnimationTrack(monster);
        }
    }
    
    [HarmonyPatch]
    public class SiphonMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(WaterfallGiant).GetMethod("SiphonMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(WaterfallGiant __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunSiphonMove(__instance, targets);
            return false;
        }

        static async Task RunSiphonMove(WaterfallGiant monster, IReadOnlyList<Creature> targets)
        {
            SfxCmd.Play("event:/sfx/enemy/enemy_attacks/waterfall_giant/waterfall_giant_eruption");
            await CreatureCmd.TriggerAnim(monster.Creature, "Heal", 0.8f);
            await CreatureCmd.Heal(monster.Creature, (Decimal) (monster.SiphonHeal * monster.CombatState.Players.Count));
            SteamEruptionPower steamEruptionPower = await PowerCmd.Apply<SteamEruptionPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 6M, monster.Creature, (CardModel) null);
            IncrementBuildUpAnimationTrack(monster);
        }
    }
    
    [HarmonyPatch]
    public class PressureGunMove
    {
        static MethodBase TargetMethod()
        {
            return typeof(WaterfallGiant).GetMethod("PressureGunMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(WaterfallGiant __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunPressureGunMove(__instance, targets);
            return false;
        }

        static async Task RunPressureGunMove(WaterfallGiant monster, IReadOnlyList<Creature> targets)
        {
            AttackCommand attackCommand = await DamageCmd.Attack((Decimal) GetCurrentPressureGunDamage(monster)).FromMonster((MonsterModel) monster).WithAttackerAnim("Attack", 0.3f).WithAttackerFx(sfx: "event:/sfx/enemy/enemy_attacks/waterfall_giant/waterfall_giant_attack_kick").WithHitFx("vfx/vfx_attack_blunt").Execute((PlayerChoiceContext) null);
            int current = GetCurrentPressureGunDamage(monster);
            int increase = (int)typeof(WaterfallGiant)
                .GetProperty("PressureGunIncrease", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(monster);
            SetCurrentPressureGunDamage(monster, current + increase);
            SteamEruptionPower steamEruptionPower = await PowerCmd.Apply<SteamEruptionPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, 1M, monster.Creature, (CardModel) null);
            IncrementBuildUpAnimationTrack(monster);
        }
    }
}