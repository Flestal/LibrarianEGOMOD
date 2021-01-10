
using System.Collections.Generic;

namespace Source
{
    public class DiceCardAbility_Where2reach1 : DiceCardAbilityBase
    {
        public override void OnWinParryingDefense()
        {
            PassiveAbility_36492806 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492806) as PassiveAbility_36492806;
            passive.flag_where2reach_toggle = true;
            if (passive.speedAdder < 4)
            {
                passive.speedAdder++;
            }
            BattleDiceCardModel newCard = this.owner.allyCardDetail.AddNewCard(36492010);
            newCard.SetCurrentCost(0);
            newCard.temporary = true;
        }
    }
    public class DiceCardAbility_Where2reach2 : DiceCardAbilityBase
    {
        public override void OnWinParryingDefense()
        {
            PassiveAbility_36492806 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492806) as PassiveAbility_36492806;
            passive.flag_where2reach_toggle = true;
            if (passive.speedAdder < 4)
            {
                passive.speedAdder++;
            }
            BattleDiceCardModel newCard = this.owner.allyCardDetail.AddNewCard(36492011);
            newCard.SetCurrentCost(0);
            newCard.temporary = true;
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
