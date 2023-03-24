using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Merchant
    {
        private int gold { get; set; } = 500;

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

        public Weapon ironSword = new(
                5,
                "Iron Sword",
                "An affordable sword that is easy to wield.",
                25,
                50
                );
        public Armor leatherArmor = new(
            4,
            "Leather Armor",
            "Affordable armor, that is easy to wear.",
            25,
            50
            );
        public Weapon ironStaff = new(
            3,
            "Quarterstaff",
            "A long stick, used by wizards, casue they cast spells, and don't actually fight.",
            10,
            20
            );
        public Armor robes = new(
            2,
            "Robes",
            "Decent quality cloth, light and breathable.",
            10,
            20
            );
        public Spell fireBall = new(
            5,
            5,
            "Fire Ball",
            "A small ball of fire shoots from your finger.",
            55,
            0
            );
        public Spell lightning = new(
            5,
            5,
            "Lightning",
            "A bolt of lightning hits the enemy.",
            55,
            0
            );
        public Weapon ironBow = new(
            4,
            "Iron Bow",
            "An affordable bow that is easy to weild.",
            25,
            50
            );

        public Potion healthPotion = new(PotionType.Health, 10, 10, 5);
        public Potion manaPotion = new (PotionType.Mana, 10, 10, 5);

        public Merchant()
        {
            inventory.Add(ItemType.Potion, new List<Item>());
            inventory.Add(ItemType.Equipment, new List<Item>());
            inventory.Add(ItemType.Spell, new List<Item>());

            AddItem(ironSword);
            AddItem(leatherArmor);
            AddItem(ironStaff);
            AddItem(robes);
            AddItem(ironBow);
            AddItem(healthPotion);
            AddItem(manaPotion);
            AddItem(fireBall);
            AddItem(lightning);

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
    }
}
