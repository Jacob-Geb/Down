
using battle;
using config;
using Dungeon;
using System;
using System.Collections;
using UnityEngine;
namespace dungeon.room
{
    class RoomView : MonoBehaviour
    {
        private const float ROOM_WIDTH = 800;
        private const float ROOM_HEIGHT = 620;

        private GameObject dungeonView;
        public bool roomeEnabled { get; set; }

        private void OnEnable()
        {
            dungeonView = GameObject.Find("DungeonView");
            if (dungeonView != null)
            {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
                dungeonView.GetComponent<MiniKeypressRecognizer>().KeyPress += tryChangeDir;
#elif UNITY_IOS || UNITY_ANDROID
                dungeonView.GetComponent<MiniGestureRecognizer>().Swipe += tryChangeDir;
#endif
            }
        }

        private void OnDisable()
        {
            if (dungeonView != null)
            {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
                dungeonView.GetComponent<MiniKeypressRecognizer>().KeyPress -= tryChangeDir;
#elif UNITY_IOS || UNITY_ANDROID
                dungeonView.GetComponent<MiniGestureRecognizer>().Swipe -= tryChangeDir;
#endif
            }
        }

        private void tryChangeDir(Dir keyDir)
        {
            if (roomeEnabled)
                Messenger<Dir>.Broadcast(DungeonEvent.TRY_CHANGE_ROOM, keyDir);
        }

        public void triggerBattle()
        {
            if (roomeEnabled)
            {
                // take enemy from this room
                int roomID = 10;
                Messenger.Broadcast(BattleEvent.TRY_ENTER_BATTLE);
            }
        }

        public void triggerCollectLoot()
        {

        }

        public void triggerGoDescend()
        {
            if (roomeEnabled)
            {

                //BattleEvent
                // TODO not sure if this should be here..
                // not sure if movement should be hadled here
                Messenger.Broadcast(DungeonEvent.TRY_ENTER_DUNGEON);
            }
        }

        public void exitAndDestroy(Dir direction)
        {
            roomeEnabled = false;
            Vector3 endPos = Positions.fromDir(direction);
            endPos.x *= ROOM_WIDTH;// TODO ROOM_HEIGHT somewhere else.. or dynamic?
            endPos.y *= ROOM_HEIGHT;// and width

            StartCoroutine(moveRoom(endPos, destroyOnArrive));
        }

        public void enterAndEnable(Dir direction)
        {
            Vector3 startOffscreen = Positions.fromDir(direction);
            startOffscreen.x *= ROOM_WIDTH;
            startOffscreen.y *= ROOM_HEIGHT;

            transform.localPosition = startOffscreen;
            StartCoroutine(moveRoom(Vector3.zero, eneableOnArrive));
        }

        private IEnumerator moveRoom(Vector3 endPos, Action onComplete)
        {
            float progress = 0;
            float duration = 0.5f;

            while (progress < duration)
            {
                progress += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, progress / duration);
                yield return null;
            }

            transform.localPosition = endPos;
            if (onComplete != null)
                onComplete();
        }

        private void destroyOnArrive()
        {
            Destroy(gameObject);
        }

        private void eneableOnArrive()
        {
            roomeEnabled = true;
        }

        // movement
        public void tryGoRight()
        {
            tryChangeDir(Dir.RIGHT);
        }
        public void tryGoDown()
        {
            tryChangeDir(Dir.DOWN);
        }

        public void tryGoLeft()
        {
            tryChangeDir(Dir.LEFT);
        }
        public void tryGoUp()
        {
            tryChangeDir(Dir.UP);
        }

    }
}
