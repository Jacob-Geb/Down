namespace battle.attacks
{
    public struct AttackArgs
    {
        public float castTime;
        public float amount;

        /// <summary> 
        /// The attack data object
        /// </summary> 
        /// <param name="castTime"> time in s to cast.</param>
        /// <param name="amount"> damage dealt.</param>
        public AttackArgs(float castTime, float amount)
        {
            this.castTime = castTime;
            this.amount = amount;
        }
    }

}
