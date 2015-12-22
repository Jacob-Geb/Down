
using characters.enemy;
using config;
using loot;
using UnityEngine;
namespace dungeon.room
{
    public interface IRoom
    {
        Vector2 pos { get; set; }

        RoomType roomType { get; set; }
        EnemyType enemyType { get; set; }
        Loot loot { get; set; }
        bool[] walls { get; set; }

        void setup();
        void teardown();
        void killEnemy();
        bool canGo(Dir dir);
    }
}
