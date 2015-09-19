using UnityEngine;
using dungeon;
using dungeon.room;
using config;

public class DungeonManager : MonoBehaviour {

    public DungeonModel dungeonModel;
    private DungeonView dungeonView;
 
	void Start () {
        dungeonModel = new DungeonModel();
	}

    public void OnResetDungeon()
    {
        clearDungeon();
        resetDungeon();
    }

    public void OnChangeRoom(Dir direction)
    {
        dungeonModel.changeRoom(direction);
        dungeonView.changeRoom(dungeonModel, direction);
    }

    public void OnDescend()
    {
        clearDungeon();
        dungeonModel.descend();
        generateDungeon();
    }

    private void resetDungeon()
    {
        dungeonModel.resetDungeon();
    }

    private void generateDungeon()
    {
        dungeonModel.generateDungeon();
        
        dungeonView = DungeonFactory.makeDungeonView(transform);
        dungeonView.generateDungeon(dungeonModel);
    }

    private void clearDungeon()
    {
        if (dungeonView != null) {
            Destroy(dungeonView.gameObject);
        }
    }

    public void OnLeaveBattle()
    {

    }
}
