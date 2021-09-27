using System;
using System.Collections.Generic;
using System.Text;

namespace Group1Game
{
    class Character : ICharacter
    {
        public string Name { get; set; }
        //public int MovingDistance { get; set; }
        public int Health { get; set; }
        public int MaxNumberOfItem { get; set; }
        public List<Item> InventoryOfItems { get; set; }
        public Character(string name, int health, int maxNumberOfItem)
        {
            Name = name;
           
            Health = health;
            MaxNumberOfItem = maxNumberOfItem;
        }

    }
}
