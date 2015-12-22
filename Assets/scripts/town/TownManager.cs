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
            townView = GameObject.Instantiate(Resources.Load("town/Town", typeof(GameObject))) as GameObject;
            townView.transform.SetParent(transform);
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