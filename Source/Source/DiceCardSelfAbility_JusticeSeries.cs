

using System.Collections.Generic;

namespace Source
{
    public class DiceCardSelfAbility_SlashingJustice : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_SpiderLegs_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.totalDamage = 0;
        }
        public override void AfterGiveDamage(int damage)
        {
            this.totalDamage += damage;
        }
        public override void OnEndBattle()
        {
            if (totalDamage >= activate)
            {
                this.owner.cardSlotDetail.RecoverPlayPointByCard(3);
                this.owner.allyCardDetail.DrawCards(1);
            }
        }
        private int activate = 20;
        private int totalDamage;
    }
    public class DiceCardSelfAbility_PenetratingJustice : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_SpiderLegs_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.totalDamage = 0;
        }
        public override void AfterGiveDamage(int damage)
        {
            this.totalDamage += damage;
            BattleUnitModel target = this.card.target;
            int j = RandomUtil.Range(0, 2);
            if (j == 0)
            {
                target.TakeDamage(RandomUtil.Range(1, 9), DamageType.Card_Ability, this.owner);
            }
            else
            {
                target.TakeBreakDamage(RandomUtil.Range(1, 9), DamageType.Card_Ability, this.owner);
            }
        }
        private int activate = 30;
        private int totalDamage;
    }
    public class DiceCardSelfAbility_CrushingJustice : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_SpiderLegs_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.totalDamage = 0;
        }
        public override void AfterGiveDamage(int damage)
        {
            this.totalDamage += damage;
        }
        public override void OnEndBattle()
        {
            if (totalDamage >= activate)
            {
                this.owner.cardSlotDetail.RecoverPlayPointByCard(1);
                this.owner.allyCardDetail.DrawCards(3);
            }
        }
        private int activate = 20;
        private int totalDamage;
    }
}
