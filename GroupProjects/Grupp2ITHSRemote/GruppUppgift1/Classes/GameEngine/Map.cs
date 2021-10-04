using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GruppUppgift1
{
    public class Map
    {
        public char[][] map { get; }
        public bool[,] mapVisible { get; set; }
        public int[] McGuffin { get; set; } = { 0, 0 };
        public (int, int) StartPosition { get; set; }
        public (int, int) StartPositionUp { get; set; }
        public (int, int) StartPositionDown { get; set; }
        private bool alwaysShowMap = false; // Debug-grejs, sätt till true för att alltid visa hela kartan.

        public Map(char[][] mapArray, (int, int) startPosition, (int, int) startPositionU, (int, int) startPositionD)
        {
            map = mapArray;
            StartPosition = startPosition;
            StartPositionUp = startPositionU;
            StartPositionDown = startPositionD;
            mapVisible = new bool[map.Length, map[0].Length];
            if (alwaysShowMap)
            {
                for (int i = 0; i < map.Length; i++)
                {
                    for (int j = 0; j < map[0].Length; j++)
                    {
                        mapVisible[i, j] = true;
                    }
                }
            }
        }
        public static List<Map> GetMaps()
        {
            List<Map> maps = new List<Map>();
            string[] mapStrings = File.ReadAllLines("maps.txt");
            char[][] mapArray = new char[mapStrings.Length][];
            (int, int) startPosition = (0, 0);
            (int, int) startPositionUp = (0, 0);
            (int, int) startPositionDown = (0, 0);

            for (int i = 0, j = 0; i < mapStrings.Length; i++, j++)
            {
                if (mapStrings[i] != ";")
                {
                    if (mapStrings[i].Contains('S'))
                        startPosition = (mapStrings[i].IndexOf('S'), j);
                    if (mapStrings[i].Contains('U'))
                        startPositionDown = (mapStrings[i].IndexOf('U'), j);
                    if (mapStrings[i].Contains('D'))
                        startPositionUp = (mapStrings[i].IndexOf('D'), j);
                    mapArray[j] = mapStrings[i].Replace('S', ' ').ToCharArray();
                }
                else
                {
                    int x, y;
                    Random rnd = new Random();
                    maps.Add(new Map(mapArray.Where(m => m != null).ToArray(), startPosition, startPositionUp, startPositionDown));
                    do
                    {
                        x = rnd.Next(0, maps.Last().map[0].Length);
                        y = rnd.Next(0, maps.Last().map.Length);
                    } while (maps.Last().map[y][x] != ' ');
                    maps.Last().McGuffin[0] = x; maps.Last().McGuffin[1] = y;
                    mapArray.Initialize();
                    i++;
                    j = 0;
                }
            }
            return maps;
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    if (mapVisible[i, j]) Console.Write(map[i][j] == '#' ? '\u2588' : map[i][j]);
                    else Console.Write('\u2592');
                }
                Console.Write('\n');
            }
        }
        public void DrawMcGuffin()
        {
            if (mapVisible[McGuffin[1], McGuffin[0]] && McGuffin[0] != 0 && McGuffin[1] != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(McGuffin[0], McGuffin[1]);
                Console.Write('¤');
            }
        }
        public bool CheckForMcGuffin(int x, int y)
        {
            return McGuffin[0] == x && McGuffin[1] == y ? true : false;
        }
        public void UpdateVisible(int x, int y)
        {
            int x1 = (x - 3) < 0 ? 0 : x - 3;
            int x2 = (x + 3) > mapVisible.GetUpperBound(1) ? mapVisible.GetUpperBound(1) : x + 3;
            int y1 = (y - 3) < 0 ? 0 : y - 3;
            int y2 = (y + 3) > mapVisible.GetUpperBound(0) ? mapVisible.GetUpperBound(0) : y + 3;
            for (int i = y1; i <= y2; i++)
            {
                for (int j = x1; j <= x2; j++)
                {
                    mapVisible[i, j] = true;
                }
            }
        }
    }
}
