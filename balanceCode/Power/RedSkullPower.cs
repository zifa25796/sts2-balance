
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

public sealed class RedSkullPower : CustomPowerModel
{
    /*
    public override List<(string, string)> Localization => new PowerLoc(
        "Red Skull",
        "While your HP is at or below [blue]50%[/blue], you deal 30% additional damage.",
        "While your HP is at or below [blue]50%[/blue], you deal 30% additional damage."
    );
    */
    
    public override string? CustomPackedIconPath =>
        "res://balance/images/powers/RedSkull.png";

    public override string? CustomBigIconPath =>
        "res://balance/images/powers/RedSkull.png";

    public override List<(string, string)> Localization => LocManager.Instance.Language switch
    { 
        "zhs" => new PowerLoc(
            "红头骨",
            "当你的生命值低于或等于[blue]50%[/blue]时，你造成[blue]30%[/blue]额外伤害。",
            "当你的生命值低于或等于[blue]50%[/blue]时，你造成[blue]30%[/blue]额外伤害。"
            ),
        _ => new PowerLoc(
            "Red Skull",
            "While your HP is at or below [blue]50%[/blue], you deal [blue]30%[/blue] additional damage.",
            "While your HP is at or below [blue]50%[/blue], you deal [blue]30%[/blue] additional damage."
        )
    };
    
    public override PowerType Type => PowerType.Buff;
    
    public override PowerStackType StackType => PowerStackType.Counter;

    public override Decimal ModifyDamageMultiplicative(
        Creature? target,
        Decimal amount,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource,
        CardPlay? cardPlay)
    {
        if ( cardSource == null || cardSource.Owner.Creature != this.Owner)
            return 1M;

        return 1.3m;
    }
}

