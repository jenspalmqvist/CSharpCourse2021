using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public class InventoryManager
    {
        public Game GameInstance { get; set; }
        public InventoryManager(Game gameInstance)
        {
            GameInstance = gameInstance;
        }
        public void EquipmentMenu(Player player)
        {
            bool equipmentPaneOpen = true;
            Console.Clear();

            while (equipmentPaneOpen)
            {
                Console.WriteLine($"(W)eapon: {player.EquipedWeapon}\n" +
                    $"(S)hield: {player.EquipedShield}\n" +
                    $"\n" +
                    $"0. Return to game");

                var choice = Console.ReadKey(true).Key;

                switch (choice)
                {
                    case ConsoleKey.S:
                        player.Inventory.EquipmentMenu(player.EquipedShield);
                        break;
                    case ConsoleKey.W:
                        player.Inventory.EquipmentMenu(player.EquipedWeapon);
                        break;
                    case ConsoleKey.D0:
                        Console.Clear();
                        GameInstance.UpdateGameField();
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        public void OpenInventory(Player player)
        {
            bool inventoryOpen = true;
            Console.Clear();

            while (inventoryOpen)
            {

                var inventory = player.Inventory;
                int choice;
                string pressedKey;

                if (inventory.itemsInSatchel.Count == 0)
                {
                    Console.WriteLine("Inventory is empty");
                    Console.SetCursorPosition(20, 10);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                    GameInstance.UpdateGameField();
                    return;
                }

                do
                {
                    Console.Clear();
                    Console.WriteLine("Inventory");
                    for (int i = 0; i < inventory.itemsInSatchel.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {inventory.itemsInSatchel[i].ItemName} | Durability/Uses left: {inventory.itemsInSatchel[i].UsesLeft}");
                    }
                    Console.WriteLine("\n0. Return to game");

                    Console.SetCursorPosition(50, 0);
                    Console.Write("Keychain");
                    for (int i = 0; i < inventory.keyChain.Count; i++)
                    {
                        Console.SetCursorPosition(50, 2 + i);
                        Console.Write((i + 1) + ". " + inventory.keyChain[i].Color + " key.");
                    }

                    var key = Console.ReadKey(true);
                    pressedKey = key.KeyChar + "";
                }
                while (!int.TryParse(pressedKey, out choice) || (choice < 0 || choice > inventory.itemsInSatchel.Count));

                if (choice == 0)
                {
                    Console.Clear();
                    GameInstance.UpdateGameField();
                    return;
                }
                else
                {
                    inventory.ItemMenu(inventory.itemsInSatchel[choice - 1]);
                }


                //if (inventory.itemsInSatchel.Count == 0)
                //{
                //    Console.WriteLine("Inventory is empty");
                //    Console.SetCursorPosition(20, 10);
                //    Console.Write("Press any key to continue...");
                //    Console.ReadKey(true);
                //    GameInstance.UpdateGameField();
                //    return;
                //}
                //Console.WriteLine("Inventory");

                //for (int i = 0; i < inventory.itemsInSatchel.Count; i++)
                //{
                //    Console.WriteLine($"{i + 1}: {inventory.itemsInSatchel[i].ItemName} | Durability/Uses left: {inventory.itemsInSatchel[i].UsesLeft}");
                //}

                //Console.WriteLine("\n0. Return to game");
                //var choice = Console.ReadKey(true).Key;


                //switch (choice)
                //{
                //    case ConsoleKey.D1:
                //        if (!ItemExist(1))
                //            break;
                //        inventory.ItemMenu(inventory.itemsInSatchel[0]);
                //        break;
                //    case ConsoleKey.D2:
                //        if (!ItemExist(2))
                //            break;
                //        inventory.ItemMenu(inventory.itemsInSatchel[1]);
                //        break;
                //    case ConsoleKey.D3:
                //        if (!ItemExist(3))
                //            break;
                //        inventory.ItemMenu(inventory.itemsInSatchel[2]);
                //        break;
                //    case ConsoleKey.D4:
                //        if (!ItemExist(4))
                //            break;
                //        inventory.ItemMenu(inventory.itemsInSatchel[3]);
                //        break;
                //    case ConsoleKey.D5:
                //        if (!ItemExist(5))
                //            break;
                //        inventory.ItemMenu(inventory.itemsInSatchel[4]);
                //        break;
                //    case ConsoleKey.D6:
                //        if (!ItemExist(6))
                //            break;
                //        inventory.ItemMenu(inventory.itemsInSatchel[5]);
                //        break;
                //    case ConsoleKey.D7:
                //        if (!ItemExist(7))
                //            break;
                //        break;
                //    case ConsoleKey.D8:
                //        if (!ItemExist(8))
                //            break;
                //        break;
                //    case ConsoleKey.D9:
                //        if (!ItemExist(9))
                //            break;
                //        break;
                //    case ConsoleKey.D0:
                //        Console.Clear();
                //        GameInstance.UpdateGameField();
                //        return;
                //    default:
                //        Console.Clear();
                //        break;
                //}
                //bool ItemExist(int index)
                //{
                //    index -= 1;
                //    if (index >= 0 && index < inventory.itemsInSatchel.Count)
                //    {
                //        return true;
                //    }
                //    return false;
                //}
            }
        }
    }
}
