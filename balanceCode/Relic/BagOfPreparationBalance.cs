using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.Relics;

namespace balance.balanceCode.Relic;

public class BagOfPreparationBalance
{
    // Balance: Turn 1 full bonus, Turn 2 +1, beyond 0
    [HarmonyPatch(typeof(BagOfPreparation), nameof(BagOfPreparation.ModifyHandDraw))]
    class BagOfPreparationBalanceHandler
    {
        static bool Prefix(BagOfPreparation __instance, Player player, decimal count, ref decimal __result)
        {
            if (player != __instance.Owner)
            {
                __result = count;
                return false;
            }

            int turn = __instance.Owner.PlayerCombatState.TurnNumber;

            if (turn == 1)
            {
                __result = count + __instance.DynamicVars.Cards.BaseValue;
            }
            else if (turn == 2)
            {
                __result = count + 1;
            }
            else
            {
                __result = count;
            }

            return false;
        }
    }
}
