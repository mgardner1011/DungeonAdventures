using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; protected set; }
        public int Sell { get; set; }
        public int Buy { get; set; }
    }
}
