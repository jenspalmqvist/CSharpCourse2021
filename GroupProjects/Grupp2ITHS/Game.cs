using System;
using System.Collections.Generic;
using System.Text;

namespace GubbenIRummet
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            Console.Title = "Welcome";
            Console.CursorVisible = false;

            string[,] grid = // här har vi våran värld.
            {
                {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█"},
                {"█", " ", " ", " ", " ", "█", " ", "█", " ", "█", " ", " ", " ", " ", " ", " ", "█"},
                {"█", " ", "█", "█", " ", " ", " ", "█", "█", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", "█", " ", "█", "█", "█", " ", " ", "█", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", "█", "█", " ", " ", " ", "█", " ", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", " ", " ", " ", "█", " ", "█", " ", " ", "█", "█", " ", " ", " ", " ", "█"},
                {"█", " ", " ", "█", "█", "█", " ", "█", "█", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", "█", "█", "█", " ", " ", " ", " ", " ", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", " ", " ", " ", "█", "█", "█", " ", "█", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", "█", " ", " ", "█", " ", " ", " ", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", "█", " ", " ", "█", "█", "█", " ", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", "█", " ", " ", "█", " ", "█", " ", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", "█", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", " ", " ", " ", "█"},
                {"█", " ", " ", " ", " ", " ", " ", "█", " ", " ", " ", "█", " ", " ", " ", "?", "█"},
                {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█"},
            };
            MyWorld = new World(grid); // skapar ny värld.
            CurrentPlayer = new Player(1,1); // lägger våran spelare på position i början.

            RunGameLoop();
        }
        private void DisplayIntro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome!");
            Console.WriteLine("Use arrow keys to move and try to reach the chests!");
            Console.ResetColor();
        }
        private void DrawFrame()
        {
            Console.Clear();
            MyWorld.Draw(); 
            CurrentPlayer.Draw();
        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X,CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;

            }

        }
        private void RunGameLoop()
        {
            //DisplayIntro();
            while (true)
            {
                // Rita ut allt
                DrawFrame();

                // Kolla player input och rör spelaren
                HandlePlayerInput();

                // Kolla om player nått kistan och breaka ut oss ur loopen
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if(elementAtPlayerPos == "?")
                {
                    break;
                }

                // Låt consolen rendra.
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
