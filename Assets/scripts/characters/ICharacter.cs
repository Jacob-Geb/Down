using System.Collections.Generic;
namespace characters
{

    public interface ICharacter
    {
        List<string> effects { get; set; }
        float hp { get; set; }

        bool isPlayer { get; }
        bool isDead();
    }
}
