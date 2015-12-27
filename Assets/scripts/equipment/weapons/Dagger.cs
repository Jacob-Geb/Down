using characters;
namespace equipment.weapons
{
    class Dagger : Equipment
    {
        private float damage;
        private float castTime;

        public Dagger()// modifier? (chipped, balanced, etc)
        {
            this.damage = 1;
            this.castTime = 2.0f;
            this.slot = Slot.LEFT_HAND;
        }

        public override AbilityCommand getCommand(BaseCharacter actor, BaseCharacter target)
        {
            return new AttackCommand(actor, target, castTime, damage);
        }

        public override string description
        {
            get
            {
                string description = "Dagger \n "+this.damage +"dmg after "+this.castTime+"s";
                if (equipped)
                    description += "\n *equipped";
                return description;
            }
        }

        public override string iconPath 
        {
            get {
                return "ui/icons/dagger";
            }
        }

        public override string ToString()
        {
            return "Dagger { dmg: " + this.damage + ", castTime: " + this.castTime +"}";
        }
        
    }
}
