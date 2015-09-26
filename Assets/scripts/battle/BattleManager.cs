﻿using Assets.scripts.characters.player;
using battle;
using battle.attacks;
using battle.queue;
using characters;
using characters.ai;
using characters.enemy;
using characters.player;
using config;
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
            Messenger<AttackArgs>.AddListener(BattleEvent.TRIGGER_PLAYER_ABILITY, triggerPlayerAbility);
            Messenger<BattleArgs>.AddListener(BattleEvent.ENTER_BATTLE, enterBattle);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_VICTORIOUS, leaveBattleVictorious);
            Messenger.AddListener(BattleEvent.LEAVE_BATTLE_DEFEATED, leaveBattleDefeated);
        }

        void OnDisable()
        {
            Messenger<AttackArgs>.RemoveListener(BattleEvent.TRIGGER_PLAYER_ABILITY, triggerPlayerAbility);
            Messenger<BattleArgs>.RemoveListener(BattleEvent.ENTER_BATTLE, enterBattle);
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
            enemyAI = new EnemyAI();//TODO: args.enemyModel or type or whatever
        }

        private void initQueues()
        {
            GameObject playerView = GetComponentInChildren<BattleView>().
                    gameObject.GetComponentInChildren<PlayerView>().gameObject;
            AbilityQueueView playerQueueView = playerView.GetComponentInChildren<AbilityQueueView>();

            playerQueue = ScriptableObject.CreateInstance<PlayerQueue>();
            playerQueue.init(triggerPlayerAbility, playerQueueView, 3);

            GameObject enemyView = GetComponentInChildren<BattleView>().
                    gameObject.GetComponentInChildren<EnemyView>().gameObject;
            AbilityQueueView enemyQueueView = enemyView.GetComponentInChildren<AbilityQueueView>();
            enemyQueue = ScriptableObject.CreateInstance<EnemyQueue>();
            enemyQueue.init(triggerEnemyAbility, enemyQueueView, 1);
        }

        private void triggerPlayerAbility(AttackArgs attackArgs)
        {
            triggerAbility(playerModel, enemyModel, attackArgs);
        }

        private void triggerEnemyAbility(AttackArgs attackArgs)
        {
            triggerAbility(enemyModel, playerModel, attackArgs);
        }

        private void triggerAbility(ICharacter attacker, ICharacter defender, AttackArgs attackArgs)
        {
            // TODO Check that we're in Battle state!
            // or restirt this to an object that is around during a battle state

            BattleCalculator.resolveAttack(attacker, defender, attackArgs);
            battleView.updateView(playerModel, enemyModel);

            if (playerModel.isDead() || enemyModel.isDead())
                endBattle();
            
        }

        private void endBattle()
        {
            Messenger.Broadcast(BattleEvent.END_BATTLE);
            enemyAI = null;

            //TODO make sure this is not called multiple times

            if (playerModel.isDead()) {
                battleView.defeat();
            }
            else if (enemyModel.isDead()) {
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
