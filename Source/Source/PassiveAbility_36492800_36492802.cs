using LOR_DiceSystem;
using System;

namespace Source
{
    public class PassiveAbility_36492800 : PassiveAbilityBase
    {
        //최속
        public override int SpeedDiceNumAdder()
        {
            return 2;
        }
        public override void OnRollSpeedDice()
        {
            foreach (SpeedDice speedDice in this.owner.speedDiceResult)
            {
                speedDice.value = 999;
            }
        }
    }
    public class PassiveAbility_36492801 : PassiveAbilityBase
    {
        //거미다리
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            foreach (BattleDiceBehavior dice in curCard.GetDiceBehaviorList())
            {
                if (dice.Type == LOR_DiceSystem.BehaviourType.Atk && !dice.abilityList.Exists((DiceCardAbilityBase x) => x is DiceCardAbility_SpiderLegs))
                {
                    dice.AddAbility(new DiceCardAbility_SpiderLegs());
                }

            }
        }
        public override void OnWaveStart()
        {
            strengthAdder = 0;
        }
        public override void OnRoundStart()
        {
            if (strengthAdder > 0)
            {
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, strengthAdder);
            }
        }
        public int strengthAdder;
    }
    public class PassiveAbility_36492802 : PassiveAbilityBase
    {
        //집행
        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            target.TakeDamage(Convert.ToInt32((target.hp * 0.05) + 1), this.owner);
            target.TakeBreakDamage(Convert.ToInt32((target.breakDetail.breakGauge * 0.05) + 1), this.owner);
        }
    }
}
