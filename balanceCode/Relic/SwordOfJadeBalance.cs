using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using System.Reflection;
using balance.balanceCode.Power;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.Rooms;


namespace balance.balanceCode.Relic;


public class SwordOfJadeBalance
{
    // Balance: Reworked: gain 1 Str + 1 Dex per combat, Dexterity also adds to attack damage
    [HarmonyPatch(typeof(SwordOfJade), "get_CanonicalVars")]
    public class CanonicalVarsPatch
    {
        static void Postfix(ref IEnumerable<DynamicVar> __result)
        {
            __result = new DynamicVar[]
            {
                new PowerVar<StrengthPower>(1M)
            };
        }
    }

    [HarmonyPatch]
    public class AfterRoomEntered
    {
        static MethodBase TargetMethod()
        {
            return typeof(SwordOfJade).GetMethod("AfterRoomEntered",
                BindingFlags.Public | BindingFlags.Instance);
        }

        static bool Prefix(SwordOfJade __instance, AbstractRoom room, ref Task __result)
        {
            __result = RunAfterRoomEntered(__instance, room);
            return false;
        }

        static async Task RunAfterRoomEntered(SwordOfJade swordOfJade, AbstractRoom room)
        {
            if (!(room is CombatRoom))
                return;
            StrengthPower strengthPower = await PowerCmd.Apply<StrengthPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), swordOfJade.Owner.Creature, swordOfJade.DynamicVars.Strength.BaseValue, (Creature) null, (CardModel) null);
            DexterityPower dexterityPower = await PowerCmd.Apply<DexterityPower>((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), swordOfJade.Owner.Creature, swordOfJade.DynamicVars.Strength.BaseValue, (Creature) null, (CardModel) null);

            await PowerCmd.Apply<SwordOfJadePower>(
                new ThrowingPlayerChoiceContext(),
                swordOfJade.Owner.Creature,
                1,
                swordOfJade.Owner.Creature,
                null
            );
        }
    }
}
