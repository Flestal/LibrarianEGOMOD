
using System.Collections.Generic;

namespace Source
{
    public class DiceCardAbility_Where2reach1 : DiceCardAbilityBase
    {
        public override void OnWinParryingDefense()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            if (aliveList.Count > 0)
            {
                BattleUnitModel target = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                List<BattleDiceCardModel> cardlist = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 36492010);
                BattleDiceCardModel card_ = RandomUtil.SelectOne<BattleDiceCardModel>(cardlist);
                if (card_ != null)
                {
                    BattlePlayingCardDataInUnitModel useCard = this.card;
                    useCard.card = card_;
                    useCard.cardAbility = card_.CreateDiceCardSelfAbilityScript();
                    useCard.owner = this.owner;
                    Singleton<StageController>.Instance.AddAllCardListInBattle(useCard, target);
                }
            }
        }
    }
    public class DiceCardAbility_Where2reach2 : DiceCardAbilityBase
    {
        public override void OnWinParryingDefense()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            if (aliveList.Count > 0)
            {
                BattleUnitModel target = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                List<BattleDiceCardModel> cardlist = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 36492011);
                BattleDiceCardModel card_ = RandomUtil.SelectOne<BattleDiceCardModel>(cardlist);
                if (card_ != null)
                {
                    BattlePlayingCardDataInUnitModel useCard = this.card;
                    useCard.card = card_;
                    useCard.cardAbility = card_.CreateDiceCardSelfAbilityScript();
                    useCard.owner = this.owner;
                    Singleton<StageController>.Instance.AddAllCardListInBattle(useCard, target);
                }
            }
        }
    }
    public class DiceCardAbility_Understanding : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction != null)
            {
                currentDiceAction.DestroyDice(DiceMatch.AllDefenseDice, DiceUITiming.AttackAfter);
            }
        }
    }
}
