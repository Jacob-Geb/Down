using UnityEngine;
using config;
using characters.player;
using characters.enemy;
using battle;
using town;
using ui.inventory;
using loot;
using dungeon;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        private PlayerModel playerModel;
        private DungeonManager dungeonManager;
        private InventoryManager inventoryManager;
        private BattleManager battleManager;

        private void Start()
        {
            playerModel = new PlayerModel();
            dungeonManager = GetComponentInChildren<DungeonManager>();
            inventoryManager = GetComponentInChildren<InventoryManager>();
            battleManager = GetComponentInChildren<BattleManager>();
            resetGame();
        }

        private void OnEnable()
        {
            Messenger.AddListener(DungeonEvent.TRY_ENTER_BATTLE, tryEnterBattle);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
            Messenger.AddListener(InventoryEvent.OPEN_INVENTORY, openInventory);
            Messenger.AddListener(DungeonEvent.TRY_PICKUP_LOOT, tryPickupLoot);

        }

        private void OnDisable()
        {
            Messenger.RemoveListener(DungeonEvent.TRY_ENTER_BATTLE, tryEnterBattle);
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
            Messenger.RemoveListener(InventoryEvent.OPEN_INVENTORY, openInventory);
            Messenger.RemoveListener(DungeonEvent.TRY_PICKUP_LOOT, tryPickupLoot);
        }

        private void resetGame()
        {
            playerModel.reset();
            battleManager.reset();
            dungeonManager.reset();
            Messenger.Broadcast(GameEvent.RESET_GAME);
            // TODO check all views !!
        }

        private void openInventory()
        {
            inventoryManager.openInventory(playerModel);
        }

        private void tryEnterBattle()
        {
            // TODO, maybe move this elsewhere
            EnemyType enemyType = dungeonManager.dungeonModel.getCurrentEnemy();

            if (enemyType != EnemyType.NONE)
            {
                battleManager.enterBattle(playerModel, enemyType);
                dungeonManager.onEnterBattle();
            }
        }

        private void tryPickupLoot()
        {
            Loot loot = dungeonManager.dungeonModel.currentRoom.loot;
            playerModel.tryPickupLoot(loot);
        }

        private void leaveBattleDefeated()
        {
            resetGame();
        }
    }
}
