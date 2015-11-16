using characters;
namespace equipment.weapons
{
    class Shield : Equipment
    {
        private float blockAmount;// 0 none - 1 all
        private float castTime;

        public Shield()// modifier? (chipped, balanced, etc)
        {
            this.blockAmount = 1;
            this.castTime = 1;
            this.slot = Slot.RIGHT_HAND;
        }

        public override AbilityCommand getCommand(BaseCharacter actor, BaseCharacter target)
        {
            return new ShieldCommand(actor, castTime, blockAmount);
        }

        public override string description
       {
            get
            {
                string description = "Shield \n blocks " + this.blockAmount *100 + "% of dmg, time: " + this.castTime + "s";
                if (equipped)
                    description += "\n *equipped";
                return description;
            }
        }

        public override string iconPath 
        {
            get {
                return "ui/icons/shield";
            }
        }

        public override string ToString()
        {
            return "Shield { dmg: " + this.blockAmount + ", castTime: " + this.castTime + "}";
        }
        
    }
}
