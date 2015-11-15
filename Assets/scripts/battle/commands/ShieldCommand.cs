using battle;
using characters;
using characters.player;
namespace equipment
{
    class  ShieldCommand : AbilityCommand
    {
        private PlayerModel actor;
        private float blockAmount;

        public ShieldCommand(BaseCharacter actor, float castTime, float blockAmount)
        {
            this.actor = (PlayerModel)actor;
            this.castTime = castTime;
            this.blockAmount = blockAmount;
            this.iconPath = "ui/icons/shieldSymbol";
        }

        override public void execute()
        {
            if (!actor.effects.Contains("shield"))
                actor.effects.Add("shield");
            Messenger<string>.Broadcast(BattleUIEvent.ADD_PLAYER_EFFECT, "shield");
            Messenger.Broadcast(BattleEvent.ABILITY_EXECUTED);
        }
    }
}
