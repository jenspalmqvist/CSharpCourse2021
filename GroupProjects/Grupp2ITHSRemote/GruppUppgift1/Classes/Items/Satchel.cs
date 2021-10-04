using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public class Satchel
    {
        public List<Item> itemsInSatchel;
        public List<Key> keyChain;
        public int SatchelSize { get; set; }
        public int SatchelSlotsCurrentlyOccupied { get; set; }
        public Player Owner { get; set; }

        public Satchel(int satchelSize, Player owner)
        {
            SatchelSize = satchelSize;
            itemsInSatchel = new List<Item>();
            keyChain = new List<Key>();
            Owner = owner;
        }

        public void AddKey(Key key)
        {
            keyChain.Add(key);
        }

        public void DropKey(Key key)
        {
            keyChain.Remove(key);
            //Owner.Inventory.SatchelSlotsCurrentlyOccupied -= key.SatchelSlotsRequired;
        }

        public void AddItem(Item item)
        {
            itemsInSatchel.Add(item);
            SatchelSlotsCurrentlyOccupied += item.SatchelSlotsRequired;
        }

        public void DropItem(Item item)
        {
            itemsInSatchel.Remove(item);
            Owner.Inventory.SatchelSlotsCurrentlyOccupied -= item.SatchelSlotsRequired;
        }

        public void EquipmentMenu(Item item)
        {
            if (item is Shield)
                ShieldMenu((Shield)item);
            else if (item is Weapon)
                WeaponMenu((Weapon)item);
            else
                return;

            Console.SetCursorPosition(20, 10);
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void ItemMenu(Item item)
        {
            if (item is IEdible)
                IEdibleItemMenu(item);
            else if (item is IEquipable)
                IEquipableItemMenu(item);
            else
                return;

            Console.SetCursorPosition(20, 10);
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void WeaponMenu(Weapon weapon)
        {
            bool validChoice = false;

            Console.Clear();
            Console.WriteLine("1. Unequip weapon\n" +
                "2. Drop weapon\n" +
                "\n" +
                "0. Return to equipment menu");

            var choice = Console.ReadKey(true).Key;

            while (!validChoice)
            {
                switch (choice)
                {
                    case ConsoleKey.D1:
                        Owner.UnequipItem(weapon, false);
                        EventDialogBox.Print($"{weapon.ItemName} was unequiped and placed in your inventory");
                        validChoice = true;
                        break;
                    case ConsoleKey.D2:
                        Owner.UnequipItem(weapon, true);
                        EventDialogBox.Print($"{weapon.ItemName} was dropped");
                        validChoice = true;
                        break;
                    case ConsoleKey.D0:
                        return;
                    default:
                        break;
                }
            }
        }

        public void ShieldMenu(Shield shield)
        {
            bool validChoice = false;

            Console.Clear();
            Console.WriteLine("1. Unequip shield\n" +
                "2. Drop shield\n" +
                "\n" +
                "0. Return to equipment menu");

            var choice = Console.ReadKey(true).Key;

            while (!validChoice)
            {
                switch (choice)
                {
                    case ConsoleKey.D1:
                        Owner.UnequipItem(shield, false);
                        EventDialogBox.Print($"{shield.ItemName} was unequiped and placed in your inventory");
                        validChoice = true;
                        break;
                    case ConsoleKey.D2:
                        Owner.UnequipItem(shield, true);
                        EventDialogBox.Print($"{shield.ItemName} was dropped");
                        validChoice = true;
                        break;
                    case ConsoleKey.D0:
                        return;
                    default:
                        break;
                }
            }
        }

        private void IEquipableItemMenu(Item item)
        {
            IEquipable equipableItem = (IEquipable)item;
            bool validChoice = false;

            Console.Clear();
            Console.WriteLine("1. Equip item\n" +
                "2. Drop item\n" +
                "\n" +
                "0. Return to inventory");

            var choice = Console.ReadKey(true).Key;

            while (!validChoice)
            {
                switch (choice)
                {
                    case ConsoleKey.D0:
                        return;
                    case ConsoleKey.D1:
                        Owner.EquipItem(equipableItem);
                        validChoice = true;
                        break;
                    case ConsoleKey.D2:
                        DropItem(item);
                        EventDialogBox.Print($"{item.ItemName} was dropped");
                        validChoice = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void IEdibleItemMenu(Item item)
        {
            IEdible edibleItem = (IEdible)item;
            bool validChoice = false;

            Console.Clear();
            Console.WriteLine("1. Eat item (Heal)\n" +
                "2. Drop item\n" +
                "\n" +
                "0. Return to inventory");

            var choice = Console.ReadKey(true).Key;
            while (!validChoice)
            {
                switch (choice)
                {
                    case ConsoleKey.D0:
                        return;
                    case ConsoleKey.D1:
                        Owner.EatItem(edibleItem);
                        validChoice = true;
                        break;
                    case ConsoleKey.D2:
                        DropItem(item);
                        EventDialogBox.Print($"{item.ItemName} was dropped");
                        validChoice = true;
                        break;
                }
            }
        }
    }
}
