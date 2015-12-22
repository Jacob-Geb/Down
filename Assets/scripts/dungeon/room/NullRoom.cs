
using config;
using UnityEngine;
namespace dungeon.room
{
    public class NullRoom : IRoom
    {

        private static IRoom _instance;
        public static IRoom instance
        {
            get{
                if (_instance == null)
                    _instance = new NullRoom();
                return _instance;
            }
        }

        private NullRoom()
        {
        }

        public void setup()
        {
        }

        public void teardown()
        {
        }

        public void killEnemy()
        {
            Debug.LogWarning("'killEnemy' called on nullroom");
        }

        public bool canGo(Dir dir)
        {
            Debug.LogWarning("'canGo' called on nullroom");
            return false;
        }

        public Vector2 pos
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public RoomType roomType
        {
            get
            {
                return RoomType.NONE;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public characters.enemy.EnemyType enemyType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public loot.Loot loot
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public bool[] walls
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
