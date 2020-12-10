
using LOR_DiceSystem;
using System;
using System.IO;
using UnityEngine;

namespace Source
{
    public class DiceCardSelfAbility_FadeIn : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Drama_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.cardSlotDetail.RecoverPlayPointByCard(2);
        }
    }
    public class DiceCardSelfAbility_Overlap : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Drama_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.allyCardDetail.DrawCards(2);
        }
    }
    public class DiceCardSelfAbility_CloseUp : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Drama_Keyword"
                };
            }
        }
        public override void OnStartBattle()
        {
            this.card.target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vulnerable, 5, this.owner);
        }
    }
    public class DiceCardSelfAbility_Adlib : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Drama_Keyword"
                };
            }
        }
        public override void OnUseCard()
        {
            this.card.RemoveAllDice();
            int AdlibType = 36492100;
            BehaviourDetail def = BehaviourDetail.Slash;
            if (this.card.target.Book.GetResistHP(def) > this.card.target.Book.GetResistHP(BehaviourDetail.Penetrate))
            {
                def = BehaviourDetail.Penetrate;
            }
            if (this.card.target.Book.GetResistHP(def) > this.card.target.Book.GetResistHP(BehaviourDetail.Hit))
            {
                def = BehaviourDetail.Hit;
            }
            switch (def)
            {
                case BehaviourDetail.Slash:
                    AdlibType = 36492100;
                    break;
                case BehaviourDetail.Penetrate:
                    AdlibType = 36492101;
                    break;
                case BehaviourDetail.Hit:
                    AdlibType = 36492102;
                    break;
                default:
                    break;
            }
            try
            {
                DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(AdlibType);
                BattleDiceCardModel adlib_card = BattleDiceCardModel.CreatePlayingCard(cardItem);
                if (adlib_card != null)
                {
                    foreach (BattleDiceBehavior battleDiceBehavior in adlib_card.CreateDiceCardBehaviorList())
                    {
                        if (battleDiceBehavior.Type != BehaviourType.Standby)
                        {
                            this.card.AddDice(battleDiceBehavior);
                        }
                    }
                }
            }catch(Exception ex)
            {
                File.WriteAllText(Application.dataPath + "/BaseMods/LibrarianEGOMOD/AdlibError.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
            
        }
    }
    public class DiceCardSelfAbility_FadeOut : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_Drama_Keyword"
                };
            }
        }
        public override void OnEndBattle()
        {
            this.card.target.breakDetail.DestroyBreakPoint();
        }
    }
}
