using UnityEngine;
using dungeon;
using dungeon.room;
using config;
using game;
using battle;
using Dungeon;
using characters.enemy;
using dungeon.ui;
using util;
using Dungeon.room;
using System;
using ui.inventory;

namespace dungeon
{
    public class DungeonManager : MonoBehaviour {

        public GameObject scaleObject;
        public DungeonModel dungeonModel;

        private DungeonView dungeonView;
        private DungeonUI dungeonUI;
        private GameObject dungeonCover;

        private GameObject dungeonCont;
        private GameObject uiCont;
 
	    void Start () {
            dungeonModel = new DungeonModel();

            dungeonCont = Instantiate(scaleObject) as GameObject;
            dungeonCont.name = "Dungeon Cont";
            dungeonCont.transform.SetParent(transform, false);
            //dungeonCont.centerScale(transform);

            uiCont = Instantiate(scaleObject) as GameObject;
            uiCont.name = "UI Cont";
            uiCont.transform.SetParent(transform, false);
            //uiCont.centerScale(transform);
	    }

        void OnEnable()
        {
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
            Messenger<Dir>.AddListener(DungeonEvent.TRY_CHANGE_ROOM, tryChangeRoom);
            Messenger.AddListener(DungeonEvent.ENTER_DUNGEON, enterDungeon);
            Messenger.AddListener(DungeonEvent.DESCEND, descend);
            Messenger.AddListener(RoomEvent.ENTER_ROOM, enterRoom);
            Messenger.AddListener(InventoryEvent.OPEN_INVENTORY, disableDungeon);
            Messenger.AddListener(InventoryEvent.CLOSE_INVENTORY, enableDungeon);
        }

        void OnDisable()
        {
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
            Messenger<Dir>.RemoveListener(DungeonEvent.TRY_CHANGE_ROOM, tryChangeRoom);
            Messenger.RemoveListener(DungeonEvent.ENTER_DUNGEON, enterDungeon);
            Messenger.RemoveListener(DungeonEvent.DESCEND, descend);
            Messenger.RemoveListener(RoomEvent.ENTER_ROOM, enterRoom);
            Messenger.RemoveListener(InventoryEvent.OPEN_INVENTORY, disableDungeon);
            Messenger.RemoveListener(InventoryEvent.CLOSE_INVENTORY, enableDungeon);
        }

        public void reset() {
            teardown();
        }

        private void enterDungeon()
        {
            removeDungeon();

            dungeonModel.descend();// TODO Better name.. is this event still needed with the next line and all..
            generateDungeon();
        }

        private void enterRoom()
        {
            if (dungeonUI != null && dungeonModel != null && dungeonModel.currentRoom != null)
            {
                dungeonUI.updateUI(dungeonModel.currentRoom);
            }
            else
            {
                throw new Exception("enter room fail");
            }
        }

        private void removeDungeon()
        {
            dungeonModel.resetDungeon();
            if (dungeonView != null)
                Destroy(dungeonView.gameObject);
        }

        public void descend()
        {
            dungeonModel.descend();
        }

        private void tryChangeRoom(Dir dir)
        {
            if (dungeonModel.canGo(dir))
            {
                Vector2 newRoomPos = dungeonModel.currentRoom.pos + Positions.fromDir(dir);
                dungeonModel.getRoomFromPos(newRoomPos);
                changeRoom(dir);
            }
        }

        private void changeRoom(Dir dir)
        {
            dungeonModel.changeRoom(dir);
            dungeonView.changeRoom(dungeonModel, dir);
        }

        private void generateDungeon()
        {
            dungeonModel.generateDungeon();

            dungeonView = DungeonFactory.makeDungeonView(dungeonCont.transform);
            dungeonView.generateDungeon(dungeonModel);

            dungeonCover = Instantiate(Resources.Load("dungeon/ui/cover", typeof(GameObject))) as GameObject;
            dungeonCover.centerScale(uiCont.transform);

            GameObject dungeonUIObj = GameObject.Instantiate(Resources.Load("dungeon/ui/dungeonUI", typeof(GameObject))) as GameObject;
            dungeonUIObj.centerScale(uiCont.transform);
            dungeonUI = dungeonUIObj.GetComponent<DungeonUI>();
            dungeonUI.updateUI(dungeonModel.currentRoom);
        }

        public void onEnterBattle()
        {
            disableDungeon();
        }

        private void leaveBattleVictorious()
        {
            if (dungeonView != null)
            {
                dungeonModel.leaveBattleVictorious();
                dungeonView.updateCurrentRoom(dungeonModel.currentRoom);
                dungeonUI.updateUI(dungeonModel.currentRoom);
                enableDungeon();
            }
        }

        private void enableDungeon()
        {
            if (dungeonView != null)
                dungeonView.gameObject.SetActive(true);
        }

        private void disableDungeon()
        {
            if (dungeonView != null)
                dungeonView.gameObject.SetActive(false);
        }

        private void teardown() {

            // Clean Up and reset Everything
            if (dungeonView != null)
                Destroy(dungeonView.gameObject);

            if (dungeonUI != null)
                Destroy(dungeonUI.gameObject);

            if (dungeonCover != null)
                Destroy(dungeonCover.gameObject);
        }
    }
}
