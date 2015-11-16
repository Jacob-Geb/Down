using battle.queue;
using characters;
using characters.enemy;
using characters.player;
using equipment;
using UnityEngine;

namespace battle.ui
{
    class BattleUIView : MonoBehaviour
    {
        [SerializeField]
        public GameObject AbilityBtnObj;

        public void init(PlayerModel player, BaseCharacter enemy)
        {
            Vector3 pos = new Vector3(-282, -342, 0);
            AbilityCommand tmpCommand;

            for (int i = 0; i < player.inventory.Count; i++) 
            {
                if (player.inventory[i].equipped)
                {
                    tmpCommand = player.inventory[i].getCommand(player, enemy);
                    addAbilityBtn(tmpCommand, pos, player.inventory[i].iconPath);
                    pos.x += 200;
                }
            }
        }

        private void addAbilityBtn(AbilityCommand command, Vector3 pos, string iconPath)
        {
            GameObject abilityBtn = GameObject.Instantiate(AbilityBtnObj);
            abilityBtn.transform.SetParent(transform);
            abilityBtn.transform.localScale = Vector3.one;
            abilityBtn.transform.localPosition = pos;
            abilityBtn.GetComponent<AbilityButton>().initButton(command, iconPath);
        }
    }
}
