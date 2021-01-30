
using System.Collections.Generic;

namespace Source
{
	public class DiceCardAbility_EdenGuard : DiceCardAbilityBase
	{
		public override string[] Keywords
		{
			get
			{
				return new string[]
				{
					
				};
			}
		}
        public override void OnWinParrying()
        {
            if (this.count < 3)
            {
				this.count++;
				base.ActivateBonusAttackDice();
            }
		}
		public int count;
	}
}
