using System;
using System.Collections.Generic;

namespace Adventure_Game
{
    internal class Map
    {
        private char[,] map;

        public Map(char[,] map)
        {
            this.map = map;
        }

        // returns the char at position (x, y) in the map array
        public char GetPosContent(int x, int y)
        {
            return map[x, y];
        }

        //For the player to se what is infront.
        public void PutCharAtPos(int x, int y, char c)
        {
            map[x, y] = c;
        }

        public void DrawMap()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            for (int y = 0; y <= map.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= map.GetUpperBound(1); x++)
                {
                    switch (map[y, x])
                    {
                        case Graphics.Player:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;

                        case Graphics.Rat:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;

                        case Graphics.Coin:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        case Graphics.Snake:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }

        //new char[,] {
        //{ Graphics.Wall, Graphics.Wall, Graphics.Wall, Graphics.Wall,Graphics.Wall, Graphics.Wall},
        //{ Graphics.Wall, Graphics.Coin, Graphics.Empty, Graphics.Empty, Graphics.Empty,Graphics.Wall},
        //{ Graphics.Wall, Graphics.Empty, Graphics.Empty, Graphics.Empty, Graphics.Empty,Graphics.Wall},
        //{ Graphics.Wall, Graphics.Empty, Graphics.Empty, Graphics.Empty, Graphics.Empty,Graphics.Wall},
        //{ Graphics.Wall, Graphics.Empty, Graphics.Empty, Graphics.Coin, Graphics.Empty,Graphics.Wall},
        //{ Graphics.Wall, Graphics.Wall, Graphics.Wall, Graphics.Wall, Graphics.Wall, Graphics.Wall}

        public int GetYDimension()
        {
            return map.GetUpperBound(0) + 1;
        }

        public int GetXDimension()
        {
            return map.GetUpperBound(1) + 1;
        }

        public List<(int, int, char)> GetEnemyPos()
        {
            var enemies = new List<(int, int, char)>();
            for (int y = 0; y <= map.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= map.GetUpperBound(1); x++)
                {
                    if (GetPosContent(y, x) == Graphics.Rat)
                    { enemies.Add((y, x, Graphics.Rat)); }
                    if (GetPosContent(y, x) == Graphics.Snake)
                    { enemies.Add((y, x, Graphics.Snake)); }
                }
            }
            return enemies;
        }
    }
}