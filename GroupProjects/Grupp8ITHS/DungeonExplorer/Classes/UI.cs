using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class UI
    {
        public static string InterfaceInstructions = "Use the arrow keys to move, Spacebar to access Inventory, or Escape to give up and exit the game.";
        public static void RefreshMap()
        {
            ClearLinesBelowHud();
            ResetScreenPosition();
            DisplayMap(DrawVisibleMap());
            DisplayHUD();
        }
        private static void ClearLinesBelowHud()
        {
            for (int i = 29; i <= 40; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', 120));
            }
        }
        private static void ResetScreenPosition()
        {
            Console.SetCursorPosition(0, 0);
        }
        public static void DisplayMap(string[,] visibleMap)
        {
            for (int i = 0; i < Map.MapSizeY; i++)
            {
                for (int j = 0; j < Map.MapSizeX; j++)
                {
                    if (Move.PlayerPosition[0] == i && Move.PlayerPosition[1] == j)
                    {
                        Console.Write("¶");
                    }
                    else
                    {
                        Console.Write(visibleMap[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        private static string[,] DrawVisibleMap()
        {
            string[,] newTempMapVis = new string[Map.MapSizeY, Map.MapSizeX];
            for (int i = 0; i < Map.MapSizeY; i++)
            {
                for (int j = 0; j < Map.MapSizeX; j++)
                {
                    if (i == 0 || j == 0 || i == Map.MapSizeY - 1 || j == Map.MapSizeX - 1)
                    {
                        newTempMapVis[i, j] = Map.CaveMap[i, j];
                    }
                    else if (i == Move.PlayerPosition[0] - 2 || i == Move.PlayerPosition[0] - 1 || i == Move.PlayerPosition[0] || i == Move.PlayerPosition[0] + 1 || i == Move.PlayerPosition[0] + 2)
                    {
                        if (j == Move.PlayerPosition[1] - 2 || j == Move.PlayerPosition[1] - 1 || j == Move.PlayerPosition[1] || j == Move.PlayerPosition[1] + 1 || j == Move.PlayerPosition[1] + 2)
                        {
                            newTempMapVis[i, j] = Map.CaveMap[i, j];
                        }
                        else
                        {
                            newTempMapVis[i, j] = Map.EmptyMap[i, j];
                        }
                    }
                    else
                    {
                        newTempMapVis[i, j] = Map.EmptyMap[i, j];
                    }
                }
            }
            return newTempMapVis;
        }
        private static void DisplayHUD()
        {
            int spacingAfterHealth = 25 - Game.player.Health.ToString().Length;
            int spacingAfterHunger = 25 - (Game.player.Hunger).ToString().Length;
            Console.Write("          ");
            Console.Write($"HP: {Game.player.Health}");
            for (int i = 0; i < spacingAfterHealth; i++)
            {
                Console.Write(" ");
            }
            Console.Write($"Hunger Saturation: {Game.player.Hunger}%");
            for (int j = 0; j < spacingAfterHunger; j++)
            {
                Console.Write(" ");
            }
            Console.Write($"# of items in Inventory: {Game.player.Inventory.Count}");
            Console.WriteLine();
        }
    }
}