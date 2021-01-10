
namespace Source
{
    public class DiceCardAbility_StrengthSpider : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            DiceCardAbility_SpiderLegs spiderlegs = behavior.abilityList.Find((DiceCardAbilityBase x) => x is DiceCardAbility_SpiderLegs) as DiceCardAbility_SpiderLegs;
            PassiveAbility_36492801 passive = this.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_36492801) as PassiveAbility_36492801;
            if (passive == null||spiderlegs==null)
            {
                return;
            }
            passive.strengthAdder += spiderlegs.count_repeat;
        }
    }
}
