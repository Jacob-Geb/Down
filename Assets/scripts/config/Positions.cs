using System;
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

        public static Vector2 NONE = Vector2.zero;
        public static Vector2 UP_VEC = new Vector2(0, -1);
        public static Vector2 RIGHT_VEC = new Vector2(1, 0);
        public static Vector2 DOWN_VEC = new Vector2(0, 1);
        public static Vector2 LEFT_VEC = new Vector2(-1, 0);

        public static Vector2 fromDir(Dir direction)
        {
            switch (direction)
            {
                case Dir.NONE:
                    return Vector2.zero;
                case Dir.UP:
                    return UP_VEC;
                case Dir.RIGHT:
                    return RIGHT_VEC;
                case Dir.DOWN:
                    return DOWN_VEC;
                case Dir.LEFT:
                    return LEFT_VEC;
                    
                default:
                    throw new Exception("No valid dir");
            }
        }
        
    }

    public enum Dir
    {
        NONE = 0,
        UP,
        RIGHT,
        DOWN,
        LEFT
    };
}
