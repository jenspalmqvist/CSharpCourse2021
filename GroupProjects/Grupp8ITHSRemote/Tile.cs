using System;

namespace Labyrintho
{
    class Tile : IConsoleDrawable
    {
        public char TileMarker { get; set; }
        public ConsoleColor Color { get; set; }
        public bool IsWall { get; set; }

        public Tile( char marker, ConsoleColor newColor, bool iswall)
        {
            TileMarker = marker;
            Color = newColor;
            IsWall = iswall;
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = Color;
            Console.Write(TileMarker);
        }
    }
}
