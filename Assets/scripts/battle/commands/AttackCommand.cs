using battle;
using characters;
namespace equipment
{
    class  AttackCommand : AbilityCommand
    {
        private BaseCharacter actor;
        private BaseCharacter target;
        private float damage;

        public AttackCommand(BaseCharacter actor, BaseCharacter target, float castTime, float damage)
        {
            this.actor = actor;
            this.target = target;
            this.castTime = castTime;
            this.damage = damage;
        }

        override public void execute()
        {
            BattleCalculator.resolveAttack(actor, target, damage);
            Messenger.Broadcast(BattleEvent.ABILITY_EXECUTED);
        }
    }
}
