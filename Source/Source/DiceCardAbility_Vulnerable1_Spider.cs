namespace Source
{
    public class DiceCardAbility_VulnerableSpider : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            DiceCardAbility_SpiderLegs spiderlegs = behavior.abilityList.Find((DiceCardAbilityBase x) => x is DiceCardAbility_SpiderLegs) as DiceCardAbility_SpiderLegs;
            if (spiderlegs != null)
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vulnerable, spiderlegs.count_repeat);
            }
            else
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vulnerable, 1);
            }
        }
    }
}
