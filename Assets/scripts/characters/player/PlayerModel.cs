using dungeon;
using equipment;
using equipment.weapons;
using loot;
using System.Collections.Generic;
using UnityEngine;
namespace characters.player
{
    public class PlayerModel : BaseCharacter
    {
        public List<Equipment> equipment { get; protected set; }
        private Equipment leftHandWeapon = null;
        private Equipment rightHandEquipment = null;

        public PlayerModel()
        {
            equipment = new List<Equipment>();
            effects = new List<string>();
        }

        public void resetPlayer()
        {
            hp = 5.0f;
            equipment.Clear();

            Equipment dagger = new Dagger();
            pickUpItem(dagger);
            equip(dagger);
        }

        public void tryPickupLoot(Loot loot)
        {
            if (loot.lootType != LootType.NONE)
            {
                Messenger.Broadcast(DungeonEvent.PICKUP_LOOT);
                switch (loot.lootType)
                {
                    case LootType.DAGGER:
                        pickUpItem(new Dagger());//TODO etter way to make/pickup loot 
                        break;
                    case LootType.SWORD:
                        pickUpItem(new Sword());//TODO etter way to make/pickup loot 
                        break;
                    case LootType.SHIELD:
                        pickUpItem(new Shield());//TODO etter way to make/pickup loot 
                        break;
                } 
            }
        }

        private void pickUpItem(Equipment item)
        {
            equipment.Add(item);
        }

        public void dropItem(Equipment item)
        {
            equipment.Remove(item);
        }

        public void sellItem(Equipment item)
        {
            // gold += item.value;
            equipment.Remove(item);
        }

        public void equip(Equipment item)
        {
            if (item.equiped)
                Debug.LogError("itm already equiped!");

            switch (item.slot)
            {
                case Slot.LEFT_HAND:

                    if (leftHandWeapon != null)
                        dequip(leftHandWeapon);

                    leftHandWeapon = item;
                    leftHandWeapon.equiped = true;
                    break;

                case Slot.RIGHT_HAND:

                    if (rightHandEquipment != null)
                        dequip(rightHandEquipment);

                    rightHandEquipment = item;
                    rightHandEquipment.equiped = true;
                    break;

                default:
                    Debug.LogWarning("no valid slot");
                    break;
            }
        }

        public void dequip(Equipment item)
        {
            if (!item.equiped)
                Debug.LogError("cant dequip weapon that is not equiped");

            switch (item.slot)
            {
                case Slot.LEFT_HAND:
                    leftHandWeapon.equiped = false;
                    leftHandWeapon = null;
                    break;

                case Slot.RIGHT_HAND:
                    rightHandEquipment.equiped = false;
                    rightHandEquipment = null;
                    break;
            }
        }

        public override bool isPlayer
        {
            get { return true; }
        }
    }
}
