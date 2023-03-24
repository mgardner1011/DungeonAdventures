using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Enemy
    {
        public string Name { get; set; }
        public DnDClass ClassType { get; set; }
        public int Strength { get; set; } = 5;
        public int Defense { get; set; } = 5;
        public int Magic { get; set; } = 5;
        public int MagicDefense { get; set; } = 5;
        private int health = 25;
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public int MaxHealth { get; set; }
        public int Xp { get; set; }
        public int Gold { get; set; }

        public int Health
        {
            get { return health; }
            set
            {
                if (health + value > MaxHealth)
                {
                    health = MaxHealth;
                }
                else
                {
                    health += value;
                }
                health = value;
            }
        }

        private int maxMana = 20;

        public int MaxMana
        {
            get { return maxMana; }
            private set { maxMana = value; }
        }

        private int mana = 20;

        public int Mana
        {
            get { return mana; }
            set
            {
                if (mana + value > maxMana)
                {
                    mana = MaxMana;
                }
                else
                {
                    mana += value;
                }
            }
        }
    }
}
