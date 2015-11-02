using characters.player;
using config;
using equipment;
using UnityEngine;
namespace ui.inventory
{
    public class InventoryManager : MonoBehaviour{

        private InventoryView inventory;

	    void Start () {
	    }

        void OnEnable()
        {
            Messenger.AddListener(InventoryEvent.CLOSE_INVENTORY, closeInventory);
        }

        void OnDisable()
        {
            Messenger.RemoveListener(InventoryEvent.CLOSE_INVENTORY, closeInventory);
        }

        public void openInventory(PlayerModel playerModel)
        {
            GameObject inventoryObj = GameObject.Instantiate(Resources.Load("ui/InventroryView", typeof(GameObject))) as GameObject;
            inventoryObj.transform.SetParent(transform);
            inventoryObj.transform.localScale = Vector3.one;
            inventoryObj.transform.localPosition = Positions.CENTER;

            inventory = inventoryObj.GetComponent<InventoryView>();
            inventory.init(playerModel);
        }

        private void closeInventory()
        {
            if (inventory != null) {
                Destroy(inventory.gameObject);
            }
        }

    }
}
