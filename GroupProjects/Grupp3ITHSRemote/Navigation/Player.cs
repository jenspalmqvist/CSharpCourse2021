using System;
using System.Threading;

namespace Rollspel
{
    internal static class Player
    {
        public static int X { get; set; }
        public static int Y { get; set; }
        public static char Symbol { get; set; } = '@';
        public static int Bonks { get; set; } = 0; // how many times the Player walked into the wall

        public static void GetInput()
        {
            // Look for input until legal input is provided
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (TryToMove(X - 1, Y))
                        {
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        if (TryToMove(X + 1, Y))
                        {
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        if (TryToMove(X, Y - 1))
                        {
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        if (TryToMove(X, Y + 1))
                        {
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Spacebar:
                        Inventory.UseInventoryItem();
                        return;
                case ConsoleKey.N: // Temporär för utveckling.
                        LevelHandler.NextLevel();
                    break;

                }
                // waits until keys are available again before leaving the method
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }

        // check if a move can be made
        // arguments to this method should be the potential new position
        // for example for a move up the arguments should be (Column, Row - 1)
        public static bool TryToMove(int requestedX, int requestedY)
        {
            switch (LevelHandler.CurrentLevel.Layout[requestedX, requestedY])
            {
                case ' ':
                    MakeMovement(requestedX, requestedY);
                    return true;

                case '░': //Minfält
                    MakeMovement(requestedX, requestedY);
                    return true;

                case 'O': // Potatis
                    return false;

                case 'N': // Nyckel
                    MakeMovement(requestedX, requestedY);
                    return true;

                default:
                    Bonks++;
                    return false;
            }
        }

        public static void MakeMovement(int newX, int newY)
        {
            X = newX;
            Y = newY;
            Program.DrawEmpty(InteractiveMenu.AnchorX, InteractiveMenu.AnchorY, InteractiveMenu.MenuWidth - 2, InteractiveMenu.MenuHeight - 2);
            LevelHandler.CurrentLevel.Steps++;
            LevelHandler.Step();
        }

        public static void Kill()
        {
            // TODO: Någon visuell effekt?
            // Kod som körs när spelaren dör.
            Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 2);
            Console.WriteLine("Du dog!");
            Thread.Sleep(1000);
            Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 2);
            Console.WriteLine("       ");

            LevelHandler.Restart();
        }
    }
}