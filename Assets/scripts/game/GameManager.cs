using UnityEngine;
using config;
using characters.player;
using characters.enemy;
using battle;

public class GameManager : MonoBehaviour
{
    PlayerModel playerModel;
    public DungeonManager dungeonManager;
    public string x;
    // other managers
	void Start () {
        playerModel = new PlayerModel();
        BroadcastMessage(MsgID.ADD_TOWN);
	}
	
	void Update () {
	}

    public void TryEnterDungeon()// dungeon lvl 0
    {
        BroadcastMessage(MsgID.RESET_DUNGEON);
        BroadcastMessage(MsgID.DESCEND);
    }

    public void TryDescend()// dungeon lvl++
    {
        BroadcastMessage(MsgID.DESCEND);
    }

    public void TryChangeRoom(Dir direction)
    {
        // if (navigationManager.canChange(direction))
        BroadcastMessage(MsgID.CHANGE_ROOM, direction);
    }

    public void TryEnterBattle(int roomID)
    {
        // move this elsewhere
        EnemyType enemyType = dungeonManager.dungeonModel.getCurrentEnemy();

        if (enemyType != EnemyType.NONE)
        {
            EnemyModel enemyModel = EnemyFactory.fromType(enemyType);
            BattleArgs args = new BattleArgs(playerModel, enemyModel);
            BroadcastMessage(MsgID.ENTER_BATTLE, args);
        }
    }

    public void TryLeaveBattle()
    {
        BroadcastMessage(MsgID.LEAVE_BATTLE);
    }
}
