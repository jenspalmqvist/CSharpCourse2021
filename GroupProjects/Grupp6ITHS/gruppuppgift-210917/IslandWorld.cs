using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppuppgift_210917
{
    public class IslandWorld
    {
        public IWorldObject[,] IslandMap { get; set; }

        public IslandWorld()
        {
            GenerateWorld();
        }

        public IslandWorld(object itemInfo)
        {
        }

        public void GenerateWorld()
        {
            var numOfTiles = 20;
            IslandMap = new IWorldObject[numOfTiles, numOfTiles];
            // Skapa island tiles
            for (int y = 0; y < IslandMap.GetLength(0); y++)
            {
                for (int x = 0; x < IslandMap.GetLength(1); x++)
                {
                    if (x == 0 || x == numOfTiles - 1 || y == 0 || y == numOfTiles - 1)
                    {
                        IslandMap[y, x] = new WaterTile();
                    }
                    else if (x == 1 || x == numOfTiles - 2 || y == 1 || y == numOfTiles - 2)
                    {
                        IslandMap[y, x] = new WaterTile();
                    }
                    else
                    {
                        IslandMap[y, x] = new IslandTile();
                    }
                }
            }
            // Skapa båt
            (int, int)[] boatTiles = new (int, int)[]{(0, 3), (0, 4), (0, 5),
                                                      (1, 3), (1, 4), (1, 5),
                                                      (2, 3), (2, 4), (2, 5),
                                                              (3, 4)};
            for (int i = 0; i < boatTiles.Length; i++)
            {
                var yPos = boatTiles[i].Item2;
                var xPos = boatTiles[i].Item1;
                IslandMap[yPos, xPos] = new BoatTile();
            }
            // Random place for Item
            Random rd = new Random();
            (int xPos, int yPos) randomPosForItem;
            do
            {
                randomPosForItem = (rd.Next(0, numOfTiles), rd.Next(0, numOfTiles));
            } while (!(IslandMap[randomPosForItem.xPos, randomPosForItem.yPos] is IslandTile));

            (IslandMap[randomPosForItem.xPos, randomPosForItem.yPos] as IslandTile).AddItemInformation();
            IslandMap[randomPosForItem.xPos, randomPosForItem.yPos].BackgroundColor = ConsoleColor.Red;
        }
    }
}