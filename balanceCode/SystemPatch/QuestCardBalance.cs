using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace balance.balanceCode.SystemPatch;

public class QuestCardBalance
{
    [HarmonyPatch(typeof(Hook), nameof(Hook.AfterCardDrawn))]
    public static class QuestCardPatch
    {
        static void Postfix(
            ICombatState combatState,
            PlayerChoiceContext choiceContext,
            CardModel card,
            bool fromHandDraw,
            ref Task __result)
        {
            if (card.Type != CardType.Quest)
                return;

            __result = Continue(__result, card, choiceContext);
        }

        private static async Task Continue(
            Task original,
            CardModel card,
            PlayerChoiceContext choiceContext)
        {
            await original;

            await CardCmd.Exhaust(choiceContext, card);
            await CardPileCmd.Draw(choiceContext, card.Owner);
        }
    }
}