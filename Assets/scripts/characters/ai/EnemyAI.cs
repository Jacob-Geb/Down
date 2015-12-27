using characters.enemy;
using characters.player;
using equipment;
using UnityEngine;
namespace characters.ai
{
    public class EnemyAI
    {
        private BaseCharacter enemy;
        private BaseCharacter player;
        private float nextMove = 0;

        public EnemyAI(EnemyModel enemy, PlayerModel player)
        {
            this.enemy = enemy;
            this.player = player;

            nextMove = 3.0f;
            // make depending on type of enemy
        }

        public void updateAI()
        {
            // check for something
            // current moves
            // player stats and shit 

            nextMove -= Time.deltaTime;
            if (nextMove <= 0)
            {
                nextMove = 3.6f;

                AbilityCommand enemyAttack = new AttackCommand(enemy, player, 3.5f, 3);
                Messenger<AbilityCommand>.Broadcast(EnemyAIEvent.TRY_START_ENEMY_ABILITY, enemyAttack);
            }
        }

    }
}
