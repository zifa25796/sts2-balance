using HarmonyLib;
using System.Reflection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

public class BigMushroomBalance
{  
    [HarmonyPatch(typeof(BigMushroom), nameof(BigMushroom.AfterObtained))]
    public static class BigMushroomPatch
    {
        static async void Postfix(BigMushroom __instance)
        {
            await CreatureCmd.Heal(
                __instance.Owner.Creature, 
                __instance.Owner.Creature.MaxHp * 0.2M
            );
        }
    }
}