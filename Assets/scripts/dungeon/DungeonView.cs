using config;
using UnityEngine;
namespace dungeon.room
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

        public void updateCurrentRoom(RoomModel model)
        {
            if (currentRoom)
                Destroy(currentRoom.gameObject);
            currentRoom = makeCurrent(model);
            currentRoom.roomeEnabled = true;
        }

        private RoomView makeCurrent(RoomModel model)
        {
            return RoomFactory.makeRoom(model, transform);
        }

    }
}
