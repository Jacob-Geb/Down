namespace characters
{
    public class BaseCharacter : ICharacter
    {
        private float _hp;
        public float hp
        {
            get{
                return _hp;
            }
            set{
                _hp = value;
            }
        }

        public bool isDead()
        {
            return _hp <= 0;
        }

        public override string ToString()
        {
            return "ICharacter { hp: " + hp + "}";
        }
    }
}
