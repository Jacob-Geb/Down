using battle.attacks;
using battle.queue;
using characters.player;
using equipment;
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
            AbilityCommand tmpCommand;

            for (int i = 0; i < playerModel.abilities.Count; i++) {

                //tmpCommand = playerModel.abilities[i].getCommand();
                tmpCommand = playerModel.abilities[i];
                addAbilityBtn(tmpCommand, pos);
                pos.x += 200;
            }
        }

        private void addAbilityBtn(AbilityCommand command, Vector3 pos)
        {
            GameObject abilityBtn = GameObject.Instantiate(AbilityBtnObj);
            abilityBtn.transform.SetParent(transform);
            abilityBtn.transform.localScale = Vector3.one;
            abilityBtn.transform.localPosition = pos;
            abilityBtn.GetComponent<AbilityButton>().initButton(command);
        }
    }
}
