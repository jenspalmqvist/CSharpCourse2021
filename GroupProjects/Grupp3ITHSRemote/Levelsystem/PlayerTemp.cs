using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Rollspel
{
    public static class PlayerTemp
    {
        public static char Symbol { get; set; } = '@';
        public static int X { get; set; } = 30;
        public static int Y { get; set; } = 10;
        public static int Bonks { get; set; } = 0; // Hur många gånger man gått in i en vägg.

        public static void Move() // Temporär för utveckling.
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    X -= 1;
                    break;

                case ConsoleKey.RightArrow:
                    X += 1;
                    break;

                case ConsoleKey.UpArrow:
                    Y -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    Y += 1;
                    break;
            }

            // Tömmer bufferten. Tar bort skridskokänslan.
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            LevelHandler.CurrentLevel.Steps++;
        }

        public static void Kill()
        {
            // TODO: Någon visuell effekt?
            // Kod som körs när spelaren dör.
            Console.SetCursorPosition(LevelHandler.AnchorX, 0); // Temp
            Console.WriteLine("Du dog!");                       //
            Thread.Sleep(500);                                  //
            Console.SetCursorPosition(LevelHandler.AnchorX, 0); //
            Console.WriteLine("       ");                       //

            LevelHandler.Restart();
        }
    }
}