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
        private EquippedView equippedView;
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

        void Start()
        {
        }

        public void init(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
            inventoryItems = new List<InventoryItem>();
            equippedView = GetComponentInChildren<EquippedView>();
            equippedView.Init();

            for (int i = 0; i < playerModel.inventory.Count; i++)
            {
                addItem(playerModel.inventory[i]);
            }

            updateView();
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
            equippedView.resetSlots();

            for (int i = 0; i < inventoryItems.Count; i++) {
                inventoryItems[i].updateView();
                if (inventoryItems[i].equipment.equipped)
                {
                    equippedView.updateView(inventoryItems[i].equipment);
                }
            }
        }

        private void onItemTap(Equipment equipment)
        {
            if (equipment.equipped)
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
