namespace Source
{
    public class DiceCardAbility_Vulnerable1Spider : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vulnerable, 1);
        }
    }
}
