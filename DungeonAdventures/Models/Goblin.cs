using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Goblin : Enemy
    {
        readonly Weapon weapon = new(5, "Iron Sword", "Goblin sword", 0, 0);
        readonly Armor armor = new(4, "Leather Armor", "some strange leather...", 0, 0);

        public Goblin()
        {
            Name = "Goblin";
            ClassType = DnDClass.Fighter;
            Strength = 6;
            Defense = 6;
            Magic = 2;
            MagicDefense = 2;
            MaxHealth = 25;
            Weapon = weapon;
            Armor = armor;
            Xp = 25;
            Gold = 50;
        }
    }
}
