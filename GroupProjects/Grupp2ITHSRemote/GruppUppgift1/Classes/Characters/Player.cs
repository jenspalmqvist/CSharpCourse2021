using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GruppUppgift1
{
    public class Player : Character
    {
        //Starting values initialized in constructor
        const int STARTING_MAX_HP = 15;
        const int STARTING_DMG = 4;
        const int STARTING_SATCHEL_SIZE = 20;
        const int STARTING_ATTACKSKILL = 8;
        const int STARTING_DEFENSESKILL = 7;
        const int STARTING_DEFENSE = 1;

        public Weapon EquipedWeapon { get; set; }
        public Shield EquipedShield { get; set; }
        public Satchel Inventory { get; set; }
        public bool HasWeaponEquiped { get; set; }
        public bool HasShieldEquiped { get; set; }
        public int McGuffinCounter { get; set; }

        private char playerChar = '@';

        public Player()
        {
            MaxHealth = STARTING_MAX_HP;
            CurrentHealth = MaxHealth;
            Damage = STARTING_DMG;
            AttackSkill = STARTING_ATTACKSKILL;
            DefenseSkill = STARTING_DEFENSESKILL;
            Defense = STARTING_DEFENSE;
            Name = "You";
            Inventory = new Satchel(STARTING_SATCHEL_SIZE, this);
            HasWeaponEquiped = false;
            HasShieldEquiped = false;
            McGuffinCounter = 0;
            Inventory.AddItem(new Weapon("Rake", 3, 5, 10, ConsoleColor.DarkGray));
            Inventory.AddItem(new Shield("Barn door", 3, 3, 10, ConsoleColor.Red));
            Inventory.AddItem(new Weapon("Chair leg", 3, 5, 10, ConsoleColor.DarkYellow));
            Inventory.AddItem(new Bread());
        }

        public void DrawPlayerCharacter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(playerChar);
        }
        public void Move(int xDirection, int yDirection, Map map)
        {
            PositionX += xDirection; PositionY += yDirection;
            map.UpdateVisible(PositionX, PositionY);
            if (map.CheckForMcGuffin(PositionX, PositionY))
            {
                McGuffinCounter++;
                map.McGuffin[0] = 0;
                map.McGuffin[1] = 0;
            }
        }
        public void EatItem(IEdible edibleItem)
        {
            if (CurrentHealth == MaxHealth)
                EventDialogBox.Print("You are already at max health");
            else
            {
                edibleItem.Heal(this);
                var item = (Item)edibleItem;
                EventDialogBox.Print($"You eat {item.ItemName}, it heals you for {edibleItem.HealingValue}");
            }
        }
        public void EquipItem(IEquipable equipableItem)
        {
            if (equipableItem.ItemType == EquipableItems.Weapon)
            {
                if (!HasWeaponEquiped)
                {
                    EquipedWeapon = (Weapon)equipableItem;
                    Damage += EquipedWeapon.Damage;
                    HasWeaponEquiped = true;
                    Inventory.SatchelSlotsCurrentlyOccupied -= EquipedWeapon.SatchelSlotsRequired;
                    Inventory.itemsInSatchel.Remove(EquipedWeapon);
                    EventDialogBox.Print($"You equiped a {EquipedWeapon.ItemName}");
                }
                else
                {
                    EventDialogBox.Print("You already have a weapon equiped");
                }
            }

            if (equipableItem.ItemType == EquipableItems.Shield)
            {
                if (!HasShieldEquiped)
                {
                    EquipedShield = (Shield)equipableItem;
                    Defense += EquipedShield.Defense;
                    HasShieldEquiped = true;
                    Inventory.SatchelSlotsCurrentlyOccupied -= EquipedShield.SatchelSlotsRequired;
                    Inventory.itemsInSatchel.Remove(EquipedShield);
                    EventDialogBox.Print($"You equiped a {EquipedShield.ItemName}");
                }
                else
                {
                    EventDialogBox.Print("You already have a shield equiped");
                }
            }
        }

        public void UnequipItem(IEquipable equipableItem, bool dropItem)
        {
            var item = (Item)equipableItem;
            if (item.SatchelSlotsRequired + Inventory.SatchelSlotsCurrentlyOccupied <= Inventory.SatchelSize)
            {
                if (equipableItem.ItemType == EquipableItems.Weapon)
                {
                    var weapon = (Weapon)equipableItem;
                    if (dropItem)
                    {
                        Damage -= weapon.Damage;
                        EquipedWeapon = null;
                        HasWeaponEquiped = false;
                    }
                    else
                    {
                        Inventory.AddItem(weapon);
                        Inventory.SatchelSlotsCurrentlyOccupied += weapon.SatchelSlotsRequired;
                        Damage -= weapon.Damage;
                        HasWeaponEquiped = false;
                        EquipedWeapon = null;
                    }
                }
                else if (equipableItem.ItemType == EquipableItems.Shield)
                {
                    var shield = (Shield)equipableItem;
                    if (dropItem)
                    {
                        Defense -= shield.Defense;
                        HasShieldEquiped = false;
                        EquipedShield = null;
                    }
                    else
                    {
                        Inventory.AddItem(shield);
                        Inventory.SatchelSlotsCurrentlyOccupied += shield.SatchelSlotsRequired;
                        Defense -= shield.Defense;
                        HasShieldEquiped = false;
                        EquipedShield = null;
                    }
                }
            }
            else
            {
                EventDialogBox.Print("You dont have enough room in your inventory");
            }

            
        }

        public void LootEnemy(Item loot)
        {
            if (loot.SatchelSlotsRequired + Inventory.SatchelSlotsCurrentlyOccupied <= Inventory.SatchelSize)
            {
                EventDialogBox.Print($"Enemy died\nYou loot {loot.ItemName}");
                Console.ReadKey(true);
                EventDialogBox.Clear();

                Inventory.AddItem(loot);
                Inventory.SatchelSlotsCurrentlyOccupied += loot.SatchelSlotsRequired;
                if (loot is IEquipable)
                {
                    EventDialogBox.Print($"Would you like to equip {loot.ItemName}? (Y/N)");
                    var choice = Console.ReadKey(true).Key;
                    bool validChoice = false;

                    while (!validChoice)
                    {
                        switch (choice)
                        {

                            case ConsoleKey.N:
                                validChoice = true;
                                break;
                            case ConsoleKey.Y:
                                EquipItem((IEquipable)loot);
                                validChoice = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    EventDialogBox.Print("Item was added to your inventory.");
                    Console.ReadKey(true);
                    EventDialogBox.Clear();
                }
                
            }
            else
            {
                EventDialogBox.Print("You can not carry any more items");
                Console.ReadKey(true);
                EventDialogBox.Clear();
            }
        }

        public Enemy AttackInstantKill(List<Enemy> enemies, Player player) // Tillfällig attack för att inte fastna i monster.
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].PositionX == player.PositionX - 1 ||
                    enemies[i].PositionY == player.PositionY - 1 ||
                    enemies[i].PositionX == player.PositionX + 1 ||
                    enemies[i].PositionY == player.PositionY + 1)
                {
                    enemies[i].CurrentHealth = 0;
                    return enemies[i];
                }
            }
            return null;
        }
    }
}
