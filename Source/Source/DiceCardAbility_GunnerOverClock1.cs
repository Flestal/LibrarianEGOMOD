namespace Source
{
    class DiceCardAbility_GunnerOverClock1:DiceCardAbilityBase
    {
        public override void AfterAction()
        {
            if (this._count < 2)
            {
                this._count++;
                base.ActivateBonusAttackDice();
            }
        }
        private int _count;
    }
}
