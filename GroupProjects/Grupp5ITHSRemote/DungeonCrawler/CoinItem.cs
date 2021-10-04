using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// CoinItem to collect. Collecting enough coins = win
    /// </summary>
    internal class CoinItem : IRepresentable
    {
        public int Value { get; set; }
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public CoinItem(int value, char representation)
        {
            Value = value;
            Representation = representation;
        }

        public CoinItem()
        {
            Value = 1;
            Representation = '$';
        }
    }
}