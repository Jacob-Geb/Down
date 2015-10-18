using battle.attacks;
namespace equipment.weapons
{
    class Dagger : Equipment
    {
        private AttackArgs _attackArgs;

        public Dagger()
        {
            _attackArgs = new AttackArgs(2, 1);
        }

        public AttackArgs attackArgs
        {
            get { return _attackArgs; }
        }

        override public AbilityCommand getCommand
        {
            return new attackArgs

        }
    }
}
