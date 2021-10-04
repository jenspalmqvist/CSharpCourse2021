using System;
using System.Collections.Generic;
using System.Linq;

namespace gruppuppgift_210917
{
    public class Player : IWorldPos
    {
        public List<string> Inventory { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        // World pos saves x and y pos for overworld when entering islands.
        public int WorldXpos { get; set; }
        public int WorldYpos { get; set; }
        public string Name { get; set; }
        public char PlayerSymbol { get; set; }
        public bool IsInIsland { get; set; }
        public ConsoleColor PlayerColor { get; set; }
        public ConsoleKey PlayerInput { get; set; }

        public Player(int startX, int startY)
        {
            Xpos = startX;
            Ypos = startY;
            PlayerSymbol = '¤';
            PlayerColor = ConsoleColor.White;
            Inventory = new List<string>() { "Treasure Map" };
        }

        internal void ClearInput()
        {
            this.PlayerInput = ConsoleKey.NoName;
        }

        public void DrawInventory()
        {
            Console.SetCursorPosition(1, 21);
            Console.WriteLine(" Inventory: ");

            if (Inventory == null)
            {
                Console.WriteLine("No items.\n");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    if (item == Inventory.ElementAt(0))
                    {
                        Console.Write(" ");
                    }
                    Console.Write($" {item},");
                }
            }
            Console.WriteLine();
        }

        public bool IsPositionInsideMap(int worldSize, int x, int y)
        {
            if (x < 0 || y < 0 || x >= worldSize || y >= worldSize * 2)
            {
                return false;
            }
            if (DrawWorld.WorldToDraw[x, y] is WaterTile)
            {
                return false;
            }

            return true;
        }
        public ConsoleKey GetKeyFromPlayer()
        {
            return Console.ReadKey(true).Key;
        }

        public void MovePlayer(int worldSize)
        {
            switch (PlayerInput)
            {
                case ConsoleKey.UpArrow:
                    if (IsPositionInsideMap(worldSize, Xpos - 1, Ypos))
                    {
                        Xpos -= 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (IsPositionInsideMap(worldSize, Xpos + 1, Ypos))
                    {
                        Xpos += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (IsPositionInsideMap(worldSize, Xpos, Ypos - 1))
                    {
                        Ypos -= 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (IsPositionInsideMap(worldSize, Xpos, Ypos + 1))
                    {
                        Ypos += 1;
                    }
                    break;

                case ConsoleKey.Escape:
                    {
                        
                        {
                            int curserPos = 21;
                            for (int i = 0; i < 4; i++)
                            {
                                Console.SetCursorPosition(1, curserPos);
                                Console.WriteLine("                                                             ");
                                curserPos++;
                            }
                            
                            Console.SetCursorPosition(18, 23);
                            Console.WriteLine("Are you sure [Enter]");
                            var newKey = Console.ReadKey().Key;
                            if (newKey == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Environment.Exit(0);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        }
                    }

                

                default:
                    break;
            }
        }
    }
}