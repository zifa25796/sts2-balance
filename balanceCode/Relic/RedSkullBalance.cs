using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using balance.balanceCode.Power;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Relics;


namespace balance.balanceCode.Relic;

public class RedSkullBalance
{
    [HarmonyPatch(typeof(RedSkull), "ModifyStrengthIfNecessary")]
    public static class RedSkullPatch
    {
        private static bool HasRedSkullPower(Creature creature)
        {
            return creature.Powers.Any(p => p is RedSkullPower);
        }


        public static bool Prefix(RedSkull __instance, ref Task __result)
        {
            __result = ModifyRedSkull(__instance);

            // 阻止原版执行
            return false;
        }


        private static async Task ModifyRedSkull(RedSkull relic)
        {
            Creature creature = relic.Owner.Creature;


            bool belowThreshold =
                creature.CurrentHp <=
                creature.MaxHp *
                (relic.DynamicVars["HpThreshold"].BaseValue / 100M);


            relic.Status = belowThreshold
                ? RelicStatus.Active
                : RelicStatus.Normal;


            bool hasPower = HasRedSkullPower(creature);


            // HP <= 50%，没有 Power -> 添加
            if (belowThreshold && !hasPower)
            {
                relic.Flash();

                await PowerCmd.Apply<RedSkullPower>(
                    new ThrowingPlayerChoiceContext(),
                    creature,
                    1,
                    creature,
                    null
                );

                return;
            }


            // HP > 50%，有 Power -> 删除
            if (!belowThreshold && hasPower)
            {
                relic.Flash();

                await PowerCmd.Remove<RedSkullPower>(
                    creature
                );
            }
        }
    }
}