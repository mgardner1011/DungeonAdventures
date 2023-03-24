using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class MenuService
    {
        public int GetPlayerChoice(string[] menuOptions)
        {
            int choice;
            do
            {
                Console.WriteLine();
                try
                {
                    for (int x = 0; x < menuOptions.Length; x++)
                    {
                        Console.WriteLine($"{x + 1}. {menuOptions[x]}");
                    }
                    choice = GetChoice() - 1;
                }
                catch (FormatException)
                {
                    choice = -1;
                    Console.WriteLine("please input only the number of your choice");
                    Console.WriteLine();
                }
                catch(Exception ex)
                {
                    choice = -1;
                    Console.Clear();
                    Console.WriteLine("------------- World Error -------------");
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("-------------  End Error  -------------");
                    Console.WriteLine("That was strange. The World glitched for a second.");
                    Console.WriteLine("Please input only the number of your choice");
                }
            } while (choice < 0 || choice >= menuOptions.Length);
            return choice;
        }

        internal bool GetConfirmation(string confirmationText)
        {
            int choice;
            do
            {
                try
                {
                    Console.WriteLine(confirmationText);
                    Console.WriteLine();
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    choice = GetChoice();
                }
                catch
                {
                    choice = -1;
                    Console.Clear();
                    Console.WriteLine("Please only input the number of your choice.");
                }
            } while (choice < 1 || choice > 2);
            return choice == 1;
        }

        private int GetChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the number of your choice and hit Enter");
            Console.Write("Choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        internal Item UseItemMenu(Player player, ItemType itemType)
        {

            for (int x=0; x < player.GetAllItemsInInventory(itemType).Count; x++)
            {
                Item item = player.GetAllItemsInInventory(itemType)[x];
                Console.WriteLine($"{x+1}. {item.Name}");
            }
            int choice = GetChoice();
            Item itemChoice = player.GetAllItemsInInventory(itemType)[choice - 1];
            return itemChoice;
        }

        public void WaitForTheReader()
        {
            Console.Write("Press Enter to Continue-> ");
            Console.ReadLine();
            Console.WriteLine("\n");
        }

        public void EndScreen()
        {
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("  ________                              ________                         \r\n /  _____/ _____     _____    ____      \\_____  \\ ___  __  ____ _______  \r\n/   \\  ___ \\__  \\   /     \\ _/ __ \\      /   |   \\\\  \\/ /_/ __ \\\\_  __ \\ \r\n\\    \\_\\  \\ / __ \\_|  Y Y  \\\\  ___/     /    |    \\\\   / \\  ___/ |  | \\/ \r\n \\______  /(____  /|__|_|  / \\___  >    \\_______  / \\_/   \\___  >|__|    \r\n        \\/      \\/       \\/      \\/             \\/            \\/         \r\n                                                                         ");
            Console.WriteLine("Your adventure has ended. Restart the program to try again.");
            Environment.Exit(0);
        }

        internal void SellItemMenu(Player player, ItemType itemType, Merchant merchant)
        {
            if(player.GetAllItemsInInventory(itemType).Count == 0)
            {
                Console.WriteLine("you have nothing to sell.");
                return;
            }
            for (int x=0; x < player.GetAllItemsInInventory(itemType).Count; x++)
            {
                Item item = player.GetAllItemsInInventory(itemType)[x];

                Console.WriteLine($"{x+1}. {item.Name}\t{item.Description}\nsells for {item.Sell}");
            }
            int choice = GetChoice();
            Item itemChoice = player.GetAllItemsInInventory(itemType)[choice - 1];

            if (merchant.Gold < itemChoice.Sell)
            {
                Console.WriteLine("\"Sorry I can't afford that\"");
                return;
            }

            Console.WriteLine($"\"I will buy {itemChoice.Name} for {itemChoice.Sell} gold.\"");

            if (GetConfirmation("\"Is that okay?\""))
            {
                player.RemoveItem(itemChoice);
                player.Gold += itemChoice.Sell;
                merchant.AddItem(itemChoice);
                merchant.Gold -= itemChoice.Sell;

            }
        }

        internal void BuyItemMenu(Player player, ItemType itemType, Merchant merchant)
        {
            if (merchant.GetAllItemsInInventory(itemType).Count ==0) {
                    Console.WriteLine("I have nothing to sell.");
                    return;
                } 
            for (int x = 0; x < merchant.GetAllItemsInInventory(itemType).Count; x++)
            {
                Item item = merchant.GetAllItemsInInventory(itemType)[x];

                Console.WriteLine($"{x + 1}. {item.Name}\t{item.Description}\ncosts {item.Buy}");
            }
            int choice = GetChoice();
            Item itemChoice = merchant.GetAllItemsInInventory(itemType)[choice - 1];

            if (player.Gold < itemChoice.Buy)
            {
                Console.WriteLine("\"Sorry you can't afford that\"");
                return;
            }

            Console.WriteLine($"\"I will sell {itemChoice.Name} for {itemChoice.Buy} gold.\"");

            if (GetConfirmation("\"Is that okay?\""))
            {
                merchant.RemoveItem(itemChoice);
                merchant.Gold += itemChoice.Sell;
                player.AddItem(itemChoice);
                player.Gold -= itemChoice.Sell;

            }
        }
    }
}
