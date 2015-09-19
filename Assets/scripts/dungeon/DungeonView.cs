using config;
using UnityEngine;
namespace dungeon.room
{
    class DungeonView : MonoBehaviour 
    {
        private RoomView currentRoom;

        public void changeRoom(DungeonModel model, Dir direction)
        {
            makeCurrentRoomView(model.currentRoom);
        }

        public void generateDungeon(DungeonModel model)
        {
            makeCurrentRoomView(model.currentRoom);
        }

        public void makeCurrentRoomView(RoomModel model)
        {
            if (currentRoom)
                Destroy(currentRoom.gameObject);
            currentRoom = RoomFactory.makeRoom(model, transform);
        }
 
    }
}
