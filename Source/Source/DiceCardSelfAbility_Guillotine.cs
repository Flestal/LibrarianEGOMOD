
namespace Source
{
    public class DiceCardSelfAbility_Guillotine : DiceCardSelfAbilityBase
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
        public override void OnEndBattle()
        {
            if (this.card.target != null && this.card.target.IsDead())
            {
                this.owner.cardSlotDetail.SetPlayPoint(this.owner.cardSlotDetail.GetMaxPlayPoint());
            }
        }
    }
}
