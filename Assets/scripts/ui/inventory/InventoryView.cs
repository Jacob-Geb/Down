using battle;
using characters.enemy;
using characters.player;
using config;
using dungeon.room;
using Dungeon;
using equipment;
using loot;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.inventory
{
    class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private Button backBtn;

        [SerializeField]
        private Transform itemCont;

        [SerializeField]
        private ItemInfo itemInfo;

        private PlayerModel playerModel;
        private List<InventoryItem> inventoryItems;

        void OnEnable()
        {
            Messenger<Equipment>.AddListener(InventoryEvent.ITEM_TAP, onItemTap);
            Messenger<Equipment>.AddListener(InventoryEvent.ITEM_HOLD, onItemHold);
            Messenger.AddListener(InventoryEvent.ITEM_HOLD_RELEASE, onItemRelease);

        }

        void OnDisable()
        {
            Messenger<Equipment>.RemoveListener(InventoryEvent.ITEM_TAP, onItemTap);
            Messenger<Equipment>.RemoveListener(InventoryEvent.ITEM_HOLD, onItemHold);
            Messenger.RemoveListener(InventoryEvent.ITEM_HOLD_RELEASE, onItemRelease);
        }

        public void init(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < playerModel.equipment.Count; i++) {
                addItem(playerModel.equipment[i]);
            }
            itemInfo.close();
        }

        private void addItem(Equipment eqipment)
        {
            var newItem = InventoryItemFactory.makeItem(eqipment);
            newItem.transform.SetParent(itemCont);
            newItem.transform.localScale = Vector3.one;
            inventoryItems.Add(newItem.GetComponent<InventoryItem>());
        }

        public void updateView()
        {
            for (int i = 0; i < inventoryItems.Count; i++) {
                inventoryItems[i].updateView();
            }
        }

        private void onItemTap(Equipment equipment)
        {
            if (equipment.equiped)
            {
                playerModel.dequip(equipment);
            }
            else
            {
                playerModel.equip(equipment);
            }
            updateView();
        }

        private void onItemHold(Equipment equipment)
        {
            itemInfo.init(equipment);
        }

        private void onItemRelease( )
        {
            itemInfo.close();
        }

        public void onBackBtn()
        {
            Messenger.Broadcast(InventoryEvent.CLOSE_INVENTORY);
        }
    }
}
