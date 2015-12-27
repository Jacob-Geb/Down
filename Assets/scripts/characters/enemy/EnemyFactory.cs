using System;
namespace characters.enemy
{
    class EnemyFactory
    {

        public static EnemyModel fromType(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.CELLAR_RAT:
                    return new EnemyModel(5);
                case EnemyType.CELLAR_GOBLIN:
                    return new EnemyModel(10);

                default:
                    throw new Exception("no valid enemy");
            }
        }

        public EnemyView makeEnemy()
        {
            return null;
        }
    }
}
