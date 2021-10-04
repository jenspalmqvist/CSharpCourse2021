using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Parent class for all Equipment objects
    /// </summary>
    internal class Equipment : IRepresentable
    {
        public string Name { get; set; }
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Damage { get; set; }
        public int Heal { get; set; }

        public Equipment(string type)
        {
            switch (type)
            {
                case "sword":
                    Name = "Sword";
                    Representation = '+';
                    Damage = 50;
                    Heal = 0;
                    break;

                case "axe":
                    Name = "Axe";
                    Representation = '!';
                    Damage = 80;
                    Heal = 0;
                    break;

                case "shovel":
                    Name = "Shovel";
                    Representation = '>';
                    Damage = 10;
                    Heal = 0;
                    break;

                case "potion":
                    Name = "Potion";
                    Representation = 'X';
                    Damage = 0;
                    Heal = 50;
                    break;

                default:
                    throw new ArgumentException("No such equipment!");
            }
        }
    }
}