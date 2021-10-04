using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete1.Engine;
using Grupparbete1.MapData;

namespace Grupparbete1
{
    /// <summary>
    /// Innehåller den karta som används i spelet just nu, och tar emot input från spelaren.
    /// </summary>
    public class Game
    {
        public Map GameMap { get; set; }
        public MessageLog MessageLog { get; set; }
        private MapGenerator _mapGen;
        public ControlMode CurrentMode { get; set; }

        public int SelectedMenuItem { get; set; }
        public List<string> MenuItems { get; }

        public Game(int width, int height)
        {
            //GameMap = new Map(width, height);
            _mapGen = new MapGenerator(new Map(width, height), 10, 5, 12);
            CurrentMode = ControlMode.Menu;

            MenuItems = new List<string>()
            {
                "Start Game",
                "Exit"
            };

        }

        public void Init()
        {
            DrawMenu();
            GameMap = _mapGen.Generate();
            MessageLog = new MessageLog(new Coord(1, GameMap.Height + 1), 10);
        }

        private void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("Temple of the Bad Riddles");
            for(int i = 0; i < MenuItems.Count; i++)
            {
                Console.WriteLine($"{(SelectedMenuItem == i ? ">" : " ")} {MenuItems[i]}");
            }
        }

        public void MoveMenuCursor()
        {
            for(int i = 0; i < MenuItems.Count; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write($"{(SelectedMenuItem == i ? ">" : " ")}");
            }
        }

        /// <summary>
        /// Själva gameloopen som läser användarens input.
        /// </summary>
        public void Run()
        {
            ConsoleKey input;

            while (true)
            {
                // Skickar den tangent som spelaren trycker på till InputManager, som sedan utför olika saker beroende på vilken tangent som tryckts på.
                InputManager.ProcessInput(Console.ReadKey());
            }
        }
    }
}
