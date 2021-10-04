using System;
using System.Collections.Generic;

namespace Projektarbete_grp7
{
    class Program
    {
        static Room startingLocation;
        static void Main(string[] args)
        {
            startingLocation = new Room("Första rummet\n\n1. Gå vänster\n2. Gå höger (fälla)");
            Room roomTwo = new Room("Andra rummet...\n\n1. Val 1\n2. Val 2");
            Trap trapOne = new Trap();

            startingLocation.AddPath(roomTwo);
            startingLocation.AddPath(trapOne);


            MainMenu();

        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== Speltitel ===");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Starta spel");
            Console.WriteLine("2. Avsluta");

            int playerinput = GetPlayerInput(2);

            if (playerinput == 1)
            {
                StartGame();
            }
            else if (playerinput == 2)
            {
                ExitGame();
            }
        }

        public static void StartGame()
        {
            Player player = new Player();
            startingLocation.EnterLocation();
        }

        public static void ExitGame()
        {
            Environment.Exit(0);
        }

        public static int GetPlayerInput(int maxValue)
        {
            int playerInput;
            bool validInput;
            do
            {
                validInput = int.TryParse(Console.ReadLine(), out playerInput);

                if (!validInput)
                {
                    Console.WriteLine("Val får endast göras med en siffra");
                }
                else if (playerInput > maxValue || playerInput < 1)
                {
                    Console.WriteLine($"Ogiltigt val\nVälj en siffra mellan 1 och {maxValue})");
                    validInput = false;
                }

            } while (!validInput);

            return playerInput;
        }
    }
}
