namespace Source
{
    public class DiceCardAbility_Gain1Tempo : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            Buf_Tempo.AddBuf(this.owner, 1);
        }
    }
    public class DiceCardAbility_Gain2Tempo : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            Buf_Tempo.AddBuf(this.owner, 2);
        }
    }
    public class DiceCardAbility_Gain3Tempo : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            Buf_Tempo.AddBuf(this.owner, 3);
        }
    }
    public class DiceCardAbility_Gain4Tempo : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            Buf_Tempo.AddBuf(this.owner, 4);
        }
    }
}
