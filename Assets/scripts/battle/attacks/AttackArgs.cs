namespace battle.attacks
{
    public struct AttackArgs
    {
        public float castTime;
        public float amount;

        public AttackArgs(float castTime, float amount)
        {
            this.castTime = castTime;
            this.amount = amount;
        }
    }

}
