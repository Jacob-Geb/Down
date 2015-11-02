using Assets.scripts.characters.player;
using battle.ui;
using characters.enemy;
using characters.player;
using config;
using UnityEngine;
namespace battle
{
    class BattleView : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerViewObj;
        [SerializeField]
        public GameObject enemyViewObj;
        [SerializeField]
        public GameObject battleViewObj;

        [SerializeField]
        public GameObject victoryPopupObj;
        [SerializeField]
        public GameObject defeatPopupObj;

        private PlayerView playerView;
        private EnemyView enemyView;
        private BattleUIView battleUIView;

        public void initBattle(PlayerModel player, EnemyModel enemy)
        {
            instantiateViews();

            //initBattle all Three
            playerView.init(player);
            enemyView.init(enemy);
            battleUIView.init(player, enemy);

            updateView(player, enemy);
        }

        public void victory( )
        {
            GameObject popup = GameObject.Instantiate(victoryPopupObj) as GameObject;
            popup.transform.SetParent(transform);
            popup.transform.localScale = Vector3.one;
            popup.transform.localPosition = Vector3.zero;
            removeUI();
        }

        public void defeat()
        {
            GameObject popup = GameObject.Instantiate(defeatPopupObj) as GameObject;
            popup.transform.SetParent(transform);
            popup.transform.localScale = Vector3.one;
            popup.transform.localPosition = Vector3.zero;
            removeUI();
        }

        private void removeUI()
        {
            if (battleUIView != null)
                Destroy(battleUIView.gameObject);
        }

        private void instantiateViews()
        {
            GameObject playerObj = GameObject.Instantiate(playerViewObj) as GameObject;
            playerObj.transform.SetParent(transform);
            playerObj.transform.localScale = Vector3.one;
            playerObj.transform.localPosition = Vector3.zero;
            playerView = playerObj.GetComponent<PlayerView>();

            GameObject enemyObj = GameObject.Instantiate(enemyViewObj) as GameObject;
            enemyObj.transform.SetParent(transform);
            enemyObj.transform.localScale = Vector3.one;
            enemyObj.transform.localPosition = Vector3.zero;
            enemyView = enemyObj.GetComponent<EnemyView>();

            GameObject battleObj = GameObject.Instantiate(battleViewObj) as GameObject;
            battleObj.transform.SetParent(transform);
            battleObj.transform.localScale = Vector3.one;
            battleObj.transform.localPosition = Vector3.zero;
            battleUIView = battleObj.GetComponent<BattleUIView>();
        }

        public void updateView(PlayerModel player, EnemyModel enemy)
        {
            playerView.updateView(player);
            enemyView.updateView(enemy);
        }
    }
}
