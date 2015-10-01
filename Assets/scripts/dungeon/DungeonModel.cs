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

            return null;
            // return nullRoom?
            //throw new Exception("no room at that position");
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
            rooms.Add(new RoomModel(new Vector2(1, -1)));
            rooms.Add(new RoomModel(new Vector2(2, -1)));
            rooms.Add(new RoomModel(new Vector2(0, -1)));
            rooms.Add(new RoomModel(new Vector2(0, -2)));
            rooms.Add(new RoomModel(new Vector2(0, -3)));
            rooms.Add(new RoomModel(new Vector2(-1, -3)));
            rooms.Add(new RoomModel(new Vector2(1, -3), false, true));

            rooms[0].walls = new bool[] { true, false, true, true };
            rooms[1].walls = new bool[] { true, true, false, false };
            rooms[2].walls = new bool[] { false, false, true, false };
            rooms[3].walls = new bool[] { true, true, true, false };
            rooms[4].walls = new bool[] { true, false, false, true };
            rooms[5].walls = new bool[] { false, true, false, true };
            rooms[6].walls = new bool[] { false, false, true, false };
            rooms[7].walls = new bool[] { true, false, true, true };
            rooms[8].walls = new bool[] { true, true, true, false };

            rooms[3].enemyType = EnemyType.CELLAR_RAT;
            rooms[5].enemyType = EnemyType.CELLAR_RAT;
            rooms[7].enemyType = EnemyType.CELLAR_RAT;

            //rooms[1].enemyType = EnemyType.CELLAR_RAT;

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
                return currentRoom.enemyType;
            throw new Exception("no currentRoom");
        }

        public void leaveBattleVictorious()
        {
            if (currentRoom != null)
            {
                currentRoom.killEnemy();
            }
        }

        public bool canGo(Dir dir)
        {
            if (currentRoom.enemyType != EnemyType.NONE)
                return false;

            if (!currentRoom.canGo(dir))
                return false;

            Vector2 newRoomPos = currentRoom.pos + Positions.fromDir(dir);
            RoomModel newRoom = getRoomFromPos(newRoomPos);

            if (newRoom == null)
                   throw new Exception(" should not Behaviour able town get here");

            return true;
        }


    }
}
