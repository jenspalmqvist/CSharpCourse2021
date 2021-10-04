using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GruppUppgift1
{
    class MapLoot
    {
        public List<Item> ItemsOnGround { get; set; } = new List<Item>();
        public List<Key> KeysOnGround { get; set; }
        public List<Item> LootTable { get; set; } = new List<Item>() { 
                                                    new Weapon("Tiny Paperknife", 1, 5, 10, ConsoleColor.DarkGray),
                                                    new Weapon("Heavy Mace", 4, 15, 100, ConsoleColor.Green),
                                                    new Weapon("Shiny Sword", 2, 25, 50, ConsoleColor.Magenta)
        };

    public MapLoot()
        {
            
        }
        public MapLoot(List<Item> items, List<Key> keys)
        {
            ItemsOnGround = items;
            KeysOnGround = keys;
        }
        public MapLoot(List<Item> items)
        {
            ItemsOnGround = items;
        }
        public MapLoot(List<Key> keys)
        {
            KeysOnGround = keys;
        }
        public void Spawn(List<Map> maps, int mapIndex) // Bestämd lootpool.
        {
            Random rnd = new Random();
            int x, y;
            ItemsOnGround.Clear();
            foreach (Item item in LootTable)
            {
                ItemsOnGround.Add(item);
            }
            for (int i = 0; i < ItemsOnGround.Count; i++)
            {
                do
                {
                    x = rnd.Next(0, maps[mapIndex].map[0].Length);
                    y = rnd.Next(0, maps[mapIndex].map.Length);

                } while (maps[mapIndex].map[y][x] != ' ' && !ItemsOnGround.Exists(item => item.PosX == x && item.PosY == y));

                ItemsOnGround[i].PosX = x;
                ItemsOnGround[i].PosY = y;
            }
        }
        public void Spawn(List<Map> maps, int mapIndex, int nrOfItemsPerMap) // Random lootpool.
        {
            Random rnd = new Random();
            int x, y;
            string[] prefixes = { "Great", "Small", "Big", "Medium", "Rusty" };
            string[] suffixes = { "Sword", "Dagger", "Mace", "Staff", "Axe" };
            ItemsOnGround.Clear();
            for (int i = 0; i < nrOfItemsPerMap; i++)
            {
                do
                {
                    x = rnd.Next(0, maps[mapIndex].map[0].Length);
                    y = rnd.Next(0, maps[mapIndex].map.Length);

                } while (maps[mapIndex].map[y][x] != ' ' && !ItemsOnGround.Exists(item => item.PosX == x && item.PosY == y));

                ItemsOnGround.Add(new Weapon(prefixes[rnd.Next(0, prefixes.Length)] + " " + suffixes[rnd.Next(0, prefixes.Length)], 1, rnd.Next(5, 20), rnd.Next(50, 150), ConsoleColor.Blue));
                ItemsOnGround[i].PosX = x;
                ItemsOnGround[i].PosY = y;
                if (ItemsOnGround[i].ItemName.StartsWith("Rusty"))
                {
                    ItemsOnGround[i].Color = ConsoleColor.DarkGray;
                }
                if (ItemsOnGround[i].ItemName.StartsWith("Small"))
                {
                    ItemsOnGround[i].Color = ConsoleColor.Green;
                }
                if (ItemsOnGround[i].ItemName.StartsWith("Medium"))
                {
                    ItemsOnGround[i].Color = ConsoleColor.Blue;
                }
                if (ItemsOnGround[i].ItemName.StartsWith("Big"))
                {
                    ItemsOnGround[i].Color = ConsoleColor.Magenta;
                }
                if (ItemsOnGround[i].ItemName.StartsWith("Great"))
                {
                    ItemsOnGround[i].Color = ConsoleColor.DarkYellow;
                }
            }
        }
        public void Run(Player player, Map map)
        {
            for (int i = 0; i < ItemsOnGround.Count; i++)
            {
                ItemsOnGround[i].Draw(map);

                if (player.PositionX == ItemsOnGround[i].PosX && player.PositionY == ItemsOnGround[i].PosY)
                {
                    player.Inventory.AddItem(ItemsOnGround[i]);
                    PrintDialog(player.PositionX + 1, player.PositionY - 1, $"You found a {ItemsOnGround[i].ItemName}!", ItemsOnGround[i].Color, false, map);
                    RemoveFromGround(i);
                    i--; // För att inte hamna fel i loopen när vi tar bort ett index.
                }
            }
        }
        public void RemoveFromGround(int index)
        {
            ItemsOnGround.RemoveAt(index);
        }
        public void PrintDialog(int posX, int posY, string msg, ConsoleColor color, bool border, Map map)
        {
            Dialog d = new Dialog(posX, posY, msg, color, border, map);
            d.Print();
        }
    }
}