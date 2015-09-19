using battle.attacks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace battle.queue
{
    class AbilityQueue : MonoBehaviour
    {
        private int maxAbilities;
        private List<AbilityProgress> abilities = new List<AbilityProgress>();
        private AbilityQueueView queueView;
        public Action<AttackArgs> triggerDelegate;

        public static string TRY_CANCEL_ABILITY = "tryCancelAbility";

        private void Start()
        {
            queueView = GetComponent<AbilityQueueView>();
        }

        public void init(Action<AttackArgs> callback, int maxAbilities = 3)
        {
            this.triggerDelegate = callback;
            this.maxAbilities = maxAbilities;
        }

        void OnEnable()
        {
            Messenger<AttackArgs>.AddListener(BattleView.ABILITY_PRESS, tryAddAbility);
            Messenger<int>.AddListener(TRY_CANCEL_ABILITY, remove);
        }

        void OnDisable()
        {
            Messenger<AttackArgs>.RemoveListener(BattleView.ABILITY_PRESS, tryAddAbility);
            Messenger<int>.RemoveListener(TRY_CANCEL_ABILITY, remove);
        }

        void Update()
        {
            if (abilities.Count >= 1)
            {
                abilities[0].update(Time.deltaTime);
                if (abilities[0].ready)
                {
                    triggerActive();
               } 
            }
        }

        private void tryAddAbility(AttackArgs args)
        {
            if (abilities.Count < maxAbilities)
            {
                abilities.Add(new AbilityProgress(args));
                queueView.updateView(abilities);
            }
        }

        private void remove(int id)
        {
            if (abilities.Count >= id && id >= 0)
            {
                abilities.RemoveAt(id);
                queueView.updateView(abilities);
            }
            else
            {
                Debug.LogWarning("FAIL!!");
            }
        }

        private void triggerActive( )
        {
            if (triggerDelegate != null)
                triggerDelegate(abilities[0].args);

            remove(0);
        }

    }
}
