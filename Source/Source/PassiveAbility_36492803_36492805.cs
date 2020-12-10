using System;

namespace Source
{
    public class PassiveAbility_36492803 : PassiveAbilityBase
    {
        //아 피아체레
        public override void OnRoundStart()
        {
            this.owner.Book.SetMaxPlayPoint(10-this.owner.emotionDetail.EmotionLevel);
            this.owner.cardSlotDetail.SetPlayPoint(10);
        }
        public override int SpeedDiceNumAdder()
        {
            return 2;
        }
        public override int GetSpeedDiceAdder(int speedDiceResult)
        {
            return 5;
        }
    }
    public class PassiveAbility_36492804 : PassiveAbilityBase
    {
        //크레센도
        public override void OnRoundStart()
        {
            winCount = 0;
        }
        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            winCount++;
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = winCount
            });
        }
        private int winCount;
    }
    public class PassiveAbility_36492805 : PassiveAbilityBase
    {
        //칸타빌레
        public override void OnRoundStart()
        {
            flag = false;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.FarArea || curCard.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.FarAreaEach)
            {
                flag = true;
            }
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (flag)
            {
                this.owner.RecoverHP(behavior.DiceResultValue);
                this.owner.RecoverBreakLife(behavior.DiceResultValue);
            }
        }
        public override void OnBattleEnd()
        {
            flag = false;
        }
        private bool flag;
    }
}
