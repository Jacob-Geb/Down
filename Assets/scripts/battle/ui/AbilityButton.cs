
using equipment;
using UnityEngine;
using UnityEngine.UI;
namespace battle.ui
{
    class AbilityButton : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        private AbilityCommand command;
        public void initButton(AbilityCommand command, string iconPath)
        {
            icon.sprite = Resources.Load<Sprite>(iconPath); 
            this.command = command;
        }

        public void OnBtnPress()
        {
            Messenger<AbilityCommand>.Broadcast(BattleUIEvent.ABILITY_BTN_PRESS, command, MessengerMode.DONT_REQUIRE_LISTENER);
        }
    }
}
