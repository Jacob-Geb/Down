using characters.ai;
using equipment;
using System;

namespace battle.queue
{
    public class EnemyQueue : AbilityQueue
    {
        public override void init(AbilityQueueView queueView, int maxAbilities)
        {
            base.init(queueView, maxAbilities);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Messenger<AbilityCommand>.AddListener(EnemyAIEvent.TRY_START_ENEMY_ABILITY, tryAddAbility);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Messenger<AbilityCommand>.RemoveListener(EnemyAIEvent.TRY_START_ENEMY_ABILITY, tryAddAbility);
        }
    }
}
