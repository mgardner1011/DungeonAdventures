using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class StoryService
    {
        private readonly MenuService _menuService;
        private readonly BattleService _battleService;
        private readonly MerchantService _merchantService;
        public StoryService()
        {
            _menuService = new MenuService();
            _battleService = new BattleService();
            _merchantService = new MerchantService();
        }

        public void WriteGameIntro()
        {
            //write out game intro
            Console.WriteLine("  _____                                                   _                 _                       \r\n |  __ \\                                         /\\      | |               | |                      \r\n | |  | |_   _ _ __   __ _  ___  ___  _ __      /  \\   __| |_   _____ _ __ | |_ _   _ _ __ ___  ___ \r\n | |  | | | | | '_ \\ / _` |/ _ \\/ _ \\| '_ \\    / /\\ \\ / _` \\ \\ / / _ \\ '_ \\| __| | | | '__/ _ \\/ __|\r\n | |__| | |_| | | | | (_| |  __/ (_) | | | |  / ____ \\ (_| |\\ V /  __/ | | | |_| |_| | | |  __/\\__ \\\r\n |_____/ \\__,_|_| |_|\\__, |\\___|\\___/|_| |_| /_/    \\_\\__,_| \\_/ \\___|_| |_|\\__|\\__,_|_|  \\___||___/\r\n                      __/ |                                                                         \r\n                     |___/                                                                          ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\nWelcome to Dungeon Adventures, traveler!");
            Console.WriteLine("You are about to embark on an epic quest!");
            _menuService.WaitForTheReader();
            Console.WriteLine("But first, tell us a bit about yourself.");
        }

        public Player CreateNewPlayer()
        {
            Player player = new Player();
            player.Name = CreatePlayerName();

            Console.WriteLine($"\nPleasure to meet you, {player.Name}.");
            player.ClassType = ChoosePlayerClass();

            AdjustPlayerStats(player);

            EquipPlayer(player);
            
            return player;
        }

        private void EquipPlayer(Player player)
        {
            //Fighter equipment
            Weapon ironSword = new (
                5, 
                "Iron Sword", 
                "An affordable sword that is easy to wield.",
                25,
                50
                );
            Armor leatherArmor = new(
                4,
                "Leather Armor",
                "Affordable armor, that is easy to wear.",
                25,
                50
                );
            //Wizard equipment
            Weapon ironStaff = new(
                3,
                "Quarterstaff",
                "A long stick, used by wizards, casue they cast spells, and don't actually fight.",
                10,
                20
                );
            Armor robes = new(
                2,
                "Robes",
                "Decent quality cloth, light and breathable.",
                10, 
                20
                );
            Spell fireBall = new(
                5,
                5,
                "Fire Ball",
                "A small ball of fire shoots from your finger.",
                55,
                0
                );
            Spell lightning = new(
                5,
                5,
                "Lightning",
                "A bolt of lightning hits the enemy.",
                55,
                0
                );
            //Ranger equipment Ranger also gets leather armor
            Weapon ironBow = new (
                4, 
                "Iron Bow", 
                "An affordable bow that is easy to weild.",
                25,
                50
                );
            switch (player.ClassType)
            {
                case DnDClass.Fighter:
                    player.Weapon = ironSword;
                    player.Armor = leatherArmor;
                    break;
                case DnDClass.Wizard:
                    player.Weapon = ironStaff;
                    player.Armor = robes;
                    player.AddItem(fireBall);
                    player.AddItem(lightning);
                    break;
                case DnDClass.Ranger:
                    player.Weapon = ironBow;
                    player.Armor = leatherArmor;
                    break;
            }
            player.Gold += 100;
        }

        private void AdjustPlayerStats(Player player)
        {
            switch (player.ClassType)
            {
                case DnDClass.Fighter:
                    player.Strength += 8;
                    player.Defense += 1;
                    player.Magic -= 2;
                    player.MagicDefense -= 2;
                    player.Mana = 0;
                    break;
                case DnDClass.Wizard:
                    player.Strength += 1;
                    player.Defense -= 1;
                    player.Magic += 7;
                    player.MagicDefense += 2;
                    break;
                case DnDClass.Ranger:
                    player.Strength += 6;
                    player.Defense += 1;
                    player.Magic -= 1;
                    player.MagicDefense -= 1;
                    player.Mana = 0;
                    break;
                default:
                    //all stats stay the same
                    break;
            }
        }
        private string CreatePlayerName()
        {
            Console.WriteLine("What is your name?");
            Console.Write("Input name -> ");
            string playerName = Console.ReadLine();
            Console.WriteLine("\n");

            bool nameCorrect;
            do
            {
                nameCorrect = _menuService.GetConfirmation($"So your name is {playerName}?");
                if (!nameCorrect)
                {
                    nameCorrect = false;
                    Console.WriteLine("\nOkay then. What is your real name?");
                    Console.Write("Input name -> ");
                    playerName = Console.ReadLine();
                    Console.WriteLine("\n");
                }
            } while (!nameCorrect);
            return playerName;
        }

        private DnDClass ChoosePlayerClass()
        {
            bool classCorrect;
            DnDClass classChoice;
            do
            {
                Console.WriteLine("\nWhat is your class?");
                Console.WriteLine($"{(byte)DnDClass.Fighter}. {DnDClass.Fighter}");
                Console.WriteLine($"{(byte)DnDClass.Wizard}. {DnDClass.Wizard}");
                Console.WriteLine($"{(byte)DnDClass.Ranger}. {DnDClass.Ranger}");
                Console.Write("\nInput the number of your choice -> ");
                classChoice = (DnDClass)Convert.ToByte(Console.ReadLine());
                classCorrect = _menuService.GetConfirmation($"\nSo you are a {classChoice}?");
            } while (!classCorrect);
            return classChoice;
        }

        internal void kingsQuest(Player player)
        {
            Console.WriteLine($"\nWelcome to your adventure {player.Name} the {player.ClassType}.");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("You find yourself in a large gilded throne room, in the land of Lucina.");
            Console.WriteLine("The King and queen sit on their thrones before you, eying you wearily.");
            _menuService.WaitForTheReader();
            Console.WriteLine("The King begins to speak \"We have called you hear to help us with a matter most dire.\"");
            Console.WriteLine("\"There is a monster terrorizing our country, and we need your help to defeat it.\"");
            Console.WriteLine($"\"As this is a test game, you are the only {player.ClassType} in the land.\"");
            _menuService.WaitForTheReader();
            Console.WriteLine("\"Without your help we are doomed to live in fear for the rest of eternity—or at least until the game is over.");
            Console.WriteLine($"\"{player.Name}, will you please help us?\"");

            int choice = -1;
            while(choice < 0 || choice > 3)
            {
                Console.WriteLine();
                Console.WriteLine("What do you say?");
                string[] menuOptions =
                {
                "'Well... I guess so.'",
                "'Of course I am!'",
                "'No, I don't think so...'"
                };
                choice = _menuService.GetPlayerChoice(menuOptions);
            }

            switch (choice)
            {
                case 0:
                    Console.WriteLine("\n\"That's the spirit! You're gonna do just fine!\"");
                    Console.WriteLine("\"To ensure you don't die during your quest, take these.\"");
                    break;
                case 1:
                    Console.WriteLine("\n\"Don't get too cocky now.\"");
                    Console.WriteLine("\"Just make sure you don't die today. These might help with that.\"");
                    break;
                case 2:
                    Console.WriteLine("\n\"Well that's really shitty of you! We are in despirate need of your help.\"");
                    Console.WriteLine("If you don't help the game ends, so you're doing it!");
                    break;
            }
            _menuService.WaitForTheReader();


            var healthPotion = new Potion(PotionType.Health, 10, 10, 5);
            var manaPotion = new Potion(PotionType.Mana, 10, 10, 5);

            player.AddItem(healthPotion);
            player.AddItem(manaPotion);

            Console.WriteLine($"{player.Name} received 2 potions.");
        }

        internal bool InitiationDecision()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");

            string[] menuOptions =
            {
                "Defeat the Monster",
                "Refuse"
            };

            int choice = _menuService.GetPlayerChoice(menuOptions);

            return choice == 0;
        }

        internal void RefuseQuest()
        {
            Console.WriteLine("The King responds \"I am dissapointed that you decided to not help us.\"");
            Console.WriteLine("\"We of course can't force you to help, after all.\"");
            Console.WriteLine("\"Unfortunately, for you I am not a kind King.\"");
            _menuService.WaitForTheReader();
            Console.WriteLine("\"GUARDS!!!\"");
            Console.WriteLine("You are thrown in the dungeon, imprisoned deep beneath the castle. You will never see the light of day again.");
            _menuService.EndScreen();
        }

        internal void AcceptQuest()
        {
            Console.WriteLine("\n\"Your assistance is appreciated, and will not go unrewarded.\"");
            Console.WriteLine("\"In order to get to the cave where the creature lives, exit the main gate and head West.\"");
            Console.WriteLine("\"You will see a large mountain with a creepy almost mouth like cave entrance. There you will find the beast.\"");
            _menuService.WaitForTheReader();
            Console.WriteLine("\"Prepare yourself, for it will not be an easy journy.\"\n");
            Console.WriteLine("You leave the throne room, and exit the city. The main gate is closed behind you as you leave.");
            _menuService.WaitForTheReader();
        }

        internal bool OutsideTheCastle(Player player)
        {
            Goblin goblin = new Goblin();
            int choice;
            do
            {
                Console.WriteLine("You see a wide expanse of land, laid out in front of you.");
                Console.WriteLine("You are facing North with the city gates behind you.");
                Console.WriteLine("Which way do you go?");
                string[] menuOptions =
                {
                "North",
                "South",
                "East",
                "West"
                };
                choice = _menuService.GetPlayerChoice(menuOptions);
            


                switch (choice)
                {
                    case 0:
                        Console.WriteLine("\nYou head North, traveling for hours, never finding the mountain.");
                        Console.WriteLine("You find some woods, thinking that the mountain is past them, you enter.");
                        Console.WriteLine("Entering the woods, you get lost, and starve. You are dead");
                        _menuService.EndScreen();
                        break;
                    case 1:
                        Console.WriteLine("\nThe city gates are locked behind you. You cannot retun until you have defeated the monster.\n");
                        break;
                    case 2: 
                        Console.WriteLine("\nYou find a village of odd humanoid creatures, with milky white skin, and a sundry of extra apendages.");
                        Console.WriteLine("As they see you enter the village, they quickly decend upon you, and the world goes black.");
                        _menuService.WaitForTheReader();
                        Console.WriteLine("The monsters roast your body, and feast off of you for many moons.");
                        Console.WriteLine("At least your body didn't go to waste.");
                        _menuService.EndScreen();
                        break;
                    case 3:
                        Console.WriteLine("\nYou head West and cross a beautiful expans of land along your journy.");
                        Console.WriteLine("As you journey along, you are attacked by a monster!");
                        _menuService.WaitForTheReader();
                        _battleService.Battle(player, goblin);
                        Console.WriteLine("You find a merchnat peddling his wares.\n");
                        _menuService.WaitForTheReader();
                        Merchant merchant = new Merchant();
                        _merchantService.OpenStore(player, merchant);
                        Console.WriteLine("Eventually finding the mountain cave the King mentioned.\n");
                        Console.WriteLine("--Entering the cave--");
                        _menuService.WaitForTheReader();
                        break;
                }
            } while (choice == 1);
            return choice ==  3;
        }

        internal void BackInTheCastle(Player player)
        {
            Console.WriteLine("\nThe gates are thrown open, and you are greeted with music, and pararades, and all the");
            Console.WriteLine("acolades you could ever wish for.");
            _menuService.WaitForTheReader();
            Console.WriteLine("Sike! This isn't that type of game!");
            Console.WriteLine("No one knows who you are, that you left then returned, or that you nearly died in a cave");
            Console.WriteLine("fighting a mutant rabbit!");
            _menuService.WaitForTheReader();
            Console.WriteLine("Back at the castle you are let into the throne room to speak with the King.");
            Console.WriteLine($"\"Welcome back {player.Name}! Glad you didn't die.\"");
            Console.WriteLine("\"I take it this means you defeated the monster.\"");
            _menuService.WaitForTheReader();
            Console.WriteLine("\"wonderful!!! Here is your reward.\"");
            Console.WriteLine("You received 50 Gold");
            Console.WriteLine("\"Great, now I'm done with you. Go away!\"");
            _menuService.WaitForTheReader() ;
            Console.WriteLine("\nAnd that dear adventurer is where our story ends!");
            Console.WriteLine("Thank you for Playing!");
            _menuService.WaitForTheReader();

        }
    }
}
