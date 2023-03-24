using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Spell : Item
    {
        public int Might;
        public int ManaCost;
        public Spell(int might, int manaCost, string name, string description, int buy, int sell)
        {
            Might = might;
            ManaCost = manaCost;
            Name = name;
            Description = description;
            ItemType = ItemType.Spell;
            Buy = buy;
            Sell = sell;
        }
    }
}
