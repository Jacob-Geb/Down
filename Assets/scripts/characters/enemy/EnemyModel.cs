using System.Collections.Generic;
namespace characters.enemy
{
    public class EnemyModel : BaseCharacter
    {
        public EnemyModel(float _hp)
        {
            hp = _hp;
            effects = new List<string>();
        }

    }
}
