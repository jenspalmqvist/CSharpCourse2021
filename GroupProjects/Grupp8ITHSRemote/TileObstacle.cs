using System;

namespace Labyrintho
{

    class TileObstacle : Tile, IConsoleDrawable
    {
        public int StepValue { get; set; }

        public Position position { get; set; }

        public TileObstacle(char marker, ConsoleColor newColor, bool iswall, int stepValue) : base (marker, newColor, iswall)
        {
            StepValue = stepValue;
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = Color;
            Console.Write(TileMarker);
        }
    }
}
