
using equipment;
using UnityEngine;
using UnityEngine.UI;
namespace ui.inventory
{
    class InventoryItem : MonoBehaviour
    {
        [SerializeField]
        private Image bgImg;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Color equipedColour;

        [SerializeField]
        private Color defaultColour;

        public Equipment equipment { get; protected set; }

        private bool longHold;
        private float pressTime; 

        public void init(Equipment equipment)
        {
            this.equipment = equipment;
            updateView();
        }

        public void clearView()
        {
            this.equipment = null;
            updateView();
        }

        public void updateView( )
        {
            if (equipment != null)
            {
                icon.sprite = Resources.Load<Sprite>(equipment.iconPath);
                icon.enabled = true;

                if (equipment.equipped)
                    bgImg.color = equipedColour;
                else
                    bgImg.color = defaultColour;
            }
            else
            {
                icon.enabled = false;
                bgImg.color = defaultColour;
            }

        }

        public void onPointerDown()
        {
            Invoke("triggerHold", 0.5f);
            longHold = false;
        }

        public void triggerHold()
        {
            longHold = true;
            Messenger<Equipment>.Broadcast(InventoryEvent.ITEM_HOLD, equipment);
        }

        public void onPointerUp()
        {
            CancelInvoke("triggerHold");
            if (longHold)
                Messenger.Broadcast(InventoryEvent.ITEM_HOLD_RELEASE);
            else
                Messenger<Equipment>.Broadcast(InventoryEvent.ITEM_TAP, equipment);
        }
    }
}
