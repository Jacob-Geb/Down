
using common;
using config;
using UnityEngine;
namespace dungeon.room
{
    class RoomView : LevelView 
    {

        public void triggerBattle()
        {
            // take enemy from this room
            int roomID = 10;
            SendMessageUpwards(MsgID.TRY_ENTER_BATTLE, roomID);
        }

        public void triggerCollectLoot()
        {

        }

        public void triggerGoDown()
        {
            SendMessageUpwards(MsgID.TRY_DESCEND);
        }

        public void OnDescend()
        {
            //setButtonsActive(false);
            moveUp();
        }

        public void OnEnterBattle()
        {
            this.gameObject.SetActive(false);
        }
 
    }
}
