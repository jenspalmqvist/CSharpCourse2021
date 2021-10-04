using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    class Dialog : Game
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Message { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        public bool Border { get; set; }

        //public Dialog()
        //{

        //}

        public Dialog(int posX, int posY, string msg, ConsoleColor color, bool border, Map map)
        {
            PosX = posX;
            PosY = posY;
            Message = msg;
            Color = color;
            Border = border;
            int mapWidth = map.map[0].Length;
            for (int i = 0; PosX + msg.Length + 2 >= mapWidth + 1; i++) // Positionera om dialogrutan om den är utanför spelfältet.
            {
                PosX--;
            }
            if (PosX < 1)
            {
                PosX = 1;
            }
            if (PosY < 1)
            {
                PosY = 1;
            }
        }

        public void Print()
        {
            Console.ForegroundColor = Color;
            if (Border)
            {
                Console.SetCursorPosition(PosX, PosY);
                Console.Write("**");
                foreach (char c in Message)
                {
                    Console.Write("*");
                }
            }
            
            Console.SetCursorPosition(PosX, PosY - 1);
            if (Border)
            {
                Console.Write("*" + Message + "*");
            }
            else
            {
                Console.Write(Message);
            }

            if (Border)
            {
                Console.SetCursorPosition(PosX, PosY - 2);
                foreach (char c in Message)
                {
                    Console.Write("*");
                }
                Console.Write("**");
            }
        }
    }
}
