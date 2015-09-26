using battle.attacks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace battle.queue
{
    public class AbilityQueueView : MonoBehaviour
    {
        [SerializeField]
        private QueueView view1;
        [SerializeField]
        private QueueView view2;
        [SerializeField]
        private QueueView view3;
        private QueueView[] views = new QueueView[3];

        void Start()
        {
            views[0] = view1;
            views[1] = view2;
            views[2] = view3;

            for (int i = 0; i < views.Length; i++) {
                if ( views[i] != null)
                    views[i].init(i);
            }

        }

        public void updateView(List<AbilityProgress> abilities)
        {
            for (int i = 0; i < views.Length; i++)
            {
                if (views[i] != null)
                {
                    if (i < abilities.Count)
                        views[i].init(abilities[i]);
                    else
                        views[i].hide();
                }
            } 
        }
    }
}
