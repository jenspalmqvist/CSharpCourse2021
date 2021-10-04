using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbete_grp7
{
    class Trap : Location
    {
        public override void EnterLocation()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Du gick i en fälla");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n === Game Over ===\n");
            Console.ResetColor();

            Console.Write("Tryck Enter för att gå till menyn...");
            Console.ReadLine();
            Program.MainMenu();
        }
    }
}
