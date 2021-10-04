using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppuppgift_210917
{
    static public class DrawWorld
    {
        static public string LastItemStory = " With the treasure map you shall be able to find \n| the metal detector so you can locate the key";
        static public IWorldObject[,] WorldToDraw;
        static public World MainWorld { get; set; }

        static public void DrawGameWorld(Player player, IWorldObject[,] map)
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.BackgroundColor = map[row, col].BackgroundColor;

                    if (player.Xpos == row && player.Ypos == col)
                    {
                        Console.ForegroundColor = player.PlayerColor;
                        Console.Write(player.PlayerSymbol);
                    }
                    else
                        Console.Write(' ');
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        private static void DrawBox()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(" ________________________________________________________________");
            Console.SetCursorPosition(65, 21);
            Console.Write("|");
            Console.SetCursorPosition(65, 22);
            Console.Write("|");
            Console.SetCursorPosition(65, 23);
            Console.Write("|");
            Console.SetCursorPosition(65, 24);
            Console.Write("|");
            Console.SetCursorPosition(65, 25);
            Console.WriteLine("|");
            Console.SetCursorPosition(0, 21);
            Console.Write("|");
            Console.SetCursorPosition(0, 22);
            Console.Write("|");
            Console.SetCursorPosition(0, 23);
            Console.Write("|");
            Console.SetCursorPosition(0, 24);
            Console.Write("|");
            Console.SetCursorPosition(0, 25);
            Console.Write("|");
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("|________________________________________________________________|");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine(" ________________________________________________________________");
            Console.SetCursorPosition(65, 28);
            Console.Write("|");
            Console.SetCursorPosition(65, 29);
            Console.Write("|");
            Console.SetCursorPosition(65, 30);
            Console.Write("|");
            Console.SetCursorPosition(65, 31);
            Console.Write("|");
            Console.SetCursorPosition(65, 32);
            Console.Write("|");
            Console.SetCursorPosition(65, 33);
            Console.WriteLine("|");
            Console.SetCursorPosition(0, 28);
            Console.Write("|");
            Console.SetCursorPosition(0, 29);
            Console.Write("|");
            Console.SetCursorPosition(0, 30);
            Console.Write("|");
            Console.SetCursorPosition(0, 31);
            Console.Write("|");
            Console.SetCursorPosition(0, 32);
            Console.Write("|");
            Console.SetCursorPosition(0, 33);
            Console.Write("|");
            Console.SetCursorPosition(0, 34);
            Console.WriteLine("|________________________________________________________________|");
        }
        public static bool DrawMessages(Player player, IWorldObject[,] map)
        {
            DrawBox();
            Console.SetCursorPosition(1, 23);
            Console.WriteLine(" Location: " + map[player.Xpos, player.Ypos].InformationAboutObject + "");
            Console.SetCursorPosition(1, 28);
            Console.WriteLine(" Quest log: ");

            //if (map[player.Xpos, player.Ypos] is Ocean)
            {
                Console.SetCursorPosition(1, 30);
                Console.WriteLine(LastItemStory);
            }
            if (map[player.Xpos, player.Ypos].Item != null && map[player.Xpos, player.Ypos] is IslandTile)
            {
                Console.SetCursorPosition(1, 24);
                Console.WriteLine($" The island contains a {map[player.Xpos, player.Ypos].Item}.");
                Console.SetCursorPosition(1, 25);
                Console.WriteLine($" To get the item you need a " +
                    $"{map[player.Xpos, player.Ypos].RequestedItem}.");

                if (IfPlayerHasRequestedItem(player))
                {
                    Console.SetCursorPosition(1, 25);
                    Console.WriteLine($"                                                              ");
                    Console.SetCursorPosition(1, 25);
                    Console.WriteLine($" Press <Enter> to pick up the item.");
                    if (player.PlayerInput == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(1, 30);
                        AddItemToPlayer(player);
                        player.ClearInput();
                        //return true if world changes
                        return true;
                    }
                }
                
            }
            if (map[player.Xpos, player.Ypos] is Island)
            {
                Console.SetCursorPosition(1, 24);
                Console.WriteLine(" Do you want to <Enter> the island?");
                if (player.PlayerInput == ConsoleKey.Enter)
                {

                    var convertToIsland = map[player.Xpos, player.Ypos] as Island;
                    // Spara dessa värden innan reset
                    player.WorldXpos = player.Xpos;
                    player.WorldYpos = player.Ypos;
                    // Sätt player pos så man spawnar på båten.
                    player.Xpos = 4;
                    player.Ypos = 2;
                    // Byt världen till Island
                    ChooseWorld(player, convertToIsland.IslandMap.IslandMap);
                    Console.Clear();
                    //return true if world changes
                    return true;
                }

            }
            // If player is on their boat they can go back to main world
            else if (map[player.Xpos, player.Ypos] is BoatTile)
            {
                Console.SetCursorPosition(1, 24);
                Console.WriteLine(" Press <Enter> to return back to the ocean.");
                if (player.PlayerInput == ConsoleKey.Enter)
                {
                    player.Xpos = player.WorldXpos;
                    player.Ypos = player.WorldYpos;
                    ChooseWorld(player, MainWorld.WorldMap);
                    return true;
                }
            }
            // return false if world stays the same
            return false;


        }
        static public bool IfPlayerHasRequestedItem(Player player)
        {
            if (player.Inventory.Contains(WorldToDraw[player.Xpos, player.Ypos].RequestedItem) &&
                !player.Inventory.Contains(WorldToDraw[player.Xpos, player.Ypos].Item))
            {
                return true;
            }
            else return false;
        }
        static public void AddItemToPlayer(Player player)
        {
            if (player.Inventory.Contains(WorldToDraw[player.Xpos, player.Ypos].RequestedItem) &&
                !player.Inventory.Contains(WorldToDraw[player.Xpos, player.Ypos].Item))
            {
                Console.WriteLine(WorldToDraw[player.Xpos, player.Ypos].MessageForRequestedItem);
                player.Inventory.Add(WorldToDraw[player.Xpos, player.Ypos].Item);
                DrawWorld.LastItemStory = WorldToDraw[player.Xpos, player.Ypos].MessageForRequestedItem;
                WorldToDraw[player.Xpos, player.Ypos] = new IslandTile();
            }
        }
        public static void ChooseWorld(Player player, IWorldObject[,] map)
        {
            player.ClearInput();

            WorldToDraw = map;
        }


    }
}
