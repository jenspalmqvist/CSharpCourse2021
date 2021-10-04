using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Game engine class. Sets up the game and runs gameloop
    /// </summary>
    internal class GameEngine
    {
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public DungeonMap WorldMap;
        public PlayerCharacter Player;

        public GameEngine()
        {
            WindowWidth = 100;
            WindowHeight = 50;
            Console.WindowWidth = WindowWidth;
            Console.WindowHeight = WindowHeight;

            WorldMap = new DungeonMap(WindowWidth, WindowHeight - 3);
            Player = new PlayerCharacter(2, 2, WorldMap, '@');

            WorldMap.PlaceDynamic(2, 2, Player);

            // Place equipment on map
            Equipment sword = new Equipment("sword");
            WorldMap.PlaceDynamic(87, 45, sword);

            Equipment potion = new Equipment("potion");
            WorldMap.PlaceDynamic(85, 45, potion);
            WorldMap.PlaceDynamic(11, 26, potion);
            WorldMap.PlaceDynamic(21, 27, potion);
            WorldMap.PlaceDynamic(14, 20, potion);
            WorldMap.PlaceDynamic(95, 45, potion);
            WorldMap.PlaceDynamic(44, 12, potion);
            WorldMap.PlaceDynamic(96, 3, potion);
            WorldMap.PlaceDynamic(50, 8, potion);
            WorldMap.PlaceDynamic(84, 30, potion);

            Equipment axe = new Equipment("axe");
            WorldMap.PlaceDynamic(84, 27, axe);
            WorldMap.PlaceDynamic(96, 3, axe);

            CoinItem coin = new CoinItem(100, '£');
            WorldMap.PlaceDynamic(45, 39, coin);

            // place enemies on map
            var random = new Random();
            for (int i = 0; i < 40; i++)
            {
                int x = random.Next(1, WorldMap.MapWidth - 1);
                int y = random.Next(1, WorldMap.MapHeight - 1);
                if (WorldMap.CanMoveTo(x, y))
                {
                    WorldMap.dynamicMap[x, y] = new NonPlayerCharacter(x, y, WorldMap, random.Next(10) < 3 ? random.Next(10) < 5 ? "goblin" : "skeleton" : "bat");
                }
            }
        }

        /// <summary>
        /// Main loop for the game. Runs until ESC, game over or game won
        /// </summary>
        public void MainLoop()
        {
            DrawStartScreen();

            ConsoleKeyInfo input;
            input = new ConsoleKeyInfo();

            while (input.Key != ConsoleKey.Escape)
            {
                if (IsVictory())
                {
                    DrawVictoryScreen();
                    break;
                }
                if (IsGameOver())
                {
                    DrawGameOver();
                    break;
                }
                if (!Player.HandleInput(input.KeyChar))
                {
                    Player.Move(input.KeyChar);
                }
                WorldMap.NextTurn(input);
                WorldMap.DrawMap();

                Console.WriteLine(Player.GetInventoryString());
                Console.WriteLine(Player.GetStatusString());

                input = Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Uppdates the size of the console window.
        /// </summary>
        private void UpdateWindowSize()
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
        }

        /// <summary>
        /// Draws new data to console window.
        /// </summary>
        public void DrawWindow()
        {
            WorldMap.DrawMap();
        }

        /// <summary>
        /// Check if game is won
        /// </summary>
        public bool IsVictory()
        {
            if (Player.CoinPurse >= 100) return true;

            return false;
        }

        /// <summary>
        /// Check if game is over
        /// </summary>
        public bool IsGameOver()
        {
            if (Player.Health <= 0) return true;

            return false;
        }

        /// <summary>
        /// Draws game over screen
        /// </summary>
        public void DrawGameOver()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "GAME OVER! YOU LOSE BIG TIME!"));
        }

        /// <summary>
        /// Draws game won screen
        /// </summary>
        public void DrawVictoryScreen()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "A WINNER IS YOU! YOU FOUND ENOUGH COINS TO RETIRE IN LUXURY!"));
        }

        /// <summary>
        /// Draws startscreen to the console
        /// </summary>
        public int DrawStartScreen()
        {
            Console.WriteLine();
            Console.WriteLine("You are a brave adventurer searching for loot so that you may retire in luxury.");
            Console.WriteLine();
            Console.WriteLine("You have entered an ancient dungeon filled with monsters that drop coins when");
            Console.WriteLine("they are defeated.");
            Console.WriteLine("And somewhere inside is a treasure chest with enough gold to set you for life,");
            Console.WriteLine("if the monsters won't sate your lust for gold.");
            Console.WriteLine();
            Console.WriteLine("Symbols:");
            Console.WriteLine("@: A fearless adventurer, this is you.");
            Console.WriteLine();
            Console.WriteLine("b: Bat, an enemy on the weaker side.");
            Console.WriteLine("g: Goblin, a fearsome foe!");
            Console.WriteLine("s: Skeleton, can occasionally deal even more damage than a goblin so take care.");
            Console.WriteLine();
            Console.WriteLine("£: A great treasure of gold coins.");
            Console.WriteLine("$: Dropped gold coins.");
            Console.WriteLine("+: Sword, quite useful.");
            Console.WriteLine("!: Axe, a powerful weapon.");
            Console.WriteLine(">: Shovel, weak as a weapon but useful when nothing else is available.");
            Console.WriteLine("X: Potion, use this to heal your wounds.");
            Console.WriteLine();
            Console.WriteLine("Use w/a/s/d-keys to move around. Select equipment with 1-5. Use selected potion with 'u'.");

            ConsoleKeyInfo input;
            input = new ConsoleKeyInfo();

            while (input.Key != ConsoleKey.Spacebar)
            {
                Console.WriteLine();
                Console.WriteLine("Press space to continue.");
                input = Console.ReadKey(true);
            }

            return 0;
        }
    }
}