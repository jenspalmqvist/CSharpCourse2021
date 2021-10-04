using System;

namespace Rollspel
{
    internal class Program
    {
        public static bool quit = false;
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(87, 45);

            Inventory.PrintInventory();


            LevelHandler.Initialize();
            while (!quit)
            {
                Player.GetInput();
            }


        }

        public static void DrawFrame(int x, int y, int width, int height)
        {
            char cornerTL = '╔', cornerTR = '╗', cornerBL = '╚', cornerBR = '╝', hor = '═', ver = '║';
            string line = "";

            line += cornerTL;
            for (int i = 0; i < width - 2; i++)
            {
                line += hor;
            }
            line += cornerTR;
            Console.SetCursorPosition(x, y);
            Console.Write(line);

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(ver);
                Console.SetCursorPosition(x + width - 1, y + i);
                Console.Write(ver);
            }

            line = "";
            line += cornerBL;
            for (int i = 0; i < width - 2; i++)
            {
                line += hor;
            }
            line += cornerBR;
            Console.SetCursorPosition(x, y + height - 1);
            Console.Write(line);
        }

        public static void DrawEmpty(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                string line = "";
                for (int j = 0; j < width; j++)
                {
                    line += " ";
                }
                Console.SetCursorPosition(x, y + i);
                Console.Write(line);
            }
        }
    }
}