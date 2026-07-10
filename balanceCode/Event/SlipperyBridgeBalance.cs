using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace balance.balanceCode.Event;

public class SlipperyBridgeBalance
{
    private static readonly FieldInfo RandomCardField =
        AccessTools.Field(typeof(SlipperyBridge), "_randomCardToLose");

    private static readonly FieldInfo SkippedRemovalsField =
        AccessTools.Field(typeof(SlipperyBridge), "_skippedRemovals");

    private static readonly FieldInfo NumberOfHoldOnsField =
        AccessTools.Field(typeof(SlipperyBridge), "_numberOfHoldOns");


    // Balance: HP loss starts at 2, each Hold On +1
    [HarmonyPatch(typeof(SlipperyBridge), "CurrentHpLoss", MethodType.Getter)]
    public static class CurrentHpLossPatch
    {
        public static bool Prefix(
            SlipperyBridge __instance,
            ref int __result)
        {
            int holdOns = (int)NumberOfHoldOnsField.GetValue(__instance);

            // 初始2，每次Hold On +1
            __result = 2 + holdOns;

            return false;
        }
    }


    // Balance: First card removal no longer excludes Basic cards
    [HarmonyPatch(typeof(SlipperyBridge), "GetNewRandomCard")]
    public static class GetNewRandomCardPatch
    {
        public static bool Prefix(SlipperyBridge __instance)
        {
            var owner = __instance.Owner;

            CardModel? currentCard =
                (CardModel?)RandomCardField.GetValue(__instance);


            HashSet<CardModel>? skipped =
                (HashSet<CardModel>?)
                SkippedRemovalsField.GetValue(__instance);


            List<CardModel> cards;


            // 第一次：不再排除 Basic
            if (currentCard == null)
            {
                cards = owner.Deck.Cards.ToList();
            }
            else
            {
                // 后续保持原逻辑
                if (skipped == null)
                {
                    skipped = new HashSet<CardModel>();

                    SkippedRemovalsField.SetValue(
                        __instance,
                        skipped);
                }

                skipped.Add(currentCard);


                cards = owner.Deck.Cards
                    .Where(c => c.GetType() != currentCard.GetType())
                    .ToList();
            }


            cards.RemoveAll(c =>
            {
                if (!c.IsRemovable)
                    return true;

                return skipped != null &&
                       skipped.Contains(c);
            });


            // 防止没有卡
            if (cards.Count == 0)
            {
                cards = owner.Deck.Cards
                    .Where(c => c.IsRemovable)
                    .ToList();
            }


            CardModel newCard =
                __instance.Rng.NextItem(cards);


            RandomCardField.SetValue(
                __instance,
                newCard);


            // 更新 DynamicVar
            ((StringVar)__instance.DynamicVars["RandomCard"])
                .StringValue = newCard.Title;


            return false;
        }
    }
}
