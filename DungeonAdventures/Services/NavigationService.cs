using DungeonAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Services
{
    internal class NavigationService
    {
        const int maxLeft = 0;
        const int maxForward = 0;

        const int moveLeft = -1;
        const int moveRight = 1;
        const int moveForward = -1;
        const int moveBackward = 1;

        public void MovePlayerLocation(Location playerLocation, string movementDirection, DungeonSpace[,] map)
        {
            var direction = (Navigation)Enum.Parse(typeof(Navigation), movementDirection);
            int maxBackward = map.GetLength(0) - 1;
            int maxRight = map.GetLength(1) - 1;

            switch (direction)
            {
                case Navigation.Left:
                    if(playerLocation.Column > maxLeft &&
                        map[playerLocation.Row, playerLocation.Column + moveLeft] != DungeonSpace.Wall)
                    {
                        Console.WriteLine("Sucessfully Moved");
                        Console.WriteLine();
                        playerLocation.Column += moveLeft;
                    }
                    else
                    {
                        Console.WriteLine("You can't move there");
                        Console.WriteLine();
                    }
                    break;
                case Navigation.Right:
                    if (playerLocation.Column < maxRight &&
                        map[playerLocation.Row, playerLocation.Column + moveRight] != DungeonSpace.Wall)
                    {
                        Console.WriteLine("Sucessfully Moved");
                        Console.WriteLine();
                        playerLocation.Column += moveRight;
                    }
                    else
                    {
                        Console.WriteLine("You can't move there");
                        Console.WriteLine();
                    }
                    break;
                case Navigation.Forward:
                    if (playerLocation.Row > maxForward &&
                        map[playerLocation.Row + moveForward, playerLocation.Column] != DungeonSpace.Wall)
                    {
                        Console.WriteLine("Sucessfully Moved");
                        Console.WriteLine();
                        playerLocation.Row += moveForward;
                    }
                    else
                    {
                        Console.WriteLine("You can't move there");
                    }
                    break;
                case Navigation.Backward:
                    if (playerLocation.Row < maxBackward &&
                        map[playerLocation.Row + moveBackward, playerLocation.Column] != DungeonSpace.Wall)
                    {
                        Console.WriteLine("Sucessfully Moved");
                        Console.WriteLine();
                        playerLocation.Row += moveBackward;
                    }
                    else
                    {
                        Console.WriteLine("You can't move there");
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}
