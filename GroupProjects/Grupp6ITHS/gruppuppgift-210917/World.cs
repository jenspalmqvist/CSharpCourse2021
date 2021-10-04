using System;
using System.Linq;

namespace gruppuppgift_210917
{
    public class World
    {
        public IWorldObject[,] WorldMap { get; set; }
        public World() { }
        public World(int worldSize, int numberOfIslands)
        {
            GenerateWorld(worldSize, numberOfIslands);
        }

        public void GenerateWorld(int worldSize, int numberOfIslands)
        {
            WorldMap = new IWorldObject[worldSize, worldSize * 2];
            // Random positions for Islands
            Random rd = new Random();
            (int, int)[] RandomIslandPositions = new (int, int)[numberOfIslands];
            for (int i = 0; i < numberOfIslands; i++)
            {
                var tempPos = (rd.Next(0, worldSize), rd.Next(0, worldSize*2));
                if (!RandomIslandPositions.Contains(tempPos))
                {
                    RandomIslandPositions[i] = tempPos;
                } else i--;
            }
            // Place Islands at random position in array.
            foreach (var IslandPos in RandomIslandPositions)
            {
                WorldMap[IslandPos.Item1, IslandPos.Item2] = new Island();
            }
            // Place Ocean where there are no Islands.
            for (int y = 0; y < WorldMap.GetLength(0); y++)
            {
                for (int x = 0; x < WorldMap.GetLength(1); x++)
                {
                    if (WorldMap[y, x] is not Island)
                    {
                        WorldMap[y, x] = new Ocean();
                    }
                }
            }
        }

    }
}