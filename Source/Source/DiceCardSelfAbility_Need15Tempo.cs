

namespace Source
{
    public class DiceCardSelfAbility_Need15Tempo : DiceCardSelfAbilityBase
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
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            Buf_Tempo tempo = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
            if (tempo.stack >= 15)
            {
                return true;
            }
            return false;
        }
    }
}
