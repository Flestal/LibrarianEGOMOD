
namespace Source
{
    public class DiceCardAbility_Strength1Spider : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1);
        }
    }
}
