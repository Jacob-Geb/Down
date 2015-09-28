using characters.enemy;
using UnityEngine;
namespace dungeon.room
{
    public class RoomModel
    {
        public Vector2 pos;
        public bool isStart;
        public bool isEnd;

        public int roomType;
        public EnemyType enemyType;
        public bool[] walls;

        public RoomModel(Vector2 pos, bool isStart = false, bool isEnd = false, EnemyType enemyType = EnemyType.NONE)
        {
            this.pos = pos;
            this.isStart = isStart;
            this.isEnd = isEnd;
            this.enemyType = enemyType;
        }

        public EnemyType getEnemy(){
            return enemyType;
        }

        public void killEnemy()
        {
            enemyType = EnemyType.NONE;
        }

    }
}
