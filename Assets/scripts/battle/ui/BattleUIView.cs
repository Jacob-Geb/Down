using battle.attacks;
using battle.queue;
using characters.player;
using UnityEngine;

namespace battle.ui
{
    class BattleUIView : MonoBehaviour
    {
        [SerializeField]
        public GameObject AbilityBtnObj;

        public void init(PlayerModel playerModel)
        {
            Vector3 pos = new Vector3(-282, -342, 0);
            for (int i = 0; i < playerModel.abilities.Count; i++) {
                addAbilityBtn(playerModel.abilities[i], pos);
                pos.x += 200;
            }
        }

        private void addAbilityBtn(AttackArgs args, Vector3 pos)
        {
            GameObject abilityBtn = GameObject.Instantiate(AbilityBtnObj);
            abilityBtn.transform.SetParent(transform);
            abilityBtn.transform.localScale = Vector3.one;
            abilityBtn.transform.localPosition = pos;
            abilityBtn.GetComponent<AbilityButton>().initButton(args);
        }
    }
}
