using characters.enemy;
using config;
using loot;
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

        public static RoomView makeRoom(IRoom model, Transform cont)
        {
            string resourceID = "dungeon/rooms/RoomCellar";
            GameObject room = GameObject.Instantiate(Resources.Load(resourceID, typeof(GameObject))) as GameObject;
            room.centerScale(cont);

            addWalls(room, model);

            if (model.enemyType != EnemyType.NONE)
                addEnemy(room, model.enemyType);
            else if (model.loot.lootType != LootType.NONE)
                addLoot(room, (Loot)model.loot);

            RoomView roomView = room.GetComponent<RoomView>();
            return roomView;
        }

        private static void addWalls(GameObject room, IRoom model)
        {
            addCeiling(room, model.walls[0]);
            addFloor(room, model.walls[2]);

            if (model.walls[1])
                addRightWall(room);
            if (model.walls[3])
                addLeftWall(room);
        }

        private static void addCeiling(GameObject room, bool value)
        {
            string assetPath = "dungeon/rooms/cellar/ceiling" + (value ? "" : "_false");
            GameObject ceiling = GameObject.Instantiate(Resources.Load(assetPath, typeof(GameObject))) as GameObject;
            ceiling.centerScale(room.transform);
        }

        private static void addFloor(GameObject room, bool value)
        {
            string assetPath = "dungeon/rooms/cellar/floor" + (value ? "" : "_false");
            GameObject floor = GameObject.Instantiate(Resources.Load(assetPath, typeof(GameObject))) as GameObject;
            floor.centerScale(room.transform);
        }

        private static void addRightWall(GameObject room)
        {
            GameObject wall = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/rightWall", typeof(GameObject))) as GameObject;
            wall.centerScale(room.transform);
        }

        private static void addLeftWall(GameObject room)
        {
            GameObject wall = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/leftWall", typeof(GameObject))) as GameObject;
            wall.centerScale(room.transform);
        }

        private static void addEnemy(GameObject room, EnemyType enemyType)
        {
            // str enemyName = room.eney
            GameObject enemy = GameObject.Instantiate(Resources.Load("dungeon/enemies/rat", typeof(GameObject))) as GameObject;
            enemy.centerScale(room.transform);
        }

        private static void addLoot(GameObject room, Loot loot)
        {
            GameObject lootObj = GameObject.Instantiate(Resources.Load("dungeon/loot/genericLoot", typeof(GameObject))) as GameObject;
            lootObj.centerScale(room.transform);
        }
    }
}
