using UnityEngine;
using config;
using characters.player;
using characters.enemy;
using battle;
using town;
using Dungeon;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        private PlayerModel playerModel;
        private DungeonManager dungeonManager;
        private BattleManager battleManager;

        private void Start()
        {
            playerModel = new PlayerModel();
            dungeonManager = GetComponentInChildren<DungeonManager>();
            battleManager = GetComponentInChildren<BattleManager>();
            
            resetGame();
        }

        private void OnEnable()
        {
            Messenger.AddListener(DungeonEvent.TRY_ENTER_DUNGEON, tryEnterDungeon);
            Messenger.AddListener(DungeonEvent.TRY_DESCEND, tryDescend);
            Messenger.AddListener(BattleEvent.TRY_ENTER_BATTLE, tryEnterBattle);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        }

        private void OnDisable()
        {
            Messenger.RemoveListener(DungeonEvent.TRY_ENTER_DUNGEON, tryEnterDungeon);
            Messenger.RemoveListener(DungeonEvent.TRY_DESCEND, tryDescend);
            Messenger.RemoveListener(BattleEvent.TRY_ENTER_BATTLE, tryEnterBattle);
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        }

        private void resetGame()
        {
            playerModel.resetPlayer();
            Messenger.Broadcast(GameEvent.RESET_GAME);
        }

        public void tryEnterDungeon()// dungeon lvl 0
        {
            Messenger.Broadcast(DungeonEvent.ENTER_DUNGEON);
        }

        public void tryDescend()// dungeon lvl++
        {
            Messenger.Broadcast(DungeonEvent.DESCEND);
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

        public void leaveBattleVictorious()
        {
            //...
        }

        public void leaveBattleDefeated()
        {
            resetGame();
        }
    }
}
