using characters.enemy;
using characters.player;
namespace battle
{
    public struct BattleArgs
    {
        public PlayerModel playerModel;
        public EnemyModel enemyModel;

        public BattleArgs(PlayerModel playerModel, EnemyModel enemyModel) 
        {
            this.playerModel = playerModel;
            this.enemyModel = enemyModel;
        }
    }
}
