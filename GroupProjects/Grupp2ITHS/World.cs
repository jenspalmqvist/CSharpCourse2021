using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GubbenIRummet
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    if (element == "?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(element);
                }
            }
        }
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }
        public bool IsPositionWalkable(int x, int y)
        {
            // Kolla vart X befinner sig först.
            if(x < 0 || y < 0 || x >= Cols || y >= Rows )
            {
                return false;
            }

            // Kolla om grid positionen går att gå på
            return Grid[y, x] == " " || Grid[y, x] == "?";
        }
    }
}
