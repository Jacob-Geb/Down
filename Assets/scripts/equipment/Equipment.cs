
using characters;
namespace equipment
{
    public abstract class Equipment
    {
        public bool equipped { get; set; }
        public Slot slot { get; protected set; }
        public abstract string description { get; }
        public abstract string iconPath { get; }

        public abstract AbilityCommand getCommand(BaseCharacter actor, BaseCharacter target);

    }
}
