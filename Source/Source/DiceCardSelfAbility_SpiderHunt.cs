

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
            BattleUnitModel target = this.card.target;
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 3);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Disarm, 3);
        }
    }
}
