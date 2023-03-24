using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class BattleService
    {
        private readonly MenuService _menuService;
        public BattleState _battleState;
        public LevelService _levelService;

        public BattleService()
        {
            _menuService = new MenuService();
            _battleState = new BattleState();
            _levelService = new LevelService();
        }

        internal bool Battle(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"A {enemy.Name} approaches. \nPrepair for battle!!!");
            _battleState = BattleState.PlayerTurn;
            do
            {
                if (_battleState == BattleState.PlayerTurn)
                {
                    Playerturn(player, enemy);
                }
                if (_battleState == BattleState.EnemyTurn)
                {
                    EnemyTurn(player, enemy);
                }
            } while (_battleState == BattleState.PlayerTurn || _battleState == BattleState.EnemyTurn);

            if (_battleState == BattleState.Lost)
            {
                return false;
            }
            else //_battleState = BattleState.Won
            {
                player.Gold += enemy.Gold;
                _levelService.GainXp(player, enemy.Xp);
                return true;
            }
        }

        internal void Playerturn(Player player, Enemy enemy)
        {
            Console.WriteLine($"\nHP: {player.Health}\tMP: {player.Mana}");
            //give options to do something
            string[] menuOptions =
            {
                "Attack",
                "Magic",
                "Use Potion",
                "Do Nothing"
            };
            int choice = _menuService.GetPlayerChoice(menuOptions);
        //attack heal or do nothing
            switch (choice)
            {
                case 0:
                    PlayerAttack(player, enemy);
                    break;
                case 1:
                    CastSpell(player, enemy);
                    break;
                case 2:
                    if (!player.GetAllItemsInInventory(ItemType.Potion).Any())
                    {
                        Console.WriteLine("You don't have any potions to use.");
                        _battleState = BattleState.PlayerTurn;
                        break;
                    }
                    UseItem(player, ItemType.Potion);
                    break;
                case 3:
                    Console.WriteLine("You did nothing.");
                    _battleState = BattleState.EnemyTurn;
                    break;
            }
        }

        private void CastSpell(Player player, Enemy enemy)
        {
            Console.WriteLine("Choose a spell");

            Spell spell = (Spell)_menuService.UseItemMenu(player, ItemType.Spell);
            int damage = (player.Magic + spell.Might) - (enemy.MagicDefense);
            Console.WriteLine($"\n{spell.Description}");
            Console.WriteLine($"You deal {damage} points of damage");

            enemy.Health -= damage;
            player.Mana -= spell.ManaCost;

            //check if enemy died
            if (enemy.Health <= 0)
            {
                Console.WriteLine("You won the Battle!");
                Console.WriteLine($"You've gained {enemy.Xp} xp!");
                _battleState = BattleState.Won;
                return;
            }
            _battleState = BattleState.EnemyTurn;

        }

        private void UseItem(Player player, ItemType itemType)
        {
            Console.WriteLine("What potion would you like to use?");

            Potion potionToUse = (Potion) _menuService.UseItemMenu(player, itemType);

            potionToUse.ApplyEffect(player);
            player.RemoveItem(potionToUse);
            Console.WriteLine($"{player.Name} {potionToUse.Description}");
            Console.WriteLine($"{player.Name}'s health is {player.Health}");

            _battleState = BattleState.EnemyTurn;
        }

        internal void EnemyTurn(Player player, Enemy enemy)
        {
            EnemyAttack(player, enemy);
        }

        internal void PlayerAttack(Player player, Enemy enemy)
        {
            int damage =
                (player.Strength + player.Weapon.Might) - (enemy.Defense + enemy.Armor.Defense);
            Console.WriteLine($"You attack {enemy.Name} for {damage} damage");
            enemy.Health -= damage;
            //check if enemy died
            if(enemy.Health <= 0)
            {
                Console.WriteLine("You won the Battle!");
                Console.WriteLine($"You've gained {enemy.Xp} xp!");
                _battleState = BattleState.Won;
                return;
            }
            _battleState = BattleState.EnemyTurn;
        }

        internal void EnemyAttack(Player player, Enemy enemy)
        {
            int damage = 
                (enemy.Strength + enemy.Weapon.Might) - (player.Defense + player.Armor.Defense);
            Console.WriteLine($"You take {damage} damage");
            player.Health -= damage;
            //check if player died
            if(player.Health <= 0)
            {
                Console.WriteLine("You Died!!!");
                _battleState = BattleState.Lost;
                _menuService.EndScreen();
            }
            _battleState = BattleState.PlayerTurn;
        }
    }
}
