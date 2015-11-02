using equipment;
using UnityEngine;

namespace battle.queue
{
    public class AbilityProgress
    {
        public AbilityCommand command { get; protected set; }
        public float progress {
            get{
                return progressInS / command.castTime;
            }
        }

        private float progressInS = 0;

        public AbilityProgress(AbilityCommand command)
        {
            this.command = command;
            progressInS = 0f;
        }

        public void update(float value)
        {
            progressInS += value;
        }

        public bool ready
        {
            get{
                return progressInS >= command.castTime;
            }
        }
    }
}
