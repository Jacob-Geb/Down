using characters.enemy;
using characters.player;
using UnityEngine;

namespace loot
{
    class LootGenerator
    {
        public Loot generate(PlayerModel player, EnemyModel enemy)// level? special room?
        {
            float rnd = Random.Range(0.0f, 1.0f);

            if (rnd < 0.1)
            {
                return new Loot(LootType.DAGGER, 1);
            } 

            return new Loot(LootType.NONE);
        }
    }
}
