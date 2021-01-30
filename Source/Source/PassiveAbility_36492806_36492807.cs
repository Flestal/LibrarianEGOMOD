using System;

namespace Source
{
    public class PassiveAbility_36492806 : PassiveAbilityBase
    {
        //탑은 하늘에 닿으며
        public override int SpeedDiceNumAdder()
        {
            return 3+speedAdder;
        }
        public override void OnWaveStart()
        {
            this.flag_question = false;
            this.flag_understanding = false;
            this.flag_where2reach = false;
            this.flag_where2reach_toggle = false;
            speedAdder = 0;
        }
        public override void OnRoundStart()
        {
            this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
            this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 2);
        }
        public override void OnRoundEnd()
        {
            if (this.flag_where2reach_toggle)
            {
                this.flag_where2reach_toggle = false;
                return;
            }
            this.speedAdder = 0;
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
        public int speedAdder;
        public bool flag_where2reach_toggle;
    }
    public class PassiveAbility_36492807 : PassiveAbilityBase
    {
        //땅에는 무엇도 남기지 않으리라
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            foreach (BattleUnitModel target in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy))
            {
                target.TakeBreakDamage(behavior.DiceResultDamage, DamageType.Passive,this.owner, target.GetResistBP(behavior.Detail));
            }
        }
    }
}
