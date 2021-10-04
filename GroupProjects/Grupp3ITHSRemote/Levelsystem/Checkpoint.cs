using System;
using System.Collections.Generic;
using System.Text;


namespace Rollspel
{
    public class Checkpoint : IActiveObject
    {
        public static int Counter;
        private char symbol = 'o';
        private char symbolTaken = 'x';

        public char Symbol { get; set; }
        public char SymbolInvisible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Checkpoint(int x, int y)
        {
            X = x;
            Y = y;
            Reset();
        }

        public void Reset()
        {
            Symbol = symbol;
            Counter = 0;
        }

        public void Step()
        {
            PointCounter();
        }

        public void PointCounter()
        {
            if ((X == Player.X - 1 || X == Player.X + 1) && (Y == Player.Y) && (Symbol != symbolTaken))
            {
                Symbol = symbolTaken;
                Counter++;
            }
        }
    }
}