using UnityEngine;
using dungeon;
using dungeon.room;
using config;
using game;
using battle;
using Dungeon;
using characters.enemy;

public class 
    DungeonManager : MonoBehaviour {

    public DungeonModel dungeonModel;
    private DungeonView dungeonView;
 
	void Start () {
        dungeonModel = new DungeonModel();
	}

    void OnEnable()
    {
        Messenger<BattleArgs>.AddListener(BattleEvent.ENTER_BATTLE, enterBattle);
        Messenger.AddListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
        Messenger.AddListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        Messenger<Dir>.AddListener(DungeonEvent.TRY_CHANGE_ROOM, tryChangeRoom);
        Messenger.AddListener(DungeonEvent.ENTER_DUNGEON, enterDungeon);
        Messenger.AddListener(DungeonEvent.DESCEND, descend);
    }

    void OnDisable()
    {
        Messenger<BattleArgs>.RemoveListener(BattleEvent.ENTER_BATTLE, enterBattle);
        Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
        Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        Messenger<Dir>.RemoveListener(DungeonEvent.TRY_CHANGE_ROOM, tryChangeRoom);
        Messenger.RemoveListener(DungeonEvent.ENTER_DUNGEON, enterDungeon);
        Messenger.RemoveListener(DungeonEvent.DESCEND, descend);
    }

    private void enterDungeon()
    {
        removeDungeon();

        dungeonModel.descend();// TODO Better name.. is this event still needed with the next line and all..
        generateDungeon();
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
        Vector2 newRoomPos = dungeonModel.currentRoom.pos + Positions.fromDir(dir);
        RoomModel newRoom = dungeonModel.getRoomFromPos(newRoomPos);

        if (newRoom != null && dungeonModel.currentRoom.getEnemy() == EnemyType.NONE)
        {
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
        
        dungeonView = DungeonFactory.makeDungeonView(transform);
        dungeonView.generateDungeon(dungeonModel);

        //GameObject cover = Instantiate(coverPrefab) as GameObject;
        //cover.transform.SetParent(transform);
        //cover.transform.localPosition = Vector3.zero;
        //cover.transform.localScale = Vector3.one;
    }

    private void enterBattle(BattleArgs args)
    {
        if (dungeonView != null)
            dungeonView.gameObject.SetActive(false);
    }

    private void leaveBattleVictorious()
    {
        if (dungeonView != null)
        {
            dungeonModel.leaveBattleVictorious();
            dungeonView.updateCurrentRoom(dungeonModel.currentRoom);
            dungeonView.gameObject.SetActive(true);
        }
    }

    private void leaveBattleDefeated()
    {
        removeDungeon();
    }
}
