using equipment;
using UnityEngine;
using UnityEngine.UI;
namespace ui.inventory
{
    class ItemInfo : MonoBehaviour
    {
        [SerializeField]
        private Text infoText;

        public void init(Equipment equipment)
        {
            this.infoText.text = equipment.description;
            gameObject.SetActive(true);
        }

        public void close()
        {
            gameObject.SetActive(false);
        }
    }
}
