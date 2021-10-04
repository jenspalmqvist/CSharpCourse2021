using System;

namespace DungeonCrawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameEngine gm = new GameEngine();
            gm.MainLoop();

        }
    }
}