using config;
using equipment;
using UnityEngine;
namespace ui.inventory
{
    public class InventoryItemFactory
    {
        public static GameObject makeItem(Equipment equipment)
        {
            GameObject item = GameObject.Instantiate(Resources.Load("ui/InventoryItem", typeof(GameObject))) as GameObject;
            item.GetComponent<InventoryItem>().init(equipment);
            item.transform.localPosition = Positions.CENTER;
            return item;
        }
    }
}
