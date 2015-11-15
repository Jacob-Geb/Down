namespace equipment
{
    public abstract class  AbilityCommand
    {
        public float castTime { get; protected set; }
        public string iconPath { get; protected set; } 
        abstract public void execute();
    }
}
