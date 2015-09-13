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
        Transform dungeonCont = null;

        public RoomFactory(Transform cont)
        {
            dungeonCont = cont;
        }

        public RoomView makeRoom(RoomType roomType)
        {
            string resourceID = "floors/floor1";// +roomType;
            GameObject room = GameObject.Instantiate(Resources.Load(resourceID, typeof(GameObject))) as GameObject;
            room.transform.SetParent(dungeonCont);
            room.transform.localScale = Vector3.one;

            RoomView roomView = room.GetComponent<RoomView>();
            roomView.setLevel(1);// TODO set Position

            return roomView;
        }
    }
}
