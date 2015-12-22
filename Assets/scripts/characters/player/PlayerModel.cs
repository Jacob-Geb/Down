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
        public List<Equipment> inventory { get; protected set; }
        public List<Equipment> equipped { get; protected set; }

        public PlayerModel()
        {
            inventory = new List<Equipment>();
            equipped = new List<Equipment>();
            equipped.Add(null);//SLot.NONE
            equipped.Add(null);//SLot.LEFT_HAND
            equipped.Add(null);//SLot.RIGHT_HAND

            effects = new List<string>();
        }

        public void reset()
        {
            hp = 5.0f;
            inventory.Clear();

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
            inventory.Add(item);
        }

        public void dropItem(Equipment item)
        {
            inventory.Remove(item);
        }

        public void equip(Equipment item)
        {
            if (item.equipped)
            {
                Debug.LogError("itm already equiped!");
                return;
            }

            int slotID = (int)item.slot;
            if (equipped[slotID] != null)
                dequip(equipped[slotID]);
            

            equipped[slotID] = item;
            equipped[slotID].equipped = true;
        }

        public void dequip(Equipment item)
        {
            if (!item.equipped)
            {
                Debug.LogError("cant dequip weapon that is not equiped");
                return;
            }

            int slotID = (int)item.slot;
            equipped[slotID].equipped = false;
            equipped[slotID] = null;
        }

        public override bool isPlayer
        {
            get { return true; }
        }
    }
}
