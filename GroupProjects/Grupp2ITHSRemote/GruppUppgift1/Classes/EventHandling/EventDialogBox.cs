using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public static class EventDialogBox
    {
        private static int X = 0;
        private static int Y = 26;

        public static void Print(string message)
        {
            Print(message, X, Y, true, ConsoleColor.White);
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.SetCursorPosition(X, Y);
            //Console.Write("**");
            //foreach (var c in message)
            //{
            //    Console.Write("*");
            //}
            //Console.Write("**");
            //Console.SetCursorPosition(X, Y + 1);
            //Console.WriteLine(message);
        }

        public static void Print(string message, int xPos, int yPos, bool addLineAbove, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            if(addLineAbove)
            {
                AddLineAbove(message, xPos, yPos);
            }
            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine(message);
        }

        private static void AddLineAbove(string message, int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos - 1);
            Console.Write("**");
            foreach (var c in message)
            {
                Console.Write("*");
            }
            Console.Write("**");
        }

        public static void Clear()
        {
            Clear(X, Y, Console.WindowWidth, 3);
        }
        public static void Clear(int xPos, int yPos, int width, int rows)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                stringBuilder = new StringBuilder().Append(' ', width);
                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}
