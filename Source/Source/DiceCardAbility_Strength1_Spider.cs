
namespace Source
{
    public class DiceCardAbility_FangSpider : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            BattleUnitModel target = this.card.target;
            Buf_SpiderFang.AddBuf(target, 1, true);
        }
    }
}
