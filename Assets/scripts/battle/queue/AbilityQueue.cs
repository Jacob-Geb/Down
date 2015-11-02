using equipment;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace battle.queue
{
    [Serializable]
    public abstract class AbilityQueue : ScriptableObject
    {
        protected int maxAbilities;
        protected bool queueActive;

        protected List<AbilityProgress> abilities = new List<AbilityProgress>();
        protected AbilityQueueView queueView;

        protected virtual void OnEnable()
        {
            Messenger.AddListener(BattleEvent.END_BATTLE, onBattleEnd);
        }

        protected virtual void OnDisable()
        {
            Messenger.AddListener(BattleEvent.END_BATTLE, onBattleEnd);
        }

        public virtual void init(AbilityQueueView queueView, int maxAbilities)
        {
            this.queueView = queueView;
            this.maxAbilities = maxAbilities;
            queueActive = true;
        }

        protected virtual void onBattleEnd()
        {
            queueActive = false;
            for (int i = 0; i < abilities.Count; i++) {
                remove(0);
            }
        }

        public void updateQueue()
        {
            if (abilities.Count >= 1)
            {
                abilities[0].update(Time.deltaTime);
                if (abilities[0].ready)
                {
                    triggerActiveAbility();
                }
            }
        }

        protected void tryAddAbility(AbilityCommand command)
        {
            if (queueActive && abilities.Count < maxAbilities)
            {
                abilities.Add(new AbilityProgress(command));
                queueView.updateView(abilities);
            }
        }

        protected void remove(int id)
        {
            if (abilities.Count > 0)
            {
                if (abilities.Count >= id && id >= 0)
                {
                    abilities.RemoveAt(id);
                    queueView.updateView(abilities);
                }
            }
        }

        protected void triggerActiveAbility()
        {
            abilities[0].command.execute();
            remove(0);
        }

    }
}
