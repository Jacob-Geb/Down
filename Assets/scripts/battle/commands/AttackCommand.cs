using battle.attacks;
using characters;
namespace equipment
{
    class  AttackCommand
    {
        private BaseCharacter _target;
        private float _damage;

        public AttackCommand(BaseCharacter target, float damage )
        {
            this._target = target;
            this._damage = damage;
        }

        override public void execute()
        {
            _target.hp -= _damage;
        }
    }
}
