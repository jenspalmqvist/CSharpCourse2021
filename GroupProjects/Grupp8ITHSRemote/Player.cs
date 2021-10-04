using System;

namespace Labyrintho
{
    class Player : IConsoleDrawable
    {
        private Tile playerMarker;
        public Position PlayerPosition { get; set; }
        public int numberOfSteps { get; set; } = 0;

        public Player(Position startingPosition, Tile playerMarker)
        {
            PlayerPosition = startingPosition;
            this.playerMarker = playerMarker;
        }

        public Position getInput()
        {
            ConsoleKey key;
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return new Position(PlayerPosition.X, PlayerPosition.Y - 1);
                case ConsoleKey.DownArrow:
                    return new Position(PlayerPosition.X, PlayerPosition.Y + 1);
                case ConsoleKey.LeftArrow:
                    return new Position(PlayerPosition.X - 1, PlayerPosition.Y);
                case ConsoleKey.RightArrow:
                    return new Position(PlayerPosition.X + 1, PlayerPosition.Y);
            }

            return PlayerPosition;
        }

        public void UpdatePosition(Position checkPosition)
        {
            PlayerPosition = checkPosition;
        }

        public void Draw()
        {
            Console.SetCursorPosition(PlayerPosition.X, PlayerPosition.Y);
            Console.ForegroundColor = playerMarker.Color;
            Console.Write(playerMarker.TileMarker);
        }
    }
}
