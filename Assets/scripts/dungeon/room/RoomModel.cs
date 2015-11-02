using characters.enemy;
using config;
using Dungeon;
using loot;
using System;
using UnityEngine;
namespace dungeon.room
{
    public class RoomModel : IRoom
    {
        public Vector2 pos {get;set;}
        public bool isStart;
        public bool isEnd;

        public int roomType { get; set; }
        public EnemyType enemyType { get; set; }
        public Loot loot { get; set; }
        public bool[] walls {get;set;}

        public RoomModel(Vector2 pos, bool isStart = false, bool isEnd = false, EnemyType enemyType = EnemyType.NONE, Nullable<Loot> loot = null)
        {
            this.pos = pos;
            this.isStart = isStart;
            this.isEnd = isEnd;
            this.enemyType = enemyType;
            if (loot != null)
                this.loot = (Loot)loot;
            else
                this.loot = new Loot(LootType.NONE);

        }

        public void setup()
        {
            Messenger.AddListener(DungeonEvent.TRY_PICKUP_LOOT, tryPickupLoot);
        }

        public void teardown()
        {
            Messenger.RemoveListener(DungeonEvent.TRY_PICKUP_LOOT, tryPickupLoot);
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

        private void tryPickupLoot()
        {
            Debug.Log("tryPickupLoot");
        }
    }
}
