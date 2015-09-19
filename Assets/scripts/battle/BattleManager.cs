using Assets.scripts.characters.player;
using battle;
using battle.attacks;
using battle.queue;
using characters;
using characters.enemy;
using characters.player;
using config;
using UnityEngine;

namespace battle
{ 
    public class BattleManager : MonoBehaviour
    {
        private BattleView battleView;

        private PlayerModel playerModel;
        private EnemyModel enemyModel;

        private AbilityQueue playerQueue;
        private AbilityQueue enemyQueue;

        public static string TRIGGER_PLAYER_ABILITY = "triggerPlayerAbility";

        void Start()
        {
        }

        void OnEnable()
        {
            Messenger<AttackArgs>.AddListener(TRIGGER_PLAYER_ABILITY, triggerPlayerAbility);
        }

        void OnDisable()
        {
            Messenger<AttackArgs>.RemoveListener(TRIGGER_PLAYER_ABILITY, triggerPlayerAbility);
        }


        public void OnEnterBattle(BattleArgs args)
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
        }

        private void initQueues()
        {
            GameObject playerView = GetComponentInChildren<BattleView>().
                    gameObject.GetComponentInChildren<PlayerView>().gameObject;

            AbilityQueue playerQueue = playerView.GetComponentInChildren<AbilityQueue>();
            playerQueue.init(triggerPlayerAbility);

            // same for enemy
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
            BattleCalculator.resolveAttack(attacker, defender, attackArgs);
            battleView.updateView(playerModel, enemyModel);

            if (playerModel.isDead() && enemyModel.isDead())
            {
                drawBattle();
            }
            else if (enemyModel.isDead())
            {
                winBattle();
            }
            else if (playerModel.isDead())
            {
                loseBattle();
            } 
        }

        private void winBattle()
        {
            Debug.Log("Win Battle");
            //SendMessageUpwards(MsgID.BATTLE_END_VICTORY);
        }

        private void loseBattle()
        {
            Debug.Log("Lose Battle");
            //SendMessageUpwards(MsgID.BATTLE_END_DEFEAT);
        }

        private void drawBattle()
        {
            Debug.Log("Draw");
            //SendMessageUpwards(MsgID.BATTLE_END_DRAW);
        }

        public void OnLeaveBattle()
        {
            if (battleView)
                Destroy(battleView.gameObject);
        }

    }
}
