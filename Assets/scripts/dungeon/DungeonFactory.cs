using dungeon.room;
using UnityEngine;

namespace dungeon
{
    class DungeonFactory
    {
        public static DungeonView makeDungeonView(Transform _cont)
        {
            string resourceID = "dungeon/DungeonView";
            GameObject obj = GameObject.Instantiate(Resources.Load(resourceID, typeof(GameObject))) as GameObject;
            obj.name = "DungeonView";
            obj.transform.SetParent(_cont);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;


            return obj.GetComponent<DungeonView>();
        }
    }
}
