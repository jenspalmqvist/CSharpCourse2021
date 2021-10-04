using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Interface for all objects that are representable on the map to the player 
    /// </summary>
    internal interface IRepresentable
    {
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}