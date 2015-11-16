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
    class EquippedView: MonoBehaviour
    {
        [SerializeField]
        private InventoryItem equipedLeft;
        [SerializeField]
        private InventoryItem equipedRight;

        private List<InventoryItem> slots;

        public void Init( )
        {
            slots = new List<InventoryItem>();
            slots.Add(null);
            slots.Add(equipedLeft);
            slots.Add(equipedRight);

            resetSlots();
        }

        public void updateView(Equipment equipment)
        {
            slots[(int)equipment.slot].init(equipment);
        }

        public void resetSlots()
        {
            slots[(int)Slot.LEFT_HAND].clearView();
            slots[(int)Slot.RIGHT_HAND].clearView();
        }

    }
}
