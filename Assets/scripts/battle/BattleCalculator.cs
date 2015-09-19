using battle.attacks;
using characters;
namespace battle
{
    public class BattleCalculator
    {
        public static void resolveAttack(ICharacter attacker, ICharacter defender, AttackArgs attackArgs)
        {
            defender.hp -= attackArgs.amount;
        }
    }
}
