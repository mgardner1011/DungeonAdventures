using System;
using System.Runtime.CompilerServices;
using System.Threading;
using DungeonAdventures.Models;
using DungeonAdventures.Services;

namespace DungeonAdventures
{
    internal class Program
    {
        private static StoryService _storyService = new StoryService();
        private static DungeonService _dungeonService = new DungeonService();

        static void Main(string[] args)
        {
            Console.Title = "Dungeon Adventures";
            _storyService.WriteGameIntro();
            var player = _storyService.CreateNewPlayer();
            Thread.Sleep(1000);
            Console.Clear();
            _storyService.kingsQuest(player);

            if (!_storyService.InitiationDecision())
            {
                //leave guild forever
                _storyService.RefuseQuest();
                //Environment.Exit(0);//make a method for this and end game screen
            }
                //take the test
            _storyService.AcceptQuest();
            if (_storyService.OutsideTheCastle(player))
            {
                _dungeonService.ExploreDungeon(player);
            }
            _storyService.BackInTheCastle(player);
        }
    }
}
