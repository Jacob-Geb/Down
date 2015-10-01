using characters.enemy;
using config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using util;

namespace dungeon.room
{
    class RoomFactory
    {

        public static RoomView makeRoom(RoomModel model, Transform cont)
        {
            string resourceID = "dungeon/rooms/RoomCellar";
            GameObject room = GameObject.Instantiate(Resources.Load(resourceID, typeof(GameObject))) as GameObject;
            room.centerScale(cont);

            addWalls(room, model);

            if (model.enemyType != EnemyType.NONE)
            {
                addEnemy(room);
            }
            else
            {
                // if loot? add
            }

            RoomView roomView = room.GetComponent<RoomView>();
            return roomView;
        }

        private static void addWalls(GameObject room, RoomModel model)
        {
            if (model.walls[0])
                addCeiling(room);
            if (model.walls[1])
                addRightWall(room);
            if (model.walls[2])
                addFloor(room);
            if (model.walls[3])
                addLeftWall(room);
        }

        private static void addCeiling(GameObject room)
        {
            GameObject ceiling = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/ceiling", typeof(GameObject))) as GameObject;
            ceiling.centerScale(room.transform);
        }

        private static void addRightWall(GameObject room)
        {
            GameObject wall = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/rightWall", typeof(GameObject))) as GameObject;
            wall.centerScale(room.transform);
        }

        private static void addFloor(GameObject room)
        {
            GameObject floor = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/floor", typeof(GameObject))) as GameObject;
            floor.centerScale(room.transform);
        }

        private static void addLeftWall(GameObject room)
        {
            GameObject wall = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/leftWall", typeof(GameObject))) as GameObject;
            wall.centerScale(room.transform);
        }

        private static void addEnemy(GameObject room)
        {
            // str enemyName = room.eney
            GameObject enemy = GameObject.Instantiate(Resources.Load("dungeon/enemies/rat", typeof(GameObject))) as GameObject;
            enemy.centerScale(room.transform);
        }

    }
}
