using System;
using System.Collections.Generic;
using System.Text;

namespace GubbenIRummet
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;
        public Player(int initialX, int initialY) // Kollar vart player befinner sig.
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "O";
            PlayerColor = ConsoleColor.Red;


        }
        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
    }
}
