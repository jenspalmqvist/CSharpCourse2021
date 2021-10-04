using System;

namespace Labyrintho
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }
}
