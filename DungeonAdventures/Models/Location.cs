using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Location
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Location(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
