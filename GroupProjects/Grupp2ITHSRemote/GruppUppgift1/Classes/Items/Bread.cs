using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public class Bread : Item, IEdible
    {
        public int HealingValue { get; set; }

        public Bread()
        {
            Random random = new Random();

            ItemName = "Bread";
            SatchelSlotsRequired = 2;
            UsesLeft = random.Next(1, 4);
            HealingValue = random.Next(5, 9);
        }

        public void Heal(Player player)
        {
            player.CurrentHealth += HealingValue;
            if (player.CurrentHealth > player.MaxHealth)
                player.CurrentHealth = player.MaxHealth;
            UsesLeft -= 1;

            if (UsesLeft <= 0)
            {
                player.Inventory.itemsInSatchel.Remove(this);
                player.Inventory.SatchelSlotsCurrentlyOccupied -= SatchelSlotsRequired;
            }
        }

        public override string ToString()
        {
            return $"\t-- {ItemName} --\n" +
                $"Healing value: {HealingValue}\n" +
                $"Satchel Slots: {SatchelSlotsRequired}";
        }
    }
}
