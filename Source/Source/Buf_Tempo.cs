using BaseMod;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Source
{
    class Buf_Tempo:BattleUnitBuf
    {
        protected override string keywordId
        {
            get
            {
                return "buf_Tempo";
            }
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Type == LOR_DiceSystem.BehaviourType.Standby)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = this.stack
                });
            }
        }
        public override void OnRoundEndTheLast()
        {
            this.stack--;
            if (this.stack <= 0)
            {
                this.Destroy();
            }
        }
        public static int GetBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_Tempo buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
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
            Buf_Tempo buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
            bool flag = buf == null;
            if (flag)
            {
                buf = new Buf_Tempo(model);
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
            if (this.stack > 20)
            {
                this.stack = 20;
            }
        }
        /*public static void DestroyBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_Tempo buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_Tempo) as Buf_Tempo;
            bool flag = buf == null;
            if (!flag)
            {
                buf.Destroy();
            }
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
        public Buf_Tempo(BattleUnitModel model)
        {
            this._owner = model;
            try
            {
                typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Harmony_Patch.ArtWorks["Tempo"]);
                typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            }
            catch (Exception ex)
            {
                File.WriteAllText(Application.dataPath + "/BaseMods/LibrarianEGOMOD/BufAppleError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
            this.stack = 0;
        }
    }
}
