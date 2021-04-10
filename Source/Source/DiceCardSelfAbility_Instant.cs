

using System.Collections.Generic;
using UnityEngine;

namespace Source
{
    public class DiceCardSelfAbility_SpiderFang : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "onlypage_SpiderLegs_Keyword"
                };
            }
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            base.OnUseInstance(unit, self, targetUnit);
            Buf_SpiderFang.AddBuf(targetUnit, 1, true);
        }
    }
    public class DiceCardSelfAbility_InstantCopy : DiceCardSelfAbilityBase
    {
        public override bool IsTargetableAllUnit()
        {
            return true;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            base.OnUseInstance(unit, self, targetUnit);
            List<BattleDiceCardModel> hand = unit.allyCardDetail.GetHand();
            if (hand.Count == 0)
            {
                return;
            }
            hand.Sort((BattleDiceCardModel x, BattleDiceCardModel y) => y.GetOriginCost() - x.GetOriginCost());
            int targetCost = hand[0].GetOriginCost();
            List<BattleDiceCardModel> list = hand.FindAll((BattleDiceCardModel x) => x.GetOriginCost() == targetCost);
            if (list.Count <= 0)
            {
                Debug.LogError("??? most cost not found");
                return;
            }
            BattleDiceCardModel battleDiceCardModel = RandomUtil.SelectOne<BattleDiceCardModel>(list);
            //base.owner.allyCardDetail.AddNewCard(battleDiceCardModel.GetID());
            unit.allyCardDetail.AddCardToHand(battleDiceCardModel);
            self.exhaust = true;
        }
    }
    public class DiceCardSelfAbility_InstantHeal : DiceCardSelfAbilityBase
    {
        public override bool IsTargetableAllUnit()
        {
            return true;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            base.OnUseInstance(unit, self, targetUnit);
            targetUnit.RecoverHP(10);
            //targetUnit.RecoverBreakLife(10);
            targetUnit.breakDetail.RecoverBreak(10);
        }
    }
    public class DiceCardSelfAbility_InstantRelax : DiceCardSelfAbilityBase
    {
        public override bool IsTargetableAllUnit()
        {
            return true;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            base.OnUseInstance(unit, self, targetUnit);
            targetUnit.cardSlotDetail.RecoverPlayPointByCard(1);
            targetUnit.allyCardDetail.DrawCards(1);
        }
    }
    public class DiceCardSelfAbility_InstantOverPower : DiceCardSelfAbilityBase
    {
        public override bool IsTargetableAllUnit()
        {
            return true;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            base.OnUseInstance(unit, self, targetUnit);
            targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Paralysis, 1);
            targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 2);
        }
    }
    public class DiceCardSelfAbility_InstantDamage : DiceCardSelfAbilityBase
    {
        public override bool IsTargetableAllUnit()
        {
            return true;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            base.OnUseInstance(unit, self, targetUnit);
            targetUnit.TakeDamage(10,DamageType.Card_Ability,unit);
        }
    }
}
