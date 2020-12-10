using System;

namespace Source
{
    public class PassiveAbility_36492806 : PassiveAbilityBase
    {
        //탑은 하늘에 닿으며
        public override int SpeedDiceNumAdder()
        {
            return 3;
        }
        public override void OnWaveStart()
        {
            flag_question = false;
            flag_understanding = false;
            flag_where2reach = false;
        }
        public override void OnRoundStart()
        {
            this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
            this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 2);
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetID() == 36492010)
            {
                this.flag_question = true;
            }
            if (curCard.card.GetID() == 36492011)
            {
                this.flag_understanding = true;
            }
            if (curCard.card.GetID() == 36492012)
            {
                this.flag_where2reach = true;
            }
        }
        public bool flag_question;
        public bool flag_understanding;
        public bool flag_where2reach;
    }
    public class PassiveAbility_36492807 : PassiveAbilityBase
    {
        //땅에는 무엇도 남기지 않으리라
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            foreach (BattleUnitModel target in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy))
            {
                target.TakeBreakDamage(behavior.DiceResultDamage, this.owner, target.GetResistBP(behavior.Detail));
            }
        }
    }
}
