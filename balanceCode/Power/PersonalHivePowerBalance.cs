using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Entities.Players;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Models;

namespace balance.balanceCode.Power;

[HarmonyPatch(typeof(PersonalHivePower))]
public static class PersonalHivePowerBalance
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(PersonalHivePower.AfterDamageReceived))]
    public static bool AfterDamageReceivedPrefix(
        PersonalHivePower __instance,
        PlayerChoiceContext choiceContext,
        Creature target,
        DamageResult _,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource)
    {
        // 启动自己的 async 逻辑
        RewriteAfterDamageReceived(
            __instance,
            target,
            props,
            dealer
        );

        // 阻止原版执行
        return false;
    }


    private static async void RewriteAfterDamageReceived(
        PersonalHivePower power,
        Creature target,
        ValueProp props,
        Creature? dealer)
    {
        // 原版逻辑
        if (target != power.Owner)
            return;

        if (dealer == null)
            return;

        if (!props.IsPoweredAttack())
            return;


        // 原版特殊处理 Osty
        if (dealer.Monster is Osty)
        {
            dealer = dealer.PetOwner.Creature;
        }


        CardPileAddResult[] statusCards =
            new CardPileAddResult[power.Amount];


        for (int i = 0; i < power.Amount; i++)
        {
            CardModel card =
                power.CombatState.CreateCard<Dazed>(
                    dealer.Player
                );


            // 唯一修改点：
            // Draw -> Discard
            statusCards[i] =
                await CardPileCmd.AddGeneratedCardToCombat(
                    card,
                    PileType.Discard,
                    null,
                    CardPilePosition.Top
                );
        }


        CardCmd.PreviewCardPileAdd(statusCards);

        await Cmd.Wait(0.5f);
    }
}