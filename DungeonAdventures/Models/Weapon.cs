using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Weapon : Item
    {
        public int Might { get; set; }

        public Weapon(int might, string name, string description, int sell, int buy) 
        {
            Might = might;
            ItemType = ItemType.Equipment;
            Name = name;
            Description = description;
            Buy = buy;
            Sell = sell;
        }
    }
}
