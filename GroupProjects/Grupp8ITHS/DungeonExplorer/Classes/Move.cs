using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DungeonExplorer
{
    public class Move
    {
        public static int[] PlayerPosition { get; set; }
        private static int StepSizeX { get; set; }
        private static int StepSizeY { get; set; }
        public Move()
        {
            StepSizeX = 2;
            StepSizeY = 1;
            PlayerPosition = new int[2];
            PlayerPosition[0] = 1;
            PlayerPosition[1] = 7;
        }
        public static void MovePlayer()
        {
            MoveKeys userInput;
            do
            {
                userInput = GetMoveKey();
                UI.RefreshMap();
                if (userInput == MoveKeys.None)
                {
                    Console.Write($"Invalid input! {UI.InterfaceInstructions}");
                    Console.WriteLine();
                }
            } while (userInput == MoveKeys.None);

            switch (userInput)
            {
                case MoveKeys.Escape:
                    Game.GameInProgress[0] = false;
                    break;

                case MoveKeys.Up:
                    if (CheckValidMove(PlayerPosition[0] - StepSizeY, PlayerPosition[1]))
                    {
                        PlayerPosition[0] -= StepSizeY;
                        Game.player.Moves++;
                    }
                    break;

                case MoveKeys.Left:
                    if (CheckValidMove(PlayerPosition[0], PlayerPosition[1] - StepSizeX))
                    {
                        PlayerPosition[1] -= StepSizeX;
                        Game.player.Moves++;
                    }
                    break;

                case MoveKeys.Down:
                    if (CheckValidMove(PlayerPosition[0] + StepSizeY, PlayerPosition[1]))
                    {
                        PlayerPosition[0] += StepSizeY;
                        Game.player.Moves++;
                    }
                    break;

                case MoveKeys.Right:
                    if (CheckValidMove(PlayerPosition[0], PlayerPosition[1] + StepSizeX))
                    {
                        PlayerPosition[1] += StepSizeX;
                        Game.player.Moves++;
                    }
                    break;

                case MoveKeys.Inventory:
                    Game.player.DisplayInventory();
                    break;
            }
        }
        public static bool CheckValidMove(int moveToY, int moveToX)
        {
            bool validMove = true;
            if (moveToY < 0 || moveToX < 0 || moveToY > Map.MapSizeY - 1 || moveToX > Map.MapSizeX - 1)
            {
                Console.WriteLine("Out of bounds! Please move in another direction.");
                MovePlayer();
                validMove = false;
            }
            else if (Map.CaveMap[moveToY, moveToX].ToLower() == "|" || Map.CaveMap[moveToY, moveToX].ToLower() == "_" || Map.CaveMap[moveToY, moveToX].ToLower() == "x")
            {
                Console.WriteLine("You can't go through walls! Please move in another direction.");
                MovePlayer();
                validMove = false;
            }
            else if (Map.CaveMap[moveToY, moveToX] == "/")
            {
                Game.GameInProgress[0] = false;
                Game.GameInProgress[1] = true;
            }
            return validMove;
        }
        private static MoveKeys GetMoveKey()
        {
            var keyInput = Console.ReadKey().Key;

            return keyInput switch
            {
                ConsoleKey.Escape => MoveKeys.Escape,
                ConsoleKey.UpArrow => MoveKeys.Up,
                ConsoleKey.LeftArrow => MoveKeys.Left,
                ConsoleKey.DownArrow => MoveKeys.Down,
                ConsoleKey.RightArrow => MoveKeys.Right,
                ConsoleKey.Spacebar => MoveKeys.Inventory,
                _ => MoveKeys.None,
            };
        }
    }
}

