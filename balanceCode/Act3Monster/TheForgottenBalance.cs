using System.Reflection;
using MegaCrit.Sts2.Core.Entities.Ascension;
using MegaCrit.Sts2.Core.Helpers;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using System;

namespace balance.balanceCode.Act3Monster;

public class TheForgottenBalance
{
    [HarmonyPatch(typeof(TheForgotten), nameof(TheForgotten.MinInitialHp), MethodType.Getter)]
    public class MinHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 105 : 99;
            return false;
        }
    }

    [HarmonyPatch(typeof(TheForgotten), nameof(TheForgotten.MaxInitialHp), MethodType.Getter)]
    public class MaxHp
    {
        static bool Prefix(ref int __result)
        {
            __result = AscensionHelper.HasAscension(AscensionLevel.ToughEnemies) ? 105 : 99;
            return false;
        }
    }
    
    [HarmonyPatch(typeof(TheForgotten), "DreadDamage", MethodType.Getter)]
    [HarmonyPostfix]
    public static void DreadDamagePostfix(
        TheForgotten __instance,
        ref int __result)
    {
        int dex =
            __instance.Creature.GetPowerAmount<DexterityPower>();

        __result =
            AscensionHelper.GetValueIfAscension(
                AscensionLevel.DeadlyEnemies,
                12,
                10
            )
            + dex;
    }
    
    
    [HarmonyPatch]
    public class MiasmaMove
    {
        private static readonly Func<TheForgotten, string> GetCastSfx =
            AccessTools.MethodDelegate<Func<TheForgotten, string>>(
                AccessTools.PropertyGetter(typeof(MonsterModel), "CastSfx")
            );

        private static readonly Func<TheForgotten, int> GetDebilitatingSmogDexStealAmount =
            AccessTools.MethodDelegate<Func<TheForgotten, int>>(
                AccessTools.PropertyGetter(
                    typeof(TheForgotten),
                    "DebilitatingSmogDexStealAmount"
                )!
            );


        static MethodBase TargetMethod()
        {
            return typeof(TheForgotten).GetMethod("MiasmaMove",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(TheForgotten __instance, IReadOnlyList<Creature> targets, ref Task __result)
        {
            __result = RunMiasmaMove(__instance, targets);
            return false;
        }

        static async Task RunMiasmaMove(TheForgotten monster, IReadOnlyList<Creature> targets)
        {
            SfxCmd.Play(GetCastSfx(monster));
            await CreatureCmd.TriggerAnim(monster.Creature, "Cast", 0.5f);
            IReadOnlyList<DexterityPower> dexterityPowerList = await PowerCmd.Apply<DexterityPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), (IEnumerable<Creature>) targets, (decimal) - GetDebilitatingSmogDexStealAmount(monster), monster.Creature, (CardModel) null);
            Decimal num = await CreatureCmd.GainBlock(monster.Creature, 0M, ValueProp.Move, (CardPlay) null);
            DexterityPower dexterityPower = await PowerCmd.Apply<DexterityPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), monster.Creature, (Decimal)GetDebilitatingSmogDexStealAmount(monster), monster.Creature, (CardModel) null);

        }
    }
}