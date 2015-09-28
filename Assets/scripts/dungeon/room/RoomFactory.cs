using config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace dungeon.room
{
    class RoomFactory
    {

        public static RoomView makeRoom(RoomModel model, Transform cont)
        {
            string resourceID = "dungeon/rooms/RoomCellar" + model.roomType;
            GameObject room = GameObject.Instantiate(Resources.Load(resourceID, typeof(GameObject))) as GameObject;
            centerScale(room, cont);


            addWalls(room, model);
            //addEnemies();
            //addLLoot();

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
            centerScale(ceiling, room.transform);
        }

        private static void addRightWall(GameObject room)
        {
            GameObject wall = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/rightWall", typeof(GameObject))) as GameObject;
            centerScale(wall, room.transform);
        }

        private static void addFloor(GameObject room)
        {
            GameObject floor = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/floor", typeof(GameObject))) as GameObject;
            centerScale(floor, room.transform);
        }

        private static void addLeftWall(GameObject room)
        {
            GameObject wall = GameObject.Instantiate(Resources.Load("dungeon/rooms/cellar/leftWall", typeof(GameObject))) as GameObject;
            centerScale(wall, room.transform);
        }

        private static void centerScale(GameObject obj, Transform parent)
        {
            obj.transform.SetParent(parent);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
        }
    }
}
