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
    class Buf_SpiderFang:BattleUnitBuf
    {
        protected override string keywordId
        {
            get
            {
                return "buf_SpiderFang";
            }
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                max = -this.stack
            });
        }
        public override void OnRoundEndTheLast()
        {
            this.Add(1,false);
            this.endtime--;
            if (this.endtime <= 0)
            {
                this.Destroy();
            }
        }
        public static int GetBuf(BattleUnitModel model)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_SpiderFang buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_SpiderFang) as Buf_SpiderFang;
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
        public static void AddBuf(BattleUnitModel model, int add, bool isByCard=false)
        {
            List<BattleUnitBuf> activatedBufList = model.bufListDetail.GetActivatedBufList();
            Buf_SpiderFang buf = activatedBufList.Find((BattleUnitBuf x) => x is Buf_SpiderFang) as Buf_SpiderFang;
            bool flag = buf == null;
            if (flag)
            {
                buf = new Buf_SpiderFang(model);
                buf.Add(add,isByCard);
                model.bufListDetail.AddBuf(buf);
            }
            else
            {
                buf.Add(add,isByCard);
            }
        }
        public void Add(int add,bool isByCard)
        {
            this.stack += add;
            if (isByCard)
            {
                this.endtime = 3;
            }
        }
        public Buf_SpiderFang(BattleUnitModel model)
        {
            this._owner = model;
            try
            {
                typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Harmony_Patch.ArtWorks["SpiderFang"]);
                typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            }
            catch (Exception ex)
            {
                File.WriteAllText(Application.dataPath + "/BaseMods/LibrarianEGOMOD/BufFangError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
            this.stack = 0;
            this.endtime = 3;
        }
        int endtime;
    }
}
