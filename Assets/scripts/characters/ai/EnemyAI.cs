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

            nextMove = 3;
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
                nextMove = Random.Range(0, 1) + 4;

                //AttackArgs enemyAttack = new AttackArgs(3, 1);
                AbilityCommand enemyAttack = new AttackCommand(enemy, player, 2, 1);
                Messenger<AbilityCommand>.Broadcast(EnemyAIEvent.TRY_START_ENEMY_ABILITY, enemyAttack);
            }
        }

    }
}
