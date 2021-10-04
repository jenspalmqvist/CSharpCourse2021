using System;
using System.Collections.Generic;
using System.Text;

namespace Group1Game
{
     public class Rock: MapObject
    {
        public Rock(int length, int height):base(length,height)
        {
            
        }

        public void AddRock(Board board)
        {
            int a, b;
            Random myTal = new Random();
            string[,] rockSize = new string[Length,Height];
            a = myTal.Next(1, board.BoardSize);
            b= myTal.Next(1, board.BoardSize);
            board.Boardfield[a, b] = "O";         
            
            for(int i= 0; i<Height; i++)
                for(int j=0; j<Length;j++)
                {
                    if (i + a >= board.BoardSize || j + b >= board.BoardSize)
                        continue;
                    if (i + a == board.BoardSize-1 && j + b == board.BoardSize-1)
                        continue;
                    if (board.Boardfield[i + a, j + b] == ".")
                        board.Boardfield[i + a, j + b] = "O";
                }
        }
    }
}
