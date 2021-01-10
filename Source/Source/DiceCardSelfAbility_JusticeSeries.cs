

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
        }
        public override void OnEndBattle()
        {
            if (totalDamage >= activate)
            {
                List<BattleUnitModel> alivelist = BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
                if (alivelist.Count > 0)
                {
                    BattleUnitModel target = RandomUtil.SelectOne<BattleUnitModel>(alivelist);
                    Singleton<StageController>.Instance.AddAllCardListInBattle(this.card, target);
                }
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
