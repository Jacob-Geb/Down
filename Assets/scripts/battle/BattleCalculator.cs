using characters;
using equipment;
namespace battle
{
    public class BattleCalculator
    {
        //public static void resolveAttack(ICharacter attacker, ICharacter defender, AbilityCommand command)
        //{
        //    defender.hp -= command.amount;
        //}

        public static void resolveAttack(ICharacter attacker, ICharacter defender, float damage)
        {
            // buffs, bonus & other abilities
            defender.hp -= damage;
        }
    }
}
