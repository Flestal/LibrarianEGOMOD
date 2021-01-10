

namespace Source
{
    public class DiceCardSelfAbility_SpiderHunt : DiceCardSelfAbilityBase
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
            PassiveAbility_36492801 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492801) as PassiveAbility_36492801;
            passive.strengthAdder = 0;
            BattleUnitModel target = this.card.target;
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 3);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Disarm, 3);
        }
    }
}
