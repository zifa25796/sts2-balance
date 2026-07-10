using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using System;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.Relics;


namespace balance.balanceCode.Relic;

public class CentennialPuzzleBalance
{
    // Balance: After trigger, gain 3 Block Next Turn
    [HarmonyPatch(typeof(CentennialPuzzle), nameof(CentennialPuzzle.AfterDamageReceived))]
    public static class CentennialPuzzle_AddBlockNextTurn_Patch
    {
        // 记录触发前的UsedThisCombat状态
        static void Prefix(CentennialPuzzle __instance, out bool __state)
        {
            __state = __instance.UsedThisCombat;
        }

        static async Task Postfix(
            Task __result,
            CentennialPuzzle __instance,
            bool __state,
            PlayerChoiceContext choiceContext,
            Creature target)
        {
            await __result;

            bool actuallyTriggered = !__state && __instance.UsedThisCombat;
            if (!actuallyTriggered)
                return;

            PowerCmd.Apply<BlockNextTurnPower>(
                choiceContext,
                target,
                3m,
                null,   // Creature? — 第4个参数，看报错应该是可选的来源/施法者之类，先传null
                null,   // CardModel? — 卡牌来源，没有就传null
                false); // bool — 具体含义不确定，多半是"是否显示浮动提示"之类的开关
        }
    }
}
