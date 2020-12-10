

namespace Source
{
    class DiceCardAbility_SpiderLegs:DiceCardAbilityBase
    {
        public override void AfterAction()
        {
            if (this._count < 7)
            {
                this._count++;
                base.ActivateBonusAttackDice();
            }
        }
        private int _count;
    }
}
