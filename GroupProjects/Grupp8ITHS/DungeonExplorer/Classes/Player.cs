using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Player //Madde
    {
        private int moves;
        private int health;
        public string Name { get; set; }
        public int BaseDamage { get; set; }
        public int Hunger { get; set; }
        public List<Item> Inventory { get; set; }
        public int Health
        {
            get => health; set
            {
                health = value;
                OnHealthChange?.Invoke(this, Health);
            }
        }
        public int Moves
        {
            get => moves; set
            {
                moves = value;
                OnMoveChange?.Invoke(this, Moves);
            }
        }
        public Player(string name)
        {
            Name = name;
            Health = 100;
            BaseDamage = 10;
            Hunger = 100;
            Moves = 0;
            Inventory = new List<Item>();
            OnHealthChange += PlayerDead;
            OnMoveChange += PlayerHungerAndHealthDecrease;
            OnMoveChange += PlayerChanceToGetLootOrFight;
        }
        private event EventHandler<int> OnMoveChange;
        private event EventHandler<int> OnHealthChange;
        private void PlayerDead(object sender, int health)
        {
            var player = (Player)sender;
            if (player.Health <= 0)
            {
                Game.GameInProgress[0] = false;
            }
        }
        private void PlayerHungerAndHealthDecrease(object sender, int health)
        {
            var player = (Player)sender;

            if (player.Hunger <= 0)
            {
                player.Health -= 1;
            }
            else
            {
                player.Hunger -= 1;
            }
        }
        private void PlayerChanceToGetLootOrFight(object sender, int e)
        {
            var player = (Player)sender;
            Random r = new Random();
            if (player.moves % 15 == 0 && r.Next(0, 5) == 2)
            {
                Fight.Fights();
            }
            else if (player.moves % 10 == 0 && r.Next(0, 5) == 2)
            {
                AddToInventory();
                if (Inventory[Inventory.Count - 1] is IAttackable)
                {
                    BaseDamage += (Inventory[Inventory.Count - 1] as IAttackable).Damage;
                }
            }
        }
        public void AddToInventory()
        {
            Random random = new Random();
            Inventory.Add(Game.ItemList[random.Next(Game.ItemList.Count)]);
            Console.WriteLine($"You found one {Inventory[Inventory.Count - 1].Name}                                                                                         ");

        }
        public void DisplayInventory()
        {
            List<Item> attackable = new List<Item>();
            List<Item> edible = new List<Item>();
            int itemCounter = 0;
            if (Inventory == null || Inventory.Count == 0)
            {
                Console.WriteLine("Your backpack is empty!                                                                             ");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    if (item is IEdible)
                    {
                        itemCounter++;
                        edible.Add(item);
                    }
                    else
                    {
                        itemCounter++;
                        attackable.Add(item);
                    }
                }
                Console.WriteLine($"You have {itemCounter} items in your backpack.                                                           \n");

                var q = from x in edible
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };
                Console.WriteLine("Edible:");
                foreach (var x in q)
                {
                    Console.WriteLine(x.Value.Name + " (" + x.Count + ")");
                }
                var t = from x in attackable
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };
                Console.WriteLine("Attackable:");
                foreach (var x in t)
                {
                    Console.WriteLine(x.Value.Name + " (" + x.Count + ")");
                }
            }
            UseInventory();
            void UseInventory()
            {
                if (edible.Count > 0)
                {
                    Console.WriteLine("Do you want to eat your edible items? if so press Enter");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        var tempItemToEat = Inventory.Find(item => item is IEdible);
                        Inventory.Remove(tempItemToEat);

                        if (health < 100)
                        {
                            health += (tempItemToEat as IEdible).HealthIncrease;
                            Hunger += (tempItemToEat as IEdible).HungerIncrease;
                            if (health > 100)
                            {
                                health = 100;
                            }
                            if (Hunger > 100)
                            {
                                Hunger = 100;
                            }
                        }
                        else
                        {
                            Hunger += (tempItemToEat as IEdible).HungerIncrease;
                            if (Hunger > 100)
                            {
                                Hunger = 100;
                            }
                        }
                    }
                }
                else Console.ReadKey();
            }
        }
    }
}
