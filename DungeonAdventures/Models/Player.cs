using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Player
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
        public int Xp { get; set; }
        public int Level { get; set; } = 1;

        public int Health
        {
            get { return health; }
            set
            {
                
                if (health + value > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health += value;
                }
                health = value;
            }
        }

        private int maxHealth = 25;

        public int MaxHealth
        {
            get { return maxHealth; }
            private set { maxHealth = value; }
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
                if(mana + value > maxMana)
                {
                    mana = MaxMana;
                }
                else
                {
                    mana += value;
                }
                mana = value;
            }
        }

        private int gold { get; set; } = 50;

        public int Gold
        {
            get { return gold; }
            set
            {
                if (gold <= 0)
                {
                    gold = 0;
                }
                else
                {
                    gold += value;
                }
            }
        }

        public readonly Dictionary<ItemType, List<Item>> inventory = new Dictionary<ItemType, List<Item>>();


        public Player()
        {
            inventory.Add(ItemType.Potion, new List<Item>());
            inventory.Add(ItemType.Equipment, new List<Item>());
            inventory.Add(ItemType.Spell, new List<Item>());
        }

        public void AddItem(Item item)
        {
            inventory[item.ItemType].Add(item);
        }

        public void RemoveItem(Item item)
        {
            inventory[item.ItemType].Remove(item);
        }

        public List<Item> GetAllItemsInInventory(ItemType type)
        {
            return inventory[type];
        }

        public void LevelUp(int level)
        {
            Level = level;
            MaxHealth += 5;
            MaxMana += 5;
            Strength += 2;
            Defense += 2;
            Magic += 2;
            MagicDefense += 2;
            health = MaxHealth;
            mana = MaxMana;
        }

        public override string ToString()
        {
            return $"{ClassType} : {Name}";
        }
    }
}
