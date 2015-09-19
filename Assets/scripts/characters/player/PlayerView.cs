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

        public void init(PlayerModel model)
        {
            updateHealth(model.hp);
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
