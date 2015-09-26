using battle.attacks;
using UnityEngine;
namespace characters.ai
{
    public class EnemyAI
    {
        private float nextMove = 0;

        public EnemyAI()
        {
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

                AttackArgs enemyAttack = new AttackArgs(3, 1);
                Messenger<AttackArgs>.Broadcast(EnemyAIEvent.TRY_START_ENEMY_ABILITY, enemyAttack);
            }
        }

    }
}
