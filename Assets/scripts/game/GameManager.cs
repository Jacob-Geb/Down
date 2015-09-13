using UnityEngine;
using System.Collections;
using config;
using characters.player;

public class GameManager : MonoBehaviour
{
    PlayerModel playerModel;
    DungeonModel dungeonModel;

	void Start () {
        playerModel = new PlayerModel();
        BroadcastMessage(MsgID.ADD_TOWN);
	}
	
	void Update () {
	}

    public void TryEnterDungeon()
    {
        BroadcastMessage(MsgID.RESET_DUNGEON);
        BroadcastMessage(MsgID.DESCEND);
    }

    public void TryDescend()
    {
        BroadcastMessage(MsgID.DESCEND);
    }

    public void TryEnterBattle(int roomID)
    {

        dungeonModel
        BroadcastMessage(MsgID.ENTER_BATTLE);
    }

    public void TryLeaveBattle()
    {
        BroadcastMessage(MsgID.LEAVE_BATTLE);
    }
}
