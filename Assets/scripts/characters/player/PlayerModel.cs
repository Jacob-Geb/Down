using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace characters.player
{
    class PlayerModel
    {
        public float hp;

        // left hand
        // right hand
        
        // consumables & useables

        // pasives 

        public PlayerModel()//args
        {
            resetPlayer();
        }

        public void resetPlayer()
        {
            hp = 5.0f;
        }
        
    }
}
