using characters.enemy;
using dungeon.room;
using UnityEngine;
using System.Collections.Generic;
using config;
using System;

namespace dungeon
{
    public class DungeonModel
    {
        private List<RoomModel> rooms = new List<RoomModel>();
        public RoomModel currentRoom = null;

        public int dungeonLevel;

        public DungeonModel()
        {
            resetDungeon();
        }

        public void changeRoom(Dir direction)
        {
            var newPos = currentRoom.pos + Positions.fromDir(direction);
            currentRoom = getRoomFromPos(newPos);
        }

        public RoomModel getRoomFromPos(Vector2 pos)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].pos.x == pos.x && rooms[i].pos.y == pos.y)
                {
                    return rooms[i];
                }
            }
            throw new Exception("no room at that position");
        }

        public void resetDungeon()
        {
            clearDungeon();
            dungeonLevel = 0;
        }

        public void generateDungeon()
        {
            clearDungeon();
            // room factory will be hooked u the the dungeon level, etc
            rooms.Add(new RoomModel(new Vector2(0, 0), true));
            rooms.Add(new RoomModel(new Vector2(1, 0)));
            rooms.Add(new RoomModel(new Vector2(1, 1), false, true));

            rooms[0].roomType = 1;
            rooms[1].roomType = 2;
            rooms[1].enemyType = EnemyType.CELLAR_RAT;

            rooms[2].roomType = 3;
            rooms[2].enemyType = EnemyType.CELLAR_GOBLIN;

            currentRoom = rooms[0];
        }

        private void clearDungeon()
        {
            rooms.Clear();
        }

        public void descend()
        {
            dungeonLevel++;
        }

        public EnemyType getCurrentEnemy()
        {
            if (currentRoom != null)
                return currentRoom.getEnemy();
            throw new Exception("no currentRoom");
        }




    }
}
