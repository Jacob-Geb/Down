using battle.attacks;
using config;
using equipment;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace battle.ui
{
    class AbilityButton : MonoBehaviour
    {
        private AttackArgs attackArgs;

        //public void initButton(AttackArgs attackArgs)
        public void initButton(AbilityCommand command)
        {
            this.attackArgs = attackArgs;
        }

        public void OnBtnPress()
        {
            Messenger<AttackArgs>.Broadcast(BattleUIEvent.ABILITY_BTN_PRESS, attackArgs, MessengerMode.DONT_REQUIRE_LISTENER);
        }
    }
}
