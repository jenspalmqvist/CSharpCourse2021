using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Parent class for all Character-objects
    /// </summary>
    internal abstract class Character : IRepresentable
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public string Name { get; set; }
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int CoinPurse { get; set; }

        protected DungeonMap map;

        public Character(int x, int y, DungeonMap map)
        {
            PositionX = x;
            PositionY = y;
            this.map = map;
            Health = 100;
            MaxHealth = 250;
        }

        public Character(int x, int y, DungeonMap map, int health, int maxHealth)
        {
            PositionX = x;
            PositionY = y;
            this.map = map;
            Health = health;
            MaxHealth = maxHealth;
        }
        /// <summary>
        /// Move function
        /// </summary>
        public virtual (int x, int y) Move(char direction)
        {
            (int newX, int newY) = map.Move(PositionX, PositionY, direction);

            return (newX, newY);
        }
        /// <summary>
        /// Next action for character after it moved
        /// </summary>
        public abstract void NextAction();

        /// <summary>
        /// Updates the characters health after being attacked
        /// </summary>
        public void Damage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;

            if (Health == 0)
            {
                OnDeath();
            }
        }

        /// <summary>
        /// Removes character from map after it dies
        /// </summary>
        public virtual void OnDeath()
        {
            map.RemoveDynamic(PositionX, PositionY);
        }

        /// <summary>
        /// Adds coins to player Coinpurse
        /// </summary>
        public void AddCoins(int coins)
        {
            CoinPurse += coins;
        }
    }
}