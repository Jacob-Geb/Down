using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dungeon
{
    class DungeonModel
    {
        public int floorLvl { get; set; }

        public DungeonModel()
        {
            resetDungeon();
        }

        public void resetDungeon()
        {
            floorLvl = 0;
        }

        public void descend()
        {
            floorLvl++;
        }




    }
}
