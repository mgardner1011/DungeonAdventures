using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class LevelService
    {
        public List<int> _levelXp { get; protected set; }

        readonly MenuService _menuService;

        public LevelService()
        {
            _levelXp = new List<int> { 0, 25, 100, 150, 250, 500 };
            _menuService = new MenuService();
        }

        public void GainXp(Player player, int xp)
        {
            player.Xp += xp;

            for (int x = _levelXp.Count - 1; x >= 0; x--)
            {

                if (player.Xp >= _levelXp[x] && player.Level < _levelXp[x] + 1)
                {
                    player.LevelUp(x + 1);
                    Console.WriteLine($"You leveled up!!! You are now level {player.Level}");
                    _menuService.WaitForTheReader();
                    return;
                }
            }
        }
    }
}
