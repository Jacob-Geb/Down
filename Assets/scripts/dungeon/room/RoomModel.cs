using characters.enemy;
using config;
using UnityEngine;
namespace dungeon.room
{
    public class RoomModel
    {
        public Vector2 pos;
        public bool isStart;
        public bool isEnd;

        public int roomType;
        public EnemyType enemyType {get; set;}
        public bool[] walls;

        public RoomModel(Vector2 pos, bool isStart = false, bool isEnd = false, EnemyType enemyType = EnemyType.NONE)
        {
            this.pos = pos;
            this.isStart = isStart;
            this.isEnd = isEnd;
            this.enemyType = enemyType;
        }

        public void killEnemy()
        {
            enemyType = EnemyType.NONE;
        }

        public bool canGo(Dir dir)
        {
            if (dir == Dir.UP && walls[0])
                return false;
            if (dir == Dir.RIGHT && walls[1])
                return false;
            if (dir == Dir.DOWN && walls[2])
                return false;
            if (dir == Dir.LEFT && walls[3])
                return false;

            return true;
        }

    }
}
