using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Tiles for static map
    /// </summary>
    internal class MapTile : ICloneable, IRepresentable
    {
        public bool Walkable { get; set; }
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public MapTile(bool walkable, char representation)
        {
            Walkable = walkable;
            Representation = representation;
        }

        public MapTile(string tileType)
        {
            switch (tileType)
            {
                case "floor":
                    Walkable = true;
                    Representation = ' ';
                    break;

                case "wall":
                    Walkable = false;
                    Representation = '#';
                    break;

                default:
                    throw new ArgumentException("No such map tile type!");
            }
        }
    }
}