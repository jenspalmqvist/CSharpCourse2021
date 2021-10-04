using System;

namespace Rollspel
{
    class Room
    {
        public char[,] Map { get; set; }

        public Room(int MapWidth, int MapHeight, int playerColumn, int playerRow)
        {
            Console.CursorVisible = false;
            // creates the map
            CreateMap(MapWidth, MapHeight);
        }

        public void CreateMap(int width, int height)
        {
            Map = new char[width, height]; 
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // top and bottom edges
                    if (y == 0 || y == height - 1)
                    {
                        Map[x, y] = '─';
                    }
                    // left and right edges
                    else if (x == 0 || x == width - 1)
                    {
                        Map[x, y] = '│';
                    }
                    // empty space
                    else
                    {
                        Map[x, y] = ' ';
                    }
                }
            }
            // corners
            Map[0, 0] = '┌';
            Map[width - 1, 0] = '┐';
            Map[0, height - 1] = '└';
            Map[width - 1, height - 1] = '┘';
        }
        public void PrintMap()
        {
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(Map[x, y]);
                }
            }
            Console.SetCursorPosition(Player.X, Player.Y);
            Console.Write(Player.Symbol);
        }
    }
}
