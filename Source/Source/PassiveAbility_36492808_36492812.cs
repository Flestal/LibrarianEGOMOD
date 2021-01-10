using System;
using System.Collections.Generic;

namespace Source
{
    public class PassiveAbility_36492808 : PassiveAbilityBase
    {
        //발단
        public override bool IsImmune(KeywordBuf buf)
        {
            return buf == KeywordBuf.Bleeding || buf == KeywordBuf.Burn || buf==KeywordBuf.Decay || base.IsImmune(buf);
        }
        public override int SpeedDiceNumAdder()
        {
            return 2;
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.Far||behavior.card.card.GetSpec().Ranged==LOR_DiceSystem.CardRange.FarArea||behavior.card.card.GetSpec().Ranged==LOR_DiceSystem.CardRange.FarAreaEach)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 3
                });
            }
        }
    }
    public class PassiveAbility_36492809 : PassiveAbilityBase
    {
        //전개
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            this.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId());
        }
        public override void OnWaveStart()
        {
            DamageSum = 0;
        }
        public override void OnRoundStart()
        {
            bulletCount = 0;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            List<BattleDiceCardModel> list = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602020);
            List<BattleDiceCardModel> collection = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602021);
            List<BattleDiceCardModel> collection2 = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602022);
            list.AddRange(collection);
            list.AddRange(collection2);
            List<BattleDiceCardModel> list2 = new List<BattleDiceCardModel>();
            for (int i = 0; i < 3; i++)
            {
                bool flag = list.Count > 0;
                if (flag)
                {
                    list2.Add(RandomUtil.SelectOne<BattleDiceCardModel>(list));
                    bulletCount += 2;
                }
            }
            base.owner.allyCardDetail.DiscardACardByAbility(list2);
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = bulletCount
            });
        }
        public override void OnBattleEnd()
        {
            bulletCount = 0;
        }
        private int bulletCount;
        public int DamageSum;
    }
    public class PassiveAbility_36492810 : PassiveAbilityBase
    {
        //위기
        public override void OnRoundStart()
        {
            if (isUnder70() && isOver40())
            {
                this.owner.Book.sBpResist = AtkResist.Endure;
                this.owner.Book.pBpResist = AtkResist.Endure;
                this.owner.Book.hBpResist = AtkResist.Endure;
            }
        }
        public bool isUnder70()
        {
            return this.owner.breakDetail.breakGauge < this.owner.MaxBreakLife * 0.7;
        }
        public bool isOver40()
        {
            return this.owner.breakDetail.breakGauge >= this.owner.MaxBreakLife * 0.4;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (isUnder70())
            {
                if (curCard.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.Far || curCard.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.FarArea || curCard.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.FarAreaEach)
                {
                    foreach (BattleDiceBehavior dice in curCard.GetDiceBehaviorList())
                    {
                        if (dice.Type == LOR_DiceSystem.BehaviourType.Atk && !dice.abilityList.Exists((DiceCardAbilityBase x) => x is DiceCardAbility_GunnerOverClock1))
                        {
                            dice.AddAbility(new DiceCardAbility_GunnerOverClock1());
                        }
                    }
                }
            }
        }
    }
    public class PassiveAbility_36492811 : PassiveAbilityBase
    {
        //절정
        public override void OnRoundStart()
        {
            if (isUnder40())
            {
                this.owner.Book.sBpResist = AtkResist.Normal;
                this.owner.Book.pBpResist = AtkResist.Normal;
                this.owner.Book.hBpResist = AtkResist.Normal;
            }
        }
        public bool isUnder40()
        {
            return this.owner.breakDetail.breakGauge < this.owner.MaxBreakLife * 0.4;
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (isUnder40())
            {
                if (behavior.Detail == LOR_DiceSystem.BehaviourDetail.Slash || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Penetrate || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Hit)
                {
                    behavior.ApplyDiceStatBonus(new DiceStatBonus
                    {
                        power = 5
                    });
                }
                if (behavior.Detail == LOR_DiceSystem.BehaviourDetail.Guard || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Evasion)
                {
                    behavior.ApplyDiceStatBonus(new DiceStatBonus
                    {
                        power = -3
                    });
                }
            }
        }
    }
    public class PassiveAbility_36492812 : PassiveAbilityBase
    {
        //결말
        public override bool OnBreakGageZero()
        {
            this.owner.Die(null);
            return base.OnBreakGageZero();
        }
    }
}
