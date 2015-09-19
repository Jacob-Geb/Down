
using config;
using UnityEngine;
namespace dungeon.room
{
    class RoomView : MonoBehaviour 
    {

        private GameObject dungeonView;
        private void OnEnable()
        {
            dungeonView = GameObject.Find("DungeonView");
            if (dungeonView != null)
            {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
                dungeonView.GetComponent<MiniKeypressRecognizer>().KeyPress += OnKeyPress;
#elif UNITY_IOS || UNITY_ANDROID
                dungeonView.GetComponent<MiniGestureRecognizer>().Swipe += OnSwipe;
#endif
            }
        }

        private void OnDisable()
        {
            if (dungeonView != null)
            {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
                dungeonView.GetComponent<MiniKeypressRecognizer>().KeyPress -= OnKeyPress;
#elif UNITY_IOS || UNITY_ANDROID
                dungeonView.GetComponent<MiniGestureRecognizer>().Swipe -= OnSwipe;
#endif
            }
        }

        private void OnSwipe(Dir swipeDir)
        {
            SendMessageUpwards(MsgID.TRY_CHANGE_ROOM, swipeDir);
        }

        private void OnKeyPress(Dir keyDir)
        {
            //if (gameObject.active)
                SendMessageUpwards(MsgID.TRY_CHANGE_ROOM, keyDir);
        }

        public void triggerBattle()
        {
            // take enemy from this room
            int roomID = 10;
            SendMessageUpwards(MsgID.TRY_ENTER_BATTLE, roomID);
        }

        public void triggerCollectLoot()
        {

        }

       

        // CLEAR ROOMS SCHOULD BE DONT BY ROOM MANAGER
        //public void OnDescend()
        //{
        //    //setButtonsActive(false);
        //}

        public void OnEnterBattle()
        {
            gameObject.SetActive(false);
        }

        public void triggerGoDescend()
        {
            SendMessageUpwards(MsgID.TRY_DESCEND);
        }

        // movement

        public void tryGoRight()
        {
            SendMessageUpwards(MsgID.TRY_CHANGE_ROOM, Dir.RIGHT);
        }
        public void tryGoDown()
        {
            SendMessageUpwards(MsgID.TRY_CHANGE_ROOM, Dir.DOWN);
        }

        public void tryGoLeft()
        {
            SendMessageUpwards(MsgID.TRY_CHANGE_ROOM, Dir.LEFT);
        }
        public void tryGoUp()
        {
            SendMessageUpwards(MsgID.TRY_CHANGE_ROOM, Dir.UP);
        }
 
    }
}
