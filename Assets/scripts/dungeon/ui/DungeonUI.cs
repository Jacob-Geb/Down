using characters.enemy;
using config;
using dungeon.room;
using UnityEngine;
using UnityEngine.UI;

namespace dungeon.ui
{
    class DungeonUI : MonoBehaviour
    {
        public Button attackBtn;

        public Text swipeText;
        public Image arrowUP;
        public Image arrowRight;
        public Image arrowDown;
        public Image arrowLeft; 

        public void updateUI(RoomModel room)
        {
            attackBtn.gameObject.SetActive(room.enemyType != EnemyType.NONE);

            swipeText.gameObject.SetActive(room.enemyType == EnemyType.NONE);
            if (room.enemyType == EnemyType.NONE)
            {
                arrowUP.gameObject.SetActive(room.canGo(Dir.UP));
                arrowRight.gameObject.SetActive(room.canGo(Dir.RIGHT));
                arrowDown.gameObject.SetActive(room.canGo(Dir.DOWN));
                arrowLeft.gameObject.SetActive(room.canGo(Dir.LEFT));
            }
            else
            {
                arrowUP.gameObject.SetActive(false);
                arrowRight.gameObject.SetActive(false);
                arrowDown.gameObject.SetActive(false);
                arrowLeft.gameObject.SetActive(false);
            }
        }

    }
}
