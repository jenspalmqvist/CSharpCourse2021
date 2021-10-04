using System;
using RollSpelGrupp6.Classes;

namespace RollSpelGrupp6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WindowHeight = 20;
            Console.WindowWidth = 85;
            UI gameUI = new UI();
            gameUI.StartUI();
        }
    }
}