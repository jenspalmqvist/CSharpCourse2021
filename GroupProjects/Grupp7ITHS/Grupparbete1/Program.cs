using System;

namespace Grupparbete1
{
    class Program
    {
        public static Game Game;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game = new Game(100, 18);
            Game.Init();
            Game.Run();
        }
    }
}
