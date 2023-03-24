using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal enum ItemType
    {
        /// <summary>
        /// A Consumable Item to affect the player
        /// </summary>
        Potion,
        /// <summary>
        /// Weapons and armor 
        /// </summary>
        Equipment,
        /// <summary>
        /// Wizard things
        /// </summary>
        Spell
    }
}
