using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Event;

public class TrialBalance
{
    [HarmonyPatch]
    public class MerchantInnocent
    {
        
        static MethodBase TargetMethod()
        {
            return typeof(Trial).GetMethod("MerchantInnocent",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static bool Prefix(Trial __instance, ref Task __result)
        {
            __result = RunMerchantInnocent(__instance);
            return false;
        }

        static async Task RunMerchantInnocent(Trial trial)
        {
            CardModel deck = await CardPileCmd.AddCurseToDeck<Shame>(trial.Owner);
            CardSelectorPrefs prefs = new CardSelectorPrefs(CardSelectorPrefs.UpgradeSelectionPrompt, 3);
            foreach (CardModel card in await CardSelectCmd.FromDeckForUpgrade(trial.Owner, prefs))
                CardCmd.Upgrade(card);
            AccessTools.Method(typeof(Trial), "SetTrialFinished")
                ?.Invoke(trial, new object[]
                {
                    "TRIAL.pages.MERCHANT_INNOCENT.description"
                });
        }
    }
}