using config;
using dungeon.room;
using UnityEngine;

namespace dungeon
{
    class DungeonView : MonoBehaviour 
    {
        private RoomView currentRoom;

        public void generateDungeon(DungeonModel model)
        {
            updateCurrentRoom(model.currentRoom);
        }

        public void changeRoom(DungeonModel model, Dir direction)
        {
            Dir oppositeDir = Positions.opposite(direction);
            currentRoom.exitAndDestroy(oppositeDir);

            currentRoom = makeCurrent(model.currentRoom);
            currentRoom.enterAndEnable(direction);
        }

        public void updateCurrentRoom(IRoom model)
        {
            if (currentRoom)
                Destroy(currentRoom.gameObject);
            currentRoom = makeCurrent(model);
            currentRoom.roomeEnabled = true;
        }

        private RoomView makeCurrent(IRoom model)
        {
            return RoomFactory.makeRoom(model, transform);
        }

    }
}
