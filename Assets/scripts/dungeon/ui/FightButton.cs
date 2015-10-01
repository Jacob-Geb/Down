using battle;
using UnityEngine;
namespace dungeon.ui
{
    class FightButton : MonoBehaviour
    {
        public void OnBtnPress()
        {
            Messenger.Broadcast(BattleEvent.TRY_ENTER_BATTLE);
        }
    }
}
