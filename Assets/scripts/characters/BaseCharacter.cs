using System.Collections.Generic;
namespace characters
{
    public class BaseCharacter : ICharacter
    {
        public List<string> effects { get; set; }

        private float _hp;
        public float hp
        {
            get{
                return _hp;
            }
            set{
                _hp = value;
                if (_hp <= 0){
                    // TODO dispatch signal.. here or in player/enemy
                }
            }
        }

        public bool isDead()
        {
            return _hp <= 0;
        }

        public virtual bool isPlayer
        {
            get {return false;}
        }

        public override string ToString()
        {
            return "ICharacter { hp: " + hp + "}";
        }
    }
}
