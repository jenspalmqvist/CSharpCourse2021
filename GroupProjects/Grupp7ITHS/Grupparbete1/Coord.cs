using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Grupparbete1
{
    /// <summary>
    /// Representerar en uppsättning koordinater.
    /// </summary>
    public struct Coord
    { 
        public int X { get; }
        public int Y { get; }

        public static Coord operator +(Coord point1, Coord point2)
        {
            return new Coord(point1.X + point2.X, point1.Y + point2.Y);
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
