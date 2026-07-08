
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Combat.History.Entries;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using System;
using System.Linq;
using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

#nullable enable

namespace balance.balanceCode.Power;


public class SwordOfJadePower : CustomPowerModel
{
    public override string? CustomPackedIconPath =>
        "res://balance/images/powers/StS2_SwordofJade.png";

    public override string? CustomBigIconPath =>
        "res://balance/images/powers/StS2_SwordofJade.png";

    public override List<(string, string)> Localization => LocManager.Instance.Language switch
    { 
        "zhs" => new PowerLoc(
            "玉之剑",
            "你的[gold]敏捷[/gold]也会增加你的攻击伤害",
            "你的[gold]敏捷[/gold]也会增加你的攻击伤害"
        ),
        _ => new PowerLoc(
            "Sword of Jade",
            "Your [gold]Dexterity[/gold] also increase attack damage",
            "Your [gold]Dexterity[/gold] also increase attack damage"
        )
    };
    
    public override PowerType Type => PowerType.Buff;
    
    public override PowerStackType StackType => PowerStackType.Counter;
    
    public override bool AllowNegative => true;

    public override Decimal ModifyDamageAdditive(
        Creature? target,
        Decimal amount,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource,
        CardPlay? cardPlay)
    {
        // 只影响攻击
        if (!props.IsPoweredAttack()
            || cardSource == null
            || cardSource.Owner.Creature != this.Owner)
            return 0m;


        var dex = Owner.Powers.FirstOrDefault(p => p is DexterityPower) as DexterityPower;

        if (dex == null)
            return 0m;


        return dex.Amount;
    }
}