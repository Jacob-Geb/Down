using UnityEngine;
using config;
using characters.player;
using characters.enemy;
using battle;
using town;
using Dungeon;
using ui.inventory;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        private PlayerModel playerModel;
        private DungeonManager dungeonManager;
        private InventoryManager inventoryManager;

        private void Start()
        {
            playerModel = new PlayerModel();
            dungeonManager = GetComponentInChildren<DungeonManager>();
            inventoryManager = GetComponentInChildren<InventoryManager>();
            resetGame();
        }

        private void OnEnable()
        {
            Messenger.AddListener(DungeonEvent.TRY_ENTER_BATTLE, tryEnterBattle);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
            Messenger.AddListener(InventoryEvent.OPEN_INVENTORY, openInventory);
        }

        private void OnDisable()
        {
            Messenger.RemoveListener(DungeonEvent.TRY_ENTER_BATTLE, tryEnterBattle);
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
            Messenger.RemoveListener(InventoryEvent.OPEN_INVENTORY, openInventory);
        }

        private void resetGame()
        {
            playerModel.resetPlayer();
            Messenger.Broadcast(GameEvent.RESET_GAME);
        }

        public void openInventory()
        {
            inventoryManager.openInventory(playerModel);
        }

        public void tryEnterBattle()
        {
            // move this elsewhere
            EnemyType enemyType = dungeonManager.dungeonModel.getCurrentEnemy();

            if (enemyType != EnemyType.NONE)
            {
                EnemyModel enemyModel = EnemyFactory.fromType(enemyType);
                BattleArgs args = new BattleArgs(playerModel, enemyModel);
                Messenger<BattleArgs>.Broadcast(BattleEvent.ENTER_BATTLE, args);
            }
        }

        public void leaveBattleDefeated()
        {
            resetGame();
        }
    }
}
