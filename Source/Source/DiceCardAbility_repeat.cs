
namespace Source
{
    public class DiceCardAbility_repeat5 : DiceCardAbilityBase
    {
        public override void AfterAction()
        {
            if (this._repeatCount < 4)
            {
                this._repeatCount++;
                base.ActivateBonusAttackDice();
            }
        }
        private int _repeatCount;
    }
    public class DiceCardAbility_repeat7Helix : DiceCardAbilityBase
    {
        public override void AfterAction()
        {
            if (this._repeatCount < 6)
            {
                this._repeatCount++;
                base.ActivateBonusAttackDice();
            }
        }
        private int _repeatCount;
    }
}
