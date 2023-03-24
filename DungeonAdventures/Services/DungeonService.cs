using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class DungeonService
    {
        private readonly string[] dungeonActions = {"Move Around", "Investigate the current space" };
        private readonly string[] navigationActions = 
        {
            Navigation.Forward.ToString(), 
            Navigation.Left.ToString(), 
            Navigation.Right.ToString(), 
            Navigation.Backward.ToString() 
        };

        private readonly MenuService _menuService;
        private readonly NavigationService _navigationService;
        private readonly BattleService _battleService;
        private readonly Enemy enemy;
        public DungeonService()
        {
            _menuService = new MenuService();
            _navigationService = new NavigationService();
            _battleService = new BattleService();
            enemy = new MutantRabbit();
        }

        public void ExploreDungeon(Player player)
        {
            DungeonSpace[,] room1 =
            {
                {DungeonSpace.Empty, DungeonSpace.Treasure, DungeonSpace.Empty, DungeonSpace.SpecialFeature},
                {DungeonSpace.Empty, DungeonSpace.Wall, DungeonSpace.Wall, DungeonSpace.Empty},
                {DungeonSpace.SpecialFeature, DungeonSpace.Wall, DungeonSpace.Wall, DungeonSpace.Empty},
                {DungeonSpace.Empty, DungeonSpace.Entrance, DungeonSpace.Empty, DungeonSpace.Empty}
            };

            bool crystalFound = false;
            var location = new Location(2, 1);

            Console.WriteLine("The room is dark, but you can see enough to start looking for the key.");
            do
            {
                Console.WriteLine();
                Console.WriteLine($"Your current location is [{location.Row}, {location.Column}]");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");

                var action = (DungeonActions) _menuService.GetPlayerChoice(dungeonActions);

                switch (action)
                {
                    case DungeonActions.Move:
                        Console.WriteLine();
                        Console.WriteLine("Which way would you like to move?");
                        int moveChoice = _menuService.GetPlayerChoice(navigationActions);
                        _navigationService.MovePlayerLocation(location, navigationActions[moveChoice], room1);
                        break;
                    case DungeonActions.Investigate:
                        var space = GetDungeonSpace(room1, location);
                        Console.WriteLine();
                        Console.WriteLine(GetInvestigationResults(space, "Shiny Rocks"));
                        if(space == DungeonSpace.Treasure)
                        {
                            bool confirmation = _menuService.GetConfirmation("Would you like to open the chest?");
                            if (confirmation)
                            {
                                crystalFound = true;
                                Console.WriteLine("You found the key");
                                Console.WriteLine();
                            }
                        }
                        break;
                }
            } while (!crystalFound);
            Console.WriteLine();
            Console.WriteLine("You find a strang crystal in the chest.");
            Console.WriteLine("As you pick it up, it begins to glow brightly.");
            Console.WriteLine("You are engulfed in a blinding white light.");
            _menuService.WaitForTheReader();
            Console.WriteLine("you find yourself in a large room, dimy light by torch light.");
            Console.WriteLine("In front of you, you find a small fluffy rabbit, surrounded by piles of bones.");
            Console.WriteLine("The rabbit sees you, and begins to controt and shift, as you hear flesh ripping and bones cracking.");
            _menuService.WaitForTheReader();
            Console.WriteLine("The rabbit begins to transforma in to an enormous monster.");
            Console.WriteLine("Fear floods your body as it screams in pain and hunger. Ready for another meal.");
            Console.WriteLine("Prepare for battle!");
            _menuService.WaitForTheReader();
            _battleService.Battle(player, enemy);
            _menuService.WaitForTheReader();
            Console.WriteLine("You make your way back to the castle.");
        }

        private string GetInvestigationResults(object space, string specialFeatureText)
        {
            switch (space)
            {
                case DungeonSpace.Entrance:
                    return "\nThis is the entrance of the dungeon.";
                case DungeonSpace.SpecialFeature:
                    return $"\nYou found {specialFeatureText} near you.";
                case DungeonSpace.Treasure:
                    return "\nYou see a treasure chest in front of you.";
                default:
                    return "\nYou see nothing of interest around you.";
            }
        }

        private DungeonSpace GetDungeonSpace(DungeonSpace[,] map, Location location)
        {
            return map[location.Row, location.Column];
        }
    }
}
