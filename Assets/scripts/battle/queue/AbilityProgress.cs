using battle.attacks;
using UnityEngine;

namespace battle.queue
{
    class AbilityProgress
    {
        public AttackArgs args;
        public float progress {
            get{
                return progressInS / args.castTime;
            }
        }

        private float progressInS = 0;

        public AbilityProgress(AttackArgs args)
        {
            this.args = args;
            progressInS = 0f;
        }

        public void update(float value)
        {
            progressInS += value;
        }

        public bool ready
        {
            get{
                return progressInS >= args.castTime;
            }
        }
    }
}
