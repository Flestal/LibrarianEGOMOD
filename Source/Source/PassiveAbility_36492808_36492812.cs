using BaseMod;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
            //this.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId());
        }
        public override void OnWaveStart()
        {
            Buf_BulletLoad.AddBuf(this.owner,0);
            DamageSum = 0;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            Buf_BulletLoad bulletLoad = this.owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is Buf_BulletLoad) as Buf_BulletLoad;
            if (bulletLoad != null && bulletLoad.stack < curCard.GetDiceBehaviorList().Count)
            {
                bulletLoad.UseStack(curCard.GetDiceBehaviorList().Count);
                foreach(BattleDiceBehavior behavior in curCard.GetDiceBehaviorList())
                {
                    behavior.ApplyDiceStatBonus(new DiceStatBonus
                    {
                        power = curCard.GetDiceBehaviorList().Count*2
                    });
                }
            }else if (bulletLoad != null)
            {
                int bullets = bulletLoad.stack;
                bulletLoad.UseStack(bullets);
                foreach (BattleDiceBehavior behavior in curCard.GetDiceBehaviorList())
                {
                    behavior.ApplyDiceStatBonus(new DiceStatBonus
                    {
                        power = bullets*2
                    });
                }
            }
        }
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
    class Buf_BulletLoad : BattleUnitBuf
    {
        //장탄
        protected override string keywordId
        {
            get
            {
                return "buf_BulletLoad";
            }
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == LOR_DiceSystem.CardRange.Far)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = this.stack
                });
            }
        }
        /*public override void OnRoundEndTheLast()
        {
            this.Add(1);
        }*/
        public bool UseStack(int v)
        {
            if (this.stack < v)
            {
                return false;
            }
            this.stack -= v;
            return true;
        }
        public static int GetBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_BulletLoad buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_BulletLoad) as Buf_BulletLoad;
            bool flag = buf == null;
            int result;
            if (flag)
            {
                result = 0;
            }
            else
            {
                result = buf.stack;
            }
            return result;
        }
        public static void AddBuf(BattleUnitModel model, int add)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_BulletLoad buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_BulletLoad) as Buf_BulletLoad;
            bool flag = buf == null;
            if (flag)
            {
                buf = new Buf_BulletLoad(model);
                buf.Add(add);
                model.bufListDetail.AddBuf(buf);
            }
            else
            {
                buf.Add(add);
            }
        }
        public void Add(int add)
        {
            this.stack += add;
        }
        public Buf_BulletLoad(BattleUnitModel model)
        {
            this._owner = model;
            try
            {
                typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Harmony_Patch.ArtWorks["BulletLoad"]);
                typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            }
            catch (Exception ex)
            {
                File.WriteAllText(Application.dataPath + "/BaseMods/LibrarianEGOMOD/BufBulletError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
            this.stack = 0;
        }
    }
}
