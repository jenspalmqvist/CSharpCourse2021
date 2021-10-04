using System.Drawing;
using Grupparbete1.Tiles;
using Grupparbete1.GameObjects;

namespace Grupparbete1.MapData
{
    public class Room
    {
        public Coord Position { get; }
        public Size Size { get; }
        public Rectangle Area { get; }
        public TileDoor ExitDoor { get; set; }
        public RiddleTablet Tablet { get; set; }

        public Room(Coord position, Size size)
        {
            Position = position;
            Size = size;
            Area = new Rectangle(Position.ToPoint(), Size);
        }
    }
}