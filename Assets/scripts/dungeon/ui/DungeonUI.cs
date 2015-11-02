using battle;
using characters.enemy;
using config;
using dungeon.room;
using Dungeon;
using loot;
using ui.inventory;
using UnityEngine;
using UnityEngine.UI;

namespace dungeon.ui
{
    class DungeonUI : MonoBehaviour
    {
        [SerializeField]
        private Button attackBtn;
        [SerializeField]
        private Button lootBtn;
        [SerializeField]
        private Button inventoryBtn;

        [SerializeField]
        private Text swipeText;
        [SerializeField]
        private Image arrowUP;
        [SerializeField]
        private Image arrowRight;
        [SerializeField]
        private Image arrowDown;
        [SerializeField]
        private Image arrowLeft; 

        public void updateUI(IRoom room)
        {
            attackBtn.gameObject.SetActive(room.enemyType != EnemyType.NONE);
            //inventoryBtn.gameObject.SetActive(room.enemyType == EnemyType.NONE);

            if (room.enemyType == EnemyType.NONE)
            {
                showPossibleArrows(room);

                var roomHasLoot = (room.loot.lootType != LootType.NONE);
                lootBtn.gameObject.SetActive(roomHasLoot);
                swipeText.gameObject.SetActive(!roomHasLoot);
            }
            else
            {
                disableArrows();
                lootBtn.gameObject.SetActive(false);
                swipeText.gameObject.SetActive(false);
            }
        }

        private void showPossibleArrows(IRoom room)
        {
            arrowUP.gameObject.SetActive(room.canGo(Dir.UP));
            arrowRight.gameObject.SetActive(room.canGo(Dir.RIGHT));
            arrowDown.gameObject.SetActive(room.canGo(Dir.DOWN));
            arrowLeft.gameObject.SetActive(room.canGo(Dir.LEFT));
        }

        private void disableArrows()
        {
            arrowUP.gameObject.SetActive(false);
            arrowRight.gameObject.SetActive(false);
            arrowDown.gameObject.SetActive(false);
            arrowLeft.gameObject.SetActive(false);
        }

        public void onFightBtnPress()
        {
            Messenger.Broadcast(DungeonEvent.TRY_ENTER_BATTLE);
        }

        public void onLootBtnPress()
        {
            Messenger.Broadcast(DungeonEvent.TRY_PICKUP_LOOT);
        }

        public void onInventoryPress()
        {
            Messenger.Broadcast(InventoryEvent.OPEN_INVENTORY);
        }
    }
}
