using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public class Weapon : Item, IEquipable
    {
        public EquipableItems ItemType { get; set; }
        public int Damage { get; set; }

        public Weapon(string itemName, int satchelSlotsRequired, int damage, int durability, ConsoleColor color)
        {
            ItemType = EquipableItems.Weapon;
            ItemName = itemName;
            SatchelSlotsRequired = satchelSlotsRequired;
            Damage = damage;
            UsesLeft = durability;
            ItemChar = '$';
            Color = color;
        }

        public override string ToString()
        {
            return $"{ItemName} | Damage: {Damage} | Durability: {UsesLeft}";
        }
    }
}
