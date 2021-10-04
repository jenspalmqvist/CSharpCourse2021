using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Non player characters, different types of monsters
    /// </summary>
    internal class NonPlayerCharacter : Character
    {
        private IRepresentable loot;
        private int minDamage;
        private int maxDamage;

        public NonPlayerCharacter(int x, int y, DungeonMap map, string type) : base(x, y, map)
        {
            loot = new CoinItem();

            switch (type)
            {
                case "bat":
                    Representation = 'b';
                    minDamage = 10;
                    maxDamage = 20;
                    Health = 25;
                    MaxHealth = 25;

                    loot = new CoinItem(5, '$');
                    break;

                case "goblin":
                    Representation = 'g';
                    minDamage = 20;
                    maxDamage = 40;

                    loot = new CoinItem(10, '$');
                    break;

                case "skeleton":
                    Representation = 's';
                    minDamage = 10;
                    maxDamage = 50;

                    loot = new CoinItem(15, '$');
                    break;

                default:
                    throw new ArgumentException("No such NPC type!");
            }
        }

        /// <summary>
        /// Returns current coordinates of the playercharacter
        /// </summary>
        public (int x, int y) FindPlayerCoordinates()
        {
            int w = map.dynamicMap.GetLength(0); // width
            int h = map.dynamicMap.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (map.dynamicMap[x, y] != null && map.dynamicMap[x, y].GetType() == typeof(PlayerCharacter))
                    {
                        return (x, y);
                    }
                }
            }

            return (-1, -1);
        }
        /// <summary>
        /// Calculates distance from NPC to playercharacter
        /// </summary>
        public int PlayerDistance()
        {
            int distance = -1;
            (int playerX, int playerY) = FindPlayerCoordinates();
            if (playerX >= 0 && playerY >= 0)
            {
                distance = (int)Math.Sqrt(Math.Abs(Math.Pow(playerY - PositionY, 2) + Math.Pow(playerX - PositionX, 2)));
            }
            return distance;
        }

        /// <summary>
        /// Returns the direction for the next move
        /// </summary>
        public char PlayerDirection()
        {
            (int playerX, int playerY) = FindPlayerCoordinates();
            if (playerX < 0 && playerY < 0)
            {
                return 'x'; // Error.
            }

            int deltaX = playerX - PositionX;
            int deltaY = playerY - PositionY;

            if (Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                // Move horizontally.
                if (deltaX <= 0)
                {
                    return 'a'; //Left.
                }
                else
                {
                    return 'd'; //Right.
                }
            }
            else
            {
                // Move vertically.
                if (deltaY <= 0)
                {
                    return 'w'; //Up.
                }
                else
                {
                    return 's'; //Down.
                }
            }
        }
        /// <summary>
        /// Decides the next actino for NPC
        /// </summary>
        public override void NextAction()
        {
            var random = new Random();
            int damage = random.Next(minDamage, maxDamage + 1);

            var directions = new char[] { 'w', 's', 'a', 'd' };

            int playerDist = PlayerDistance();
            char playerDir = PlayerDirection();

            var nextPosition = map.GetMoveTargetCoordinates(PositionX, PositionY, playerDir);

            var dynamic = map.GetDynamic(nextPosition.x, nextPosition.y);

            if (dynamic != null)
            {
                if (dynamic is PlayerCharacter)
                {
                    ((PlayerCharacter)dynamic).Damage(damage);
                    return;
                }
            }

            if (playerDist != -1 && playerDist <= 5)
            {
                // If the player is close, move towards player.
                Move(playerDir);
            }
            else
            {
                Move(directions[random.Next(0, directions.Length)]);
            }
        }

        /// <summary>
        /// Removes character from map after death and drops coins
        /// </summary>
        public override void OnDeath()
        {
            map.RemoveDynamic(PositionX, PositionY);
            map.PlaceDynamic(PositionX, PositionY, loot);
        }
    }
}