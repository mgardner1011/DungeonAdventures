using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Armor : Item
    {
        public int Defense { get; set; }

        public Armor(int defense, string name, string description, int buy, int sell)
        {
            Defense = defense;
            ItemType = ItemType.Equipment;
            Name = name;
            Description = description;
            Buy = buy;
            Sell = sell;
        }
    }
}
