using battle.attacks;
using System;
using UnityEngine;
namespace battle.queue
{
    public class PlayerQueue : AbilityQueue
    {
        public override void init(Action<AttackArgs> callback, AbilityQueueView queueView, int maxAbilities)
        {
            base.init(callback, queueView, maxAbilities);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Messenger<AttackArgs>.AddListener(BattleUIEvent.ABILITY_BTN_PRESS, tryAddAbility);
            Messenger<int>.AddListener(BattleUIEvent.PLAYER_QUEUE_ITEM_PRESS, remove);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Messenger<AttackArgs>.RemoveListener(BattleUIEvent.ABILITY_BTN_PRESS, tryAddAbility);
            Messenger<int>.RemoveListener(BattleUIEvent.PLAYER_QUEUE_ITEM_PRESS, remove);
        }
    }
}
