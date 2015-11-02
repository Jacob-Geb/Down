using Assets.scripts.characters.player;
using battle;
using battle.queue;
using characters;
using characters.ai;
using characters.enemy;
using characters.player;
using config;
using equipment;
using game;
using UnityEngine;

namespace battle
{ 
    public class BattleManager : MonoBehaviour
    {
        private BattleView battleView;

        private PlayerModel playerModel;
        private EnemyModel enemyModel;

        private EnemyAI enemyAI;

        private AbilityQueue playerQueue;
        private AbilityQueue enemyQueue;

        void Start()
        {
        }

        void OnEnable()
        {
            // TODO SHOULD WE BE LISTENING TO THESE IF WE'RE NOT IN BATTLEMODE??
            // DO WE DELEAT THE MANAGER?
            Messenger<BattleArgs>.AddListener(BattleEvent.ENTER_BATTLE, enterBattle);
            Messenger.AddListener(BattleEvent.ABILITY_EXECUTED, abilityExecuted);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious); // BattleMaager should decide this.. not send it
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        }

        void OnDisable()
        {
            Messenger<BattleArgs>.RemoveListener(BattleEvent.ENTER_BATTLE, enterBattle);
            Messenger.RemoveListener(BattleEvent.ABILITY_EXECUTED, abilityExecuted);
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
            Messenger.RemoveListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        }

        private void Update()
        {
            // TODO ()if battleStarted && !battleEnded
            updateBattle();
        }

        private void updateBattle()
        {
            // move these out somewhere
            if (enemyAI != null)
                enemyAI.updateAI();

            if (playerQueue != null)
                playerQueue.updateQueue();

            if (enemyQueue != null)
                enemyQueue.updateQueue();
        }

        public void enterBattle(BattleArgs args)
        {
            initBattleViews(args);
            initQueues();
        }

        private void initBattleViews(BattleArgs args)
        {
            GameObject battleViewObj = GameObject.Instantiate(Resources.Load("battle/BattleView", typeof(GameObject))) as GameObject;
            battleViewObj.transform.SetParent(transform);
            battleViewObj.transform.localScale = Vector3.one;
            battleViewObj.transform.localPosition = Positions.CENTER;

            battleView = battleViewObj.GetComponent<BattleView>();
            battleView.initBattle(args.playerModel, args.enemyModel);

            playerModel = args.playerModel;
            enemyModel = args.enemyModel;
            enemyAI = new EnemyAI(args.enemyModel, args.playerModel);
        }

        private void initQueues()
        {
            GameObject playerView = GetComponentInChildren<BattleView>().
                    gameObject.GetComponentInChildren<PlayerView>().gameObject;
            AbilityQueueView playerQueueView = playerView.GetComponentInChildren<AbilityQueueView>();

            playerQueue = ScriptableObject.CreateInstance<PlayerQueue>();
            playerQueue.init( playerQueueView, 3);

            GameObject enemyView = GetComponentInChildren<BattleView>().
                    gameObject.GetComponentInChildren<EnemyView>().gameObject;
            AbilityQueueView enemyQueueView = enemyView.GetComponentInChildren<AbilityQueueView>();
            enemyQueue = ScriptableObject.CreateInstance<EnemyQueue>();
            enemyQueue.init( enemyQueueView, 1);
        }

        private void abilityExecuted()
        {
            battleView.updateView(playerModel, enemyModel);
            if (playerModel.isDead() || enemyModel.isDead())
                endBattle();
        }

        private void endBattle()
        {
            Messenger.Broadcast(BattleEvent.END_BATTLE);
            enemyAI = null;

            //TODO make sure this is not called multiple times

            if (playerModel.isDead())
            {
                battleView.defeat();
            }
            else if (enemyModel.isDead())
            {
                battleView.victory();
            }
        }

        private void leaveBattleVictorious()
        {
            leaveBattle();
        }

        private void leaveBattleDefeated()
        {
            leaveBattle();
        }

        private void leaveBattle()
        {
            // Clean Up and reset Everything
            Destroy(battleView.gameObject);
            enemyAI = null;
        }
    }
}
