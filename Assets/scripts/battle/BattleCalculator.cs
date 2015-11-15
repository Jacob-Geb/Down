using characters;
using equipment;
using UnityEngine;
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

            if (defender.effects.Contains("shield"))
            {
                defender.effects.Remove("shield");
                if (defender.isPlayer)
                    Messenger<string>.Broadcast(BattleUIEvent.REMOVE_PLAYER_EFFECT, "shield");
                return;
            }

            defender.hp -= damage;
        }
    }
}
