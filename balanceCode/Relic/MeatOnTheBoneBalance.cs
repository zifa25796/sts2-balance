using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

public class MeatOnTheBoneBalance
{
    private static readonly Func<MeatOnTheBone, bool> WillHealOnCombatFinished =
        AccessTools.MethodDelegate<Func<MeatOnTheBone, bool>>(
            AccessTools.Method(typeof(MeatOnTheBone), "WillHealOnCombatFinished"));

    // Balance: Heals 3 if HP between threshold and 70%
    [HarmonyPatch]
    public class AfterCombatVictoryEarly
    {
        static MethodBase TargetMethod()
        {
            return typeof(MeatOnTheBone).GetMethod("AfterCombatVictoryEarly",
                BindingFlags.Public | BindingFlags.Instance);
        }

        static bool Prefix(MeatOnTheBone __instance, ref Task __result)
        {
            __result = RunAfterCombatVictoryEarly(__instance);
            return false;
        }

        static async Task RunAfterCombatVictoryEarly(MeatOnTheBone meatOnTheBone)
        {
            if (meatOnTheBone.Owner.Creature.IsDead)
                return;
            Creature creature = meatOnTheBone.Owner.Creature;
            if (!WillHealOnCombatFinished(meatOnTheBone))
                return;
            meatOnTheBone.Status = RelicStatus.Normal;
            int num = (int) ((Decimal) meatOnTheBone.Owner.Creature.MaxHp * (meatOnTheBone.DynamicVars["HpThreshold"].BaseValue / 100M));
            int num2 = (int)((Decimal)meatOnTheBone.Owner.Creature.MaxHp * (70M / 100M));
            if (meatOnTheBone.Owner.Creature.CurrentHp > num && meatOnTheBone.Owner.Creature.CurrentHp <= num2)
            {
                await CreatureCmd.Heal(creature, 3M);
            }
            else
            {
                await CreatureCmd.Heal(creature, meatOnTheBone.DynamicVars.Heal.BaseValue);
            }
        }

    }
}
