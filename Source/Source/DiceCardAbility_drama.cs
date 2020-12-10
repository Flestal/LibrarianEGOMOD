
using System.Collections.Generic;

namespace Source
{
	public class DiceCardAbility_FadeIn : DiceCardAbilityBase
	{
		public override string[] Keywords
		{
			get
			{
				return new string[]
				{
					"Energy_Keyword"
				};
			}
		}

		public override void OnSucceedAttack()
		{
			base.owner.cardSlotDetail.RecoverPlayPointByCard(2);
		}
	}
}
