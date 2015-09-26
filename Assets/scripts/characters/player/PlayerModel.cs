using battle.attacks;
using System.Collections.Generic;
namespace characters.player
{
    public class PlayerModel : BaseCharacter
    {

        // left hand
        // right hand
        // body
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

        public List<AttackArgs> abilities
        {
            get { 
                List<AttackArgs> abilities = new List<AttackArgs>();

                // from left
                // reom right hand
                // from class..

                // tmps
                abilities.Add(new AttackArgs(2, 5));

                return abilities;
            }
        }
        
    }
}
