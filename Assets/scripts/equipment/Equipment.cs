
using battle.attacks;
namespace equipment
{
    abstract class Equipment
    {
        AttackArgs attackArgs { get; }

        abstract AbilityCommand getCommand();
    }
}
