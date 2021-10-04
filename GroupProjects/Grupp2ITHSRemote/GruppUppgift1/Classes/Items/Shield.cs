using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public class Shield : Item, IEquipable
    {
        public EquipableItems ItemType { get; set; }
        public int Defense { get; set; }

        public Shield(string itemName, int satchelSlotsRequired, int defense, int durability, ConsoleColor color)
        {
            ItemType = EquipableItems.Shield;
            ItemName = itemName;
            SatchelSlotsRequired = satchelSlotsRequired;
            Defense = defense;
            UsesLeft = durability;
            Color = color;
        }

        public override string ToString()
        {
            return $"{ItemName} | Defense: {Defense} | Durability: {UsesLeft}";
        }
    }
}
