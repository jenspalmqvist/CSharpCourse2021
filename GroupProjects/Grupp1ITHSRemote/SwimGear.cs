using System;
using System.Collections.Generic;
using System.Text;

namespace Group1Game
{
    class SwimGear : Item
    {
        //public int MovingDistance { get; set; }
        public void AddSwimGear(Board board)
        {
            int a, b;
            Random myTal = new Random();
            a = myTal.Next(1, board.BoardSize);
            b = myTal.Next(1, board.BoardSize);
            board.Boardfield[a, b] = "@";
        }
      
    }
}
