using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Player character class
    /// </summary>
    internal class PlayerCharacter : Character
    {
        private List<Equipment> Inventory;
        public int EquippedSlot { get; set; }

        public const int MaxInventorySize = 5;

        public PlayerCharacter(int x, int y, DungeonMap map, char representation) : base(x, y, map)
        {
            Representation = representation;
            Inventory = new List<Equipment>();

            EquippedSlot = 0;

            // starting equipment
            Inventory.Add(new Equipment("shovel"));
            Inventory.Add(new Equipment("potion"));
        }

        public override void NextAction()
        {
        }

        /// <summary>
        /// Move function for player
        /// </summary>
        public override (int x, int y) Move(char direction)
        {
            var nextPosition = map.GetMoveTargetCoordinates(PositionX, PositionY, direction);

            var dynamic = map.GetDynamic(nextPosition.x, nextPosition.y);

            if (dynamic != null)
            {
                if (dynamic is NonPlayerCharacter)
                {
                    int damage = 10; // default damage

                    if (Inventory[EquippedSlot] != null)
                        damage = Inventory[EquippedSlot].Damage;

                    if (damage != 0)
                    {
                        ((NonPlayerCharacter)dynamic).Damage(damage);
                        return (PositionX, PositionY);
                    }
                }
                if (dynamic is Equipment)   // pick up equipment
                {
                    if (Inventory.Count == MaxInventorySize)
                    {
                        return nextPosition;
                    }

                    Inventory.Add((Equipment)dynamic);
                    map.RemoveDynamic(nextPosition.x, nextPosition.y);
                }
                if (dynamic is CoinItem)   // pick up equipment
                {
                    AddCoins(((CoinItem)dynamic).Value);
                    map.RemoveDynamic(nextPosition.x, nextPosition.y);
                }
            }

            (int newX, int newY) = map.Move(PositionX, PositionY, nextPosition.x, nextPosition.y);

            return (newX, newY);
        }

        /// <summary>
        /// Returns StatusString to display on screen during gameplay 
        /// </summary>
        public string GetStatusString()
        {
            string attackDamage = "10"; // Default damage.

            if (Inventory.Count > EquippedSlot && Inventory[EquippedSlot] != null)
                attackDamage = Inventory[EquippedSlot].Damage.ToString();
            return $"HP: {Health}/{MaxHealth}, Attack: {attackDamage}, Gold($): {CoinPurse}.";
        }

        /// <summary>
        /// Gets a string of players inventory, for display during gameplay
        /// </summary>
        public string GetInventoryString()
        {
            var stringBuilder = new StringBuilder();

            const int Spacing = 8;

            for (int i = 0; i < MaxInventorySize; i++)
            {
                string name = new string(' ', Spacing);

                if (i < Inventory.Count)
                {
                    var item = Inventory[i];

                    if (item != null)
                    {
                        name = item.Name + name;
                        name = name.Substring(0, Spacing);
                    }
                }

                if (i == EquippedSlot)
                {
                    stringBuilder.Append($"{i + 1}.>{name} ");
                }
                else
                {
                    stringBuilder.Append($"{i + 1}. {name} ");
                }
            }

            return stringBuilder.ToString();
        }



        /// <summary>
        /// Use object in inventory. Returns true if object was consumed
        /// </summary>
        public bool HandleInput(char input)
        {
            if (int.TryParse("" + input, out int i))
            {
                if (i >= 1 && i <= Inventory.Count)
                {
                    EquippedSlot = i - 1;
                    return true;
                }
            }

            if (input == 'u')
            {
                if (EquippedSlot >= Inventory.Count)
                    return false;

                if (Inventory[EquippedSlot] == null)
                    return false;

                if (Inventory[EquippedSlot].Heal > 0)
                {
                    Health += Inventory[EquippedSlot].Heal;
                    Inventory.RemoveAt(EquippedSlot);
                    EquippedSlot = 0;   
                    return true;
                }
            }

            return false;
        }
    }
}