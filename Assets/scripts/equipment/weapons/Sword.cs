using characters;
namespace equipment.weapons
{
    class Sword : Equipment
    {
        private float damage;
        private float castTime;

        public Sword()// modifier? (chipped, balanced, etc)
        {
            this.damage = 2;
            this.castTime = 1.2f;
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
                string description = "Sword \n "+this.damage +"dmg after "+this.castTime+"s";
                if (equipped)
                    description += "\n *equipped";
                return description;
            }
        }

        public override string iconPath 
        {
            get {
                return "ui/icons/sword";
            }
        }

        public override string ToString()
        {
            return "Dagger { dmg: " + this.damage + ", castTime: " + this.castTime +"}";
        }
        
    }
}
