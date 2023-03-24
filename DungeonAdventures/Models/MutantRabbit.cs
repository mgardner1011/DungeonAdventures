using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class MutantRabbit: Enemy
    {
        readonly Weapon weapon = new(5, "Claws", "Gross bloody calws... You'll probably get an infection.", 0, 0);
        readonly Armor armor = new(4, "Hide", "Matted dirty fur covers the body.", 0, 0);

        public MutantRabbit()
        {
            Name = "Mutant Rabbit";
            ClassType = DnDClass.Fighter;
            Strength = 10;
            Defense = 6;
            Magic = 2;
            MagicDefense = 4;
            MaxHealth = 32;
            Health = 32;
            Weapon = weapon;
            Armor = armor;
            Xp = 100;
            Gold = 100;
        }
    }
}
