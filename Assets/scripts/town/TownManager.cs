using config;
using dungeon;
using game;
using UnityEngine;

namespace town
{
    public class TownManager : MonoBehaviour
    {

        private GameObject townView;

        void OnEnable()
        {
            Messenger.AddListener(GameEvent.RESET_GAME, addTownView);
            Messenger.AddListener(DungeonEvent.ENTER_DUNGEON, removeTownView);
        }

        void OnDisable()
        {
            Messenger.RemoveListener(GameEvent.RESET_GAME, addTownView);
            Messenger.RemoveListener(DungeonEvent.ENTER_DUNGEON, removeTownView);
        }

        public void addTownView()
        {
            townView = GameObject.Instantiate(Resources.Load("floors/Town", typeof(GameObject))) as GameObject;
            townView.transform.SetParent(transform);
            townView.transform.localScale = Vector3.one;
            townView.transform.localPosition = Positions.CENTER;
        }

        public void removeTownView()
        {
            if (townView != null)
            {
                Destroy(townView.gameObject);
            }
        }
    }
}