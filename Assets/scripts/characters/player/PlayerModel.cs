using equipment;
using equipment.weapons;
using System.Collections.Generic;
using UnityEngine;
namespace characters.player
{
    public class PlayerModel : BaseCharacter
    {
        public List<Equipment> equipment { get; protected set; }
        private Equipment leftHandWeapon = null;

        public PlayerModel()
        {
            equipment = new List<Equipment>();
        }

        public void resetPlayer()
        {
            hp = 5.0f;
            equipment.Clear();

            Equipment dagger = new Dagger();
            pickUpItem(dagger);
            equip(dagger);
        }

        public void pickUpItem(Equipment item)
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
            }
        }
    }
}
