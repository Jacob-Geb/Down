using battle;
using characters.player;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.characters.player
{
    class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private Text hpText;

        [SerializeField]
        private Image shield;

        void OnEnable()
        {
            Messenger<string>.AddListener(BattleUIEvent.ADD_PLAYER_EFFECT, addEffect);
            Messenger<string>.AddListener(BattleUIEvent.REMOVE_PLAYER_EFFECT, removeEffect);
        }

        void OnDisable()
        {
            Messenger<string>.RemoveListener(BattleUIEvent.ADD_PLAYER_EFFECT, addEffect);
            Messenger<string>.RemoveListener(BattleUIEvent.REMOVE_PLAYER_EFFECT, removeEffect);
        }

        public void init(PlayerModel model)
        {
            updateHealth(model.hp);
            shield.enabled = false;
        }

        private void addEffect(string effect)
        {
            shield.enabled = true;
        }

        private void removeEffect(string effect)
        {
            shield.enabled = false;
        }

        public void updateView(PlayerModel model)
        {
            updateHealth(model.hp);
        }

        private void updateHealth(float hp)
        {
            if (hpText)
                hpText.text = hp.ToString("F2");
        }

    }
}
