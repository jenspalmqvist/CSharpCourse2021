using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        public string Name { get; set; }
    }
    public class Fruit : Item, IEdible
    {
        public int HealthIncrease { get; set; }
        public int HungerIncrease { get; set; }
    }
    public class Stone : Item, IAttackable
    {
        public int Damage { get; set; }
    }
    public class Sword : Item, IAttackable
    {
        public int Damage { get; set; }
    }
    public class Berry : Item, IEdible
    {
        public int HealthIncrease { get; set; }
        public int HungerIncrease { get; set; }
    }
    public class PickAxe : Item, IAttackable
    {
        public int Damage { get; set; }
    }
    public class WoodenStick : Item, IAttackable
    {
        public int Damage { get; set; }
    }
}