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
        

        public static  RoomView makeRoom(RoomModel model, Transform cont)
        {
            string resourceID = "dungeon/rooms/RoomCellar" + model.roomType;
            GameObject room = GameObject.Instantiate(Resources.Load(resourceID, typeof(GameObject))) as GameObject;
            room.transform.SetParent(cont);
            room.transform.localScale = Vector3.one;
            room.transform.localPosition = Vector3.zero;

            RoomView roomView = room.GetComponent<RoomView>();
            return roomView;
        }
    }
}
