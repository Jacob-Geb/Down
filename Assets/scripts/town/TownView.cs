using UnityEngine.UI;
using System;
using config;
using UnityEngine;
using Dungeon;

namespace town
{
    public class TownView : MonoBehaviour
    {

        public Button dungeonBtn;


        void Start()
        {
            try
            {
                dungeonBtn.onClick.AddListener(onDungeonClick);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        void setButtonsActive(bool value)
        {
            dungeonBtn.interactable = value;
        }

        public void onDungeonClick()
        {
            Messenger.Broadcast(DungeonEvent.ENTER_DUNGEON);
        }
    }
}