using battle.attacks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace battle.queue
{
    class AbilityQueueView : MonoBehaviour
    {
        [SerializeField]
        public QueueView view1;
        [SerializeField]
        public QueueView view2;
        [SerializeField]
        private QueueView view3;
        private QueueView[] views;

        void Start()
        {
            views = new QueueView[3];
            views[0] = view1;
            views[1] = view2;
            views[2] = view3;

            for (int i = 0; i < views.Length; i++) {
                views[i].init(i);
            }
        }

       public void updateView(List<AbilityProgress> abilities)
       {
           for (int i = 0; i < views.Length; i++)
           {
               if (i < abilities.Count)
                   views[i].init(abilities[i]);
               else
                   views[i].hide();

           } 
       }
    }
}
