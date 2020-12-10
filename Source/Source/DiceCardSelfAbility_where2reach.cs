
namespace Source
{
    public class DiceCardSelfAbility_Where2reach : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Helix_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.allyCardDetail.DrawCardsAllSpecific(36492010);
            this.owner.allyCardDetail.DrawCardsAllSpecific(36492011);
        }
    }
    public class DiceCardSelfAbility_Question : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Helix_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.cardSlotDetail.RecoverPlayPointByCard(2);
        }
    }
    public class DiceCardSelfAbility_Understanding : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "onlypage_Helix_Keyword",
                    "Strength_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 2);
        }
    }
    public class DiceCardSelfAbility_Helix : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Helix_Keyword"
                };
            }
        }
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            //dice.abilityList.Exists((DiceCardAbilityBase x) => x is DiceCardAbility_SpiderLegs)
            if (this.owner.passiveDetail.PassiveList.Exists((PassiveAbilityBase x)=>x is PassiveAbility_36492806))
            {
                PassiveAbility_36492806 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492806) as PassiveAbility_36492806;
                return passive.flag_question && passive.flag_understanding && passive.flag_where2reach;
            }
            return false;
        }
        public override void OnUseCard()
        {
            base.OnUseCard();
            this.card.card.exhaust = true;
        }
    }
}
