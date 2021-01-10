using BaseMod;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Source
{
    public class PassiveAbility_36492813 : PassiveAbilityBase
    {
        //금빛 날개
        public override int SpeedDiceNumAdder()
        {
            return this.owner.emotionDetail.EmotionLevel;
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            int count = 1;
            base.owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Positive, count);
            SingletonBehavior<BattleManagerUI>.Instance.ui_battleEmotionCoinUI.OnAcquireCoin(base.owner, EmotionCoinType.Positive, count);
        }
        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            int count = 1;
            base.owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Negative, count);
            SingletonBehavior<BattleManagerUI>.Instance.ui_battleEmotionCoinUI.OnAcquireCoin(base.owner, EmotionCoinType.Negative, count);
        }
    }
    public class PassiveAbility_36492814 : PassiveAbilityBase
    {
        //믿음의 과실
        /*public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            Buf_Apple.AddBuf(behavior.card.target);
        }*/
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.Detail==LOR_DiceSystem.BehaviourDetail.Slash||behavior.Detail==LOR_DiceSystem.BehaviourDetail.Penetrate)
            {
                Buf_Apple.AddBuf(behavior.card.target);
            }
        }
        public class Buf_Apple : BattleUnitBuf
        {
            //지혜의 열매 버프
            protected override string keywordId
            {
                get
                {
                    return "buf_Apple";
                }
            }
            public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
            {
                int count = 2;
                base._owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Negative, count);
                SingletonBehavior<BattleManagerUI>.Instance.ui_battleEmotionCoinUI.OnAcquireCoin(base._owner, EmotionCoinType.Negative, count);
            }
            public override int GetDamageReductionAll()
            {
                if (this._owner.emotionDetail.EmotionLevel < 3)
                {
                    return 99999;
                }
                return base.GetDamageReductionAll();
            }
            public static int GetBuf(BattleUnitModel model)
            {
                List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
                Buf_Apple buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_Apple) as Buf_Apple;
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
            public static void AddBuf(BattleUnitModel model)
            {
                List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
                Buf_Apple buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_Apple) as Buf_Apple;
                bool flag = buf == null;
                if (flag)
                {
                    buf = new Buf_Apple(model);
                    buf.stack = 1;
                    model.bufListDetail.AddBuf(buf);
                }
                else
                {
                    buf.stack = 1;
                }
            }
            public static void DestroyBuf(BattleUnitModel model)
            {
                List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
                Buf_Apple buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_Apple) as Buf_Apple;
                bool flag = buf == null;
                if (!flag)
                {
                    buf.Destroy();
                }
            }
            public Buf_Apple(BattleUnitModel model)
            {
                this._owner = model;
                try
                {
                    typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Harmony_Patch.ArtWorks["Apple"]);
                    typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
                }
                catch (Exception ex)
                {
                    File.WriteAllText(Application.dataPath + "/BaseMods/LibrarianEGOMOD/BufAppleError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
                }
                this.stack = 0;
            }
        }
        /*public class TempImmortal : BattleUnitBuf
        {
            public TempImmortal()
            {
                this.stack = 1;
            }
            public override int GetDamageReductionAll()
            {
                return 99999;
            }
            public override void OnRoundEnd()
            {
                this.Destroy();
            }
        }*/
    }
}
