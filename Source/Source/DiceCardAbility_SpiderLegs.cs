

namespace Source
{
    class DiceCardAbility_SpiderLegs:DiceCardAbilityBase
    {
        public override bool IsDoublePower()
        {
            if (this.count_repeat == 7)
            {
                return true;
            }
            return false;
        }
        public override void AfterAction()
        {
            if (this.count_repeat < 7)
            {
                this.count_repeat++;
                base.ActivateBonusAttackDice();
            }
        }
        public int count_repeat;
    }
}
