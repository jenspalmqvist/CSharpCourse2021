using System;
using System.Threading;

namespace Labyrintho
{
    class Menu
    {
        public Menu()
        {
            Logo();
            Rules();
        }

        public void Logo()
        {
            Console.Clear();
            Console.WriteLine("    88                     88                                 88                      88");
            Thread.Sleep(500);
            Console.WriteLine("    88                     88                                 \"\"                ,d    88");
            Thread.Sleep(500);
            Console.WriteLine("    88                     88                                                   88    88");
            Thread.Sleep(500);
            Console.WriteLine("    88          ,adPPYYba, 88,dPPYba,  8b       d8 8b,dPPYba, 88 8b,dPPYba,   MM88MMM 88,dPPYba,   ,adPPYba,");
            Thread.Sleep(500);
            Console.WriteLine("    88          \"\"     `Y8 88P'    \"8a `8b     d8' 88P'   \"Y8 88 88P'   `\"8a    88    88P'    \"8a a8\"     \"8a");
            Thread.Sleep(500);
            Console.WriteLine("    88          ,adPPPPP88 88       d8  `8b   d8'  88         88 88       88    88    88       88 8b       d8");
            Thread.Sleep(500);
            Console.WriteLine("    88          88,    ,88 88b,   ,a8\"   `8b,d8'   88         88 88       88    88,   88       88 \"8a,   ,a8\"");
            Thread.Sleep(500);
            Console.WriteLine("    88888888888 `\"8bbdP\"Y8 8Y\"Ybbd8\"'      Y88'    88         88 88       88    \"Y888 88       88  `\"YbbdP\"'");
            Thread.Sleep(500);
            Console.WriteLine("                                           d8'");
            Thread.Sleep(500);
            Console.WriteLine("                                           d8'");
            Thread.Sleep(500);
        }

        public void Rules()
        {
            Console.WriteLine("\n\n\nWelcome to Labyrintho");
            Console.WriteLine("The rules are simple, use your arrow keys on keyboard and navigate your player marker until you reach the green square.");
            Console.WriteLine("Also inside the labyrinth there will be objects that will do magical stuff ;)\n\n");
        }

        public int SetDifficulty()
        {
            bool validInput = false;
            int input = 0;
            while (!validInput)
            {
                Console.WriteLine("Choose your difficulty:");
                Console.WriteLine("");
                Console.WriteLine("1: WALK IN THE PARK");
                Console.WriteLine("2: KEEP YOU BUSY");
                Console.WriteLine("3: DRIVE YOU INSANE");
                int.TryParse(Console.ReadLine(), out input);
                if ((input > 0) && (input < 4))
                    validInput = true;
            }
            return input;
        }
    }
}
