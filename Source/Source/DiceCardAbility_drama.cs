
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
        public override void OnWinParrying()
        {
			base.ActivateBonusAttackDice();
		}
        public override void AfterAction()
        {
            base.AfterAction();
			Buf_BulletLoad.AddBuf(this.owner, 1);
		}
    }
	public class DiceCardAbility_OverLap : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
			get
			{
				return new string[]
				{
					"DrawCard_Keyword"
				};
			}
        }
        public override void OnWinParrying()
        {
			base.ActivateBonusAttackDice();
		}
        public override void AfterAction()
        {
            base.AfterAction();
			Buf_BulletLoad.AddBuf(this.owner, 1);
		}
    }
	public class DiceCardAbility_Closeup : DiceCardAbilityBase
	{
        public override void AfterAction()
        {
			PassiveAbility_36492809 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492809) as PassiveAbility_36492809;
			if (passive != null)
			{
				passive.DamageSum += this.behavior.DiceVanillaValue;
			}
			Buf_BulletLoad.AddBuf(this.owner, 1);
		}
        public override void BeforeRollDice_Target(BattleDiceBehavior targetDice)
        {
			PassiveAbility_36492809 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492809) as PassiveAbility_36492809;
			if (passive != null)
			{
				behavior.ApplyDiceStatBonus(new DiceStatBonus
				{
					power = passive.DamageSum

				});
			}
        }
    }
}
