using game;
using UnityEngine;
using UnityEngine.UI;

namespace battle.ui
{
    class VictoryPopup : MonoBehaviour
    {
        private Button contButton;

        void Start()
        {
            contButton = GetComponentInChildren<Button>();
            contButton.onClick.AddListener(onCont);
        }

        private void onCont()
        {
            contButton.onClick.RemoveListener(onCont);
            Messenger.Broadcast(BattleEvent.LEAVE_BATTLE_VICTORIOUS);
        }
    }
}
