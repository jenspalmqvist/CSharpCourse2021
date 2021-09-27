using System;
using System.Collections.Generic;
using System.Text;

namespace Group1Game
{
    class Item : ICollectable
    {
        public string Name { get; set; }
        public int NumberOfTimesUsed { get; set; }
        public void AddItem(Board board)
        {
            int a, b;
            Random myTal = new Random();
            a = myTal.Next(1, board.BoardSize);
            b = myTal.Next(1, board.BoardSize);
            board.Boardfield[a, b] = "!";
        }
    }
}
