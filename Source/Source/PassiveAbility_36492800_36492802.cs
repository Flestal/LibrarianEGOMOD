using LOR_BattleUnit_UI;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;

namespace Source
{
    public class PassiveAbility_36492800 : PassiveAbilityBase
    {
        //최속
        public override int SpeedDiceNumAdder()
        {
            return 2;
        }
        /*public override void OnRoundStart()
        {
            diceColors = new List<int>();
            for(int i = 0; i < this.owner.speedDiceResult.Count; i++)
            {
                diceColors.Add(-1);
            }
            for(int i = 0; i < diceColors.Count; i++)
            {
                diceColors[i]=RandomUtil.Range(0, 3);
            }
        }*/
        public override void OnRollSpeedDice()
        {
            foreach (SpeedDice speedDice in this.owner.speedDiceResult)
            {
                speedDice.value = 999;
            }
        }
        /*public override void OnFixedUpdateInWaitPhase(float delta)
        {
            base.OnFixedUpdateInWaitPhase(delta);
            for(int i = 0; i < diceColors.Count; i++)
            {
                if (diceColors[i] != null && diceColors[i] != -1)
                {
                    SpeedDiceUI UI = this.owner.view.speedDiceSetterUI.GetSpeedDiceByIndex(i);
                    if (SingletonBehavior<BattleManagerUI>.Instance.ui_unitCardsInHand.OnPointerOverInSpeedDice != UI||this.owner.faction==Faction.Enemy)
                    {
                        UI.SetColor(colors[diceColors[i]],colors[diceColors[i]]);
                    }
                }
            }
        }
        public List<int> diceColors = new List<int>();
        public UnityEngine.Color[] colors = new UnityEngine.Color[3] { new UnityEngine.Color(1,1,1),new UnityEngine.Color(1,0.5f,0.5f),new UnityEngine.Color(1,0,0)};*/
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
            strengthAdder = 8;
        }
        public override void OnRoundStart()
        {
            if (strengthAdder>0)
            {
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, strengthAdder);
                
            }
        }
        public override void OnRoundEnd()
        {
            if (strengthAdder > 0)
            {
                strengthAdder--;
            }
        }
        public int strengthAdder;
    }
    public class PassiveAbility_36492802 : PassiveAbilityBase
    {
        //견각
        public override void OnWaveStart()
        {
            base.OnWaveStart();
            Buf_NegatePower_Spider.AddBuf(this.owner);
        }

    }
    public class Buf_NegatePower_Spider : BattleUnitBuf
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel card)
        {
            base.OnUseCard(card);
            card.ignorePower = true;
        }
        public override void OnStartParrying(BattlePlayingCardDataInUnitModel card)
        {
            base.OnStartParrying(card);
            BattleUnitModel target = card.target;
            if (target == null || target.currentDiceAction == null)
            {
                return;
            }
            target.currentDiceAction.ignorePower = true;
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);

            if (this._owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x.bufType == KeywordBuf.Strength) && behavior.Type == BehaviourType.Atk)
            {
                int stack = this._owner.bufListDetail.GetActivatedBuf(KeywordBuf.Strength).stack;
                int min = stack, max = stack;
                if (this._owner.emotionDetail.EmotionLevel >= 3)
                {
                    min = stack * 2;
                    max = stack * 2;
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = min,
                    max = max
                });
            }
            if (this._owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x.bufType == KeywordBuf.Endurance) && behavior.Type == BehaviourType.Def)
            {
                int stack = this._owner.bufListDetail.GetActivatedBuf(KeywordBuf.Endurance).stack;
                int min = stack, max = stack;
                if (this._owner.emotionDetail.EmotionLevel >= 3)
                {
                    min = stack * 2;
                    max = stack * 2;
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = min,
                    max = max
                });
            }
        }
        public static bool GetBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_NegatePower_Spider buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_NegatePower_Spider) as Buf_NegatePower_Spider;
            bool flag = buf == null;
            if (flag)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void AddBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_NegatePower_Spider buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_NegatePower_Spider) as Buf_NegatePower_Spider;
            bool flag = buf == null;
            if (flag)
            {
                buf = new Buf_NegatePower_Spider(model);
                model.bufListDetail.AddBuf(buf);
            }
            /*else
            {
            }*/
        }
        public static void DestroyBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_NegatePower_Spider buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_NegatePower_Spider) as Buf_NegatePower_Spider;
            bool flag = buf == null;
            if (!flag)
            {
                buf.Destroy();
            }
        }
        public Buf_NegatePower_Spider(BattleUnitModel model)
        {
            this._owner = model;
            /*try
            {
                typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Harmony_Patch.ArtWorks["Apple"]);
                typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            }
            catch (Exception ex)
            {
                File.WriteAllText(Application.dataPath + "/BaseMods/LibrarianEGOMOD/BufAppleError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
            this.stack = 0;*/
        }
    }
}
