
namespace Source
{
    public class DiceCardSelfAbility_energy2Appple : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Eden_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.cardSlotDetail.RecoverPlayPointByCard(2);
            this.card.target.cardSlotDetail.RecoverPlayPointByCard(2);
        }
    }
    public class DiceCardSelfAbility_heal10Appple : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Eden_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.RecoverHP(10);
            this.card.target.RecoverHP(10);
        }
    }
    public class DiceCardSelfAbility_ApplderScroll : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Eden_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.cardSlotDetail.RecoverPlayPointByCard(2);
            this.owner.allyCardDetail.DrawCards(2);
            this.owner.TakeBreakDamage(4, null, AtkResist.Normal);
        }
    }
    public class DiceCardSelfAbility_BreakTree : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Eden_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.TakeBreakDamage(7, null, AtkResist.Normal);
            this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 4
            });
        }
    }
    public class DiceCardSelfAbility_HealthTree : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Eden_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.TakeDamage(7, null);
            this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 4
            });
        }
    }
    public class DiceCardAbility_TreeHeal : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            this.owner.RecoverHP(3);
        }
    }
    public class DiceCardSelfAbility_Taboo : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Eden_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy))
            {
                battleUnitModel.Book.SetResistBP(LOR_DiceSystem.BehaviourDetail.Slash, AtkResist.Weak);
                battleUnitModel.bufListDetail.AddBuf(new Buf_Taboo());
            }
        }
        public override void OnEndBattle()
        {
            this.owner.Die();
        }
    }
    public class Buf_Taboo : BattleUnitBuf
    {
        public Buf_Taboo()
        {
            this.stack = 1;
            this._owner.Book.SetResistHP(LOR_DiceSystem.BehaviourDetail.Slash, AtkResist.Weak);
            this._owner.Book.SetResistHP(LOR_DiceSystem.BehaviourDetail.Penetrate, AtkResist.Weak);
            this._owner.Book.SetResistHP(LOR_DiceSystem.BehaviourDetail.Hit, AtkResist.Weak);
            this._owner.Book.SetResistBP(LOR_DiceSystem.BehaviourDetail.Slash, AtkResist.Weak);
            this._owner.Book.SetResistBP(LOR_DiceSystem.BehaviourDetail.Penetrate, AtkResist.Weak);
            this._owner.Book.SetResistBP(LOR_DiceSystem.BehaviourDetail.Hit, AtkResist.Weak);
        }
        public override void OnDie()
        {
            this._owner.Book.SetOriginalResists();
        }
    }
}
