

namespace Source
{
    public class DiceCardSelfAbility_PowerUp1Tempo : DiceCardSelfAbilityBase
    {
		public override string[] Keywords
		{
			get
			{
				return new string[]
				{
				"onlypage_Tempo_Keyword"
				};
			}
		}
		public override void OnUseCard()
        {
			//Buf_Tempo tempo = base.owner.bufListDetail.GetActivatedBuf(KeywordBuf.Smoke) as BattleUnitBuf_smoke;
			Buf_Tempo tempo = this.owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
			if (tempo != null && tempo.stack >= 1)
			{
				tempo.UseStack(1);
				this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
				{
					power = 1
				});
			}
		}
    }
	public class DiceCardSelfAbility_PowerUp2Tempo : DiceCardSelfAbilityBase
	{
		public override string[] Keywords
		{
			get
			{
				return new string[]
				{
				"onlypage_Tempo_Keyword"
				};
			}
		}
		public override void OnUseCard()
		{
			//Buf_Tempo tempo = base.owner.bufListDetail.GetActivatedBuf(KeywordBuf.Smoke) as BattleUnitBuf_smoke;
			Buf_Tempo tempo = this.owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
			if (tempo != null && tempo.stack >= 2)
			{
				tempo.UseStack(2);
				this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
				{
					power = 2
				});
			}
		}
	}
	public class DiceCardSelfAbility_PowerUp3Tempo : DiceCardSelfAbilityBase
	{
		public override string[] Keywords
		{
			get
			{
				return new string[]
				{
				"onlypage_Tempo_Keyword"
				};
			}
		}
		public override void OnUseCard()
		{
			//Buf_Tempo tempo = base.owner.bufListDetail.GetActivatedBuf(KeywordBuf.Smoke) as BattleUnitBuf_smoke;
			Buf_Tempo tempo = this.owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
			if (tempo != null && tempo.stack >= 3)
			{
				tempo.UseStack(3);
				this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
				{
					power = 3
				});
			}
		}
	}
}
