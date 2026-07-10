using HarmonyLib;
using System.Reflection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

public class BigMushroomBalance
{
    // Balance: Big Mushroom heals 20% max HP on pickup
    [HarmonyPatch(typeof(BigMushroom), nameof(BigMushroom.AfterObtained))]
    public static class BigMushroomPatch
    {
        static async Task Postfix(BigMushroom __instance)
        {
            await CreatureCmd.Heal(
                __instance.Owner.Creature,
                __instance.Owner.Creature.MaxHp * 0.2M
            );
        }
    }
}
