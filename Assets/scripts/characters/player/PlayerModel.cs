using battle.attacks;
using equipment;
using equipment.weapons;
using System.Collections.Generic;
namespace characters.player
{
    public class PlayerModel : BaseCharacter
    {

        IEquipment leftHandWeapon;
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
            leftHandWeapon = new Dagger();
        }

        public List<AbilityCommand> abilities
        {
            get {
                List<AbilityCommand> commands = new List<AbilityCommand>();

                // from left
                commands.Add(leftHandWeapon.getCommand());

                // tmps
                //abilities.Add(new AttackArgs(2, 5));

                return commands;
            }
        }
        
    }
}
