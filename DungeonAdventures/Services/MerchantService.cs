using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class MerchantService
    {
        private readonly MenuService _menuService;

        public MerchantService()
        {
            _menuService = new MenuService();
        }

        public void OpenStore(Player player, Merchant merchant)
        {
            int choice;
            do
            {
                Console.WriteLine("What would you like to do?");

                string[] menuOptions =
                {
                    "Buy",
                    "Sell",
                    "Exit"
                };

                choice = _menuService.GetPlayerChoice(menuOptions);

                switch (choice)
                {
                    case 0:
                        BuyItems(player, merchant);
                        break;
                    case 1:
                        SellItems(player, merchant);
                        break;
                    case 2:
                        break;
                }
            } while (choice != 2);
        }

        private void SellItems(Player player, Merchant merchant)
        {
            int choice; 
            do
            {
                Console.WriteLine("\"What would you like to sell?\"");
                Console.WriteLine($"Gold: {player.Gold}");
                string[] menuOptions =
                {
                    "Potions",
                    "Equipment",
                    "Back"
                };
                choice = _menuService.GetPlayerChoice(menuOptions);
                switch (choice)
                {
                    case 0:
                        _menuService.SellItemMenu(player, ItemType.Potion, merchant);
                        break;
                    case 1:
                        _menuService.SellItemMenu(player, ItemType.Equipment, merchant);
                        break;
                    case 2:
                        break;
                }
            } while (choice != 2);
        }

        private void BuyItems(Player player, Merchant merchant)
        {
            int choice;
            do
            {
                Console.WriteLine("\"What would you like to buy?\"");
                Console.WriteLine($"Gold: {player.Gold}");
                string[] menuOptions =
                {
                    "Potions",
                    "Equipment",
                    "Spells",
                    "Back"
                };
                choice = _menuService.GetPlayerChoice(menuOptions);
                switch (choice)
                {
                    case 0:
                        _menuService.BuyItemMenu(player, ItemType.Potion, merchant);
                        break;
                    case 1:
                        _menuService.BuyItemMenu(player, ItemType.Equipment, merchant);
                        break;
                    case 2:
                        _menuService.BuyItemMenu(player, ItemType.Spell, merchant);
                        break;
                    case 3:
                        break;
                }
            } while (choice != 3);
        }
    }
}
