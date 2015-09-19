namespace characters
{
    public interface ICharacter
    {
        float hp
        {
            get;
            set;
        }

        bool isDead();
    }
}
