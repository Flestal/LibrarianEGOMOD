namespace Source
{
    public class DiceCardAbility_JusticeAttack : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            base.card.AddDiceFace(DiceMatch.LastDice, 1);
            int count = 1;
            base.owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Positive, count);
            SingletonBehavior<BattleManagerUI>.Instance.ui_battleEmotionCoinUI.OnAcquireCoin(base.owner, EmotionCoinType.Positive, count);
        }
    }
}
