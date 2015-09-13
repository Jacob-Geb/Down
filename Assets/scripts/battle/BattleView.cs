using config;
using UnityEngine;
namespace battle
{
    class BattleView : MonoBehaviour
    {
        GameObject playerView;
        GameObject enemyView;
        GameObject battleUI;

        public void initBattle()
        {

        }

        public void winBattle()
        {
            leaveBattle();
        }

        public void loseBattle()
        {
            leaveBattle();
        }

        private void leaveBattle()
        {
            SendMessageUpwards(MsgID.TRY_LEAVE_BATTLE);
        }
    }
}
