using System;

namespace RollSpelGrupp6.Classes.UIs
{
    public class Printer
    {
        public static void PrintInColor(ConsoleColor consoleColor, string sentence, bool newLine = true)
        {
            Console.ForegroundColor = consoleColor;
            if (newLine)
            {
                Console.WriteLine(sentence);
            }
            else
            {
                Console.Write(sentence);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintInColor(ConsoleColor consoleColor, char character, bool newLine = true)
        {
            Console.ForegroundColor = consoleColor;
            if (newLine)
            {
                Console.WriteLine(character);
            }
            else
            {
                Console.Write(character);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}