using battle.attacks;
using characters.ai;
using System;

namespace battle.queue
{
    public class EnemyQueue : AbilityQueue
    {
        public override void init(Action<AttackArgs> callback, AbilityQueueView queueView, int maxAbilities)
        {
            base.init(callback, queueView, maxAbilities);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Messenger<AttackArgs>.AddListener(EnemyAIEvent.TRY_START_ENEMY_ABILITY, tryAddAbility);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Messenger<AttackArgs>.RemoveListener(EnemyAIEvent.TRY_START_ENEMY_ABILITY, tryAddAbility);
        }
    }
}
