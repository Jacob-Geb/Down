using UnityEngine;
using dungeon;
using dungeon.room;

public class DungeonManager : MonoBehaviour {

    DungeonModel duneonModel;
    RoomFactory roomFactory;
    RoomView currentRoom = null;
 
	void Start () {
        duneonModel = new DungeonModel();
        roomFactory = new RoomFactory(transform);
	}
	
	void Update () {
	
	}

    public void OnResetDungeon()
    {
        resetDungeon();
    }

    public void OnDescend()
    {
        makeNewFloor();
    }

    private void resetDungeon()
    {
        if (currentRoom)
            Destroy(currentRoom);

        duneonModel.resetDungeon();
    }

    private void makeNewFloor()
    {
        RoomType roomType = RoomType.CELLAR;// TODO get lvl from DungeonModel
        currentRoom = roomFactory.makeRoom(roomType);
    }

    public void OnLeaveBattle()
    {
        if (currentRoom)
            currentRoom.gameObject.SetActive(true);
    }
}
