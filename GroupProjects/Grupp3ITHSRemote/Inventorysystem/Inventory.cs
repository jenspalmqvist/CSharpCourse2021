using System;
using System.Collections.Generic;

namespace Rollspel
{
    public static class Inventory
    {
        public static List<Item> ItemList = new List<Item>();

        public static int AnchorX { get; set; } = 64;
        public static int AnchorY { get; set; } = 1;
        public static int Width { get; set; } = 20;
        public static int Height { get; set; } = 20;

        public static List<Item> GetList()
        {
            return ItemList;
        }

        public static void PrintInventory()
        {
            Program.DrawEmpty(AnchorX + 1, AnchorY + 1, Width - 2, Height - 2);
            Program.DrawFrame(AnchorX, AnchorY, Width, Height);
            Console.SetCursorPosition(AnchorX + 5, AnchorY - 1);
            Console.WriteLine("Inventory");

            for (int i = 0; i < ItemList.Count; i++)
            {
                Console.SetCursorPosition(AnchorX + 1, AnchorY + i + 1);
                int index = i + 1;
                Console.WriteLine($"{index}. {ItemList[i].Name}");
            }
        }

        public static void AddToInventory(Item foundItem)
        {
            if (ItemList.Count < 6)
            {
                ItemList.Add(foundItem);
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 1);
                Console.WriteLine($"Lagt {foundItem.Name} i ryggsäcken!");
                PrintInventory();
            }
            else
            {
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 2);
                Console.WriteLine($"Du har redan {ItemList.Count} saker i din ryggsäck,");
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 3);
                Console.WriteLine($"du kan inte plocka upp fler.");
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 4);
                Console.WriteLine("Vill du kasta något annat?");
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 5);
                int answer = int.Parse(Console.ReadLine());
                if (answer == 1)
                {
                    SwitchItemInInventory(foundItem);
                }
                else
                {
                    Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 6);
                    Console.WriteLine("Prylen kastas i närmsta dike!");
                }
            }
        }

        public static void SwitchItemInInventory(Item newItem)
        {
            Program.DrawEmpty(InteractiveMenu.AnchorX, InteractiveMenu.AnchorY, InteractiveMenu.MenuWidth - 2, InteractiveMenu.MenuHeight - 2);
            Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 1);
            Console.WriteLine($"Vilken av sakerna i din ryggsäck vill du kasta? Ange rätt siffra.");
            Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 2);
            int itemToReplace = int.Parse(Console.ReadLine());

            if (itemToReplace > 0)
            {
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 3);
                Console.WriteLine($"{ItemList[itemToReplace - 1].Name} kastas i närmsta dike!");
                ItemList[itemToReplace - 1] = newItem;
                PrintInventory();
            }
            else
            {
                Console.SetCursorPosition(InteractiveMenu.AnchorX + 2, InteractiveMenu.AnchorY + 1);
                Console.WriteLine("Du måste ange en siffra mellan 1-6");
            }
        }

        public static void UseInventoryItem()
        {
            Console.SetCursorPosition(InteractiveMenu.AnchorX+1, InteractiveMenu.AnchorY);
            Console.WriteLine("Vilken av dina saker vill du hantera? Ange siffra för respektive objekt");
            Console.SetCursorPosition(InteractiveMenu.AnchorX + 1, InteractiveMenu.AnchorY+1); 
            int itemToHandle = int.Parse(Console.ReadLine());

            Item selectedItem;
            if (itemToHandle > 0)
            {

                //ItemList[itemToHandle - 1].Use();
                selectedItem = ItemList[itemToHandle - 1];

                if (selectedItem.Name == "Potatis")
                {
                    Console.SetCursorPosition(InteractiveMenu.AnchorX + 1, InteractiveMenu.AnchorY + 2);
                    InteractiveMenu potatisMeny = new InteractiveMenu("Vad vill du göra med potatisen?", InteractiveMenu.Uses.Kick);
                    Console.SetCursorPosition(InteractiveMenu.AnchorX + 1, InteractiveMenu.AnchorY + 3);
                    Console.WriteLine("Välj siffra för det alternativ du vill ha");
                    var dictionary = new Dictionary<string, InteractiveMenu.Uses> { { "Lägga ut den", InteractiveMenu.Uses.Kick } };
                    potatisMeny.PrintChoices(dictionary, selectedItem);

                }


            }
            else
            {
                Console.WriteLine("Du måste ange en siffra mellan 1-6");
            }
        }
    }
}