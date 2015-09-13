using UnityEngine;
namespace config
{
    class Positions
    {
        private const int LEVEL_HEIGHT = 1333;

        public static Vector3 CENTER = Vector3.zero;

        public static Vector3 fromLevel (int lvl){
            return new Vector3(0, LEVEL_HEIGHT * -lvl, 0);
        }
        
    }
}
