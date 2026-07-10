using System.Collections.Generic;
using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.ValueProps;

namespace balance.balanceCode.Event;

public class RoomFullOfCheeseBalance
{
    [HarmonyPatch(typeof(RoomFullOfCheese), "GenerateInitialOptions")]
    public class GenerateInitialOptionsPatch
    {
        static void Postfix(RoomFullOfCheese __instance)
        {
            int act = __instance.Owner.RunState.CurrentActIndex;

            int damage = act >= 1 ? 8 : 14;

            DynamicVar oldVar = __instance.DynamicVars.Damage;

            oldVar.BaseValue = damage;
        }
    }
}