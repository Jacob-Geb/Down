using UnityEngine;
using UnityEngine.UI;

namespace characters.enemy
{
    class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private Text hpText;

        public void init(EnemyModel model)
        {
            updateHealth(model.hp);
        }

        public void updateView(EnemyModel model)
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
