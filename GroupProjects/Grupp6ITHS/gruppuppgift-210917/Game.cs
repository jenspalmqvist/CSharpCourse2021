using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace gruppuppgift_210917
{
    internal class Game
    {
        public Game()
        {
        }

        public void Run()
        {
            int worldSize = 20;
            int numberOfIslands = 5;
            var player = new Player(0, 0);
            var world = new World(worldSize, numberOfIslands);
            DrawWorld.MainWorld = world;
            DrawWorld.WorldToDraw = world.WorldMap;
            Console.SetWindowSize(90, 40);
            DrawIntroMenu(player);
            DrawShipSailingAway(player);
            Console.Clear();

            while (player.Inventory.Count <= numberOfIslands)
            {
                Console.CursorVisible = false;
                DrawWorld.DrawGameWorld(player, DrawWorld.WorldToDraw);
                ClearTextElements(worldSize);
                player.DrawInventory();
                if(DrawWorld.DrawMessages(player, DrawWorld.WorldToDraw)) continue;
                while (Console.KeyAvailable)
                {
                player.PlayerInput = player.GetKeyFromPlayer();
                player.MovePlayer(worldSize);
                }
            }
            Thread.Sleep(2000);
            DrawVictoryMessage();
            Thread.Sleep(4000);
        }

        private void ClearTextElements(int worldSize)
        {
            Console.SetCursorPosition(0, worldSize);
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.SetCursorPosition(0, worldSize);
        }

        public bool CheckIfWin(int inventorySize, int maxItems)
        {
            if (inventorySize < maxItems)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DrawVictoryMessage()
        {
            Console.Clear();
            DrawPrayingHands();
        }

        private void DrawIntroMenu(Player player)
        {
            Console.Clear();
            player.Name = GetPirateName();
            Console.Clear();
            DrawShip();
        }

        private void DrawShip()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("                                            (                                     ");
            Console.WriteLine("                                            (                                     ");
            Console.WriteLine("                                            &&&&&&                                ");
            Console.WriteLine("                                            &.                                    ");
            Console.WriteLine("                                            &                   & &               ");
            Console.WriteLine("                                            &                &****                ");
            Console.WriteLine("                                        ,*  &             &*******                ");
            Console.WriteLine("                                      ,   , &.         /***********               ");
            Console.WriteLine("                                   ..  .   *&,      /**************.              ");
            Console.WriteLine("                               *...  *,    .&,  .******/************              ");
            Console.WriteLine("                            #..... ,,,  ** .&#***********************             ");
            Console.WriteLine("                        , ......*,,,, ***. *&*************************            ");
            Console.WriteLine("                      .......,,,,,,,*****  ,&/(****************/*******           ");
            Console.WriteLine("                  .........*,,,,,,*******   &***************************/         ");
            Console.WriteLine("               #........*,,,,,,,*********   &*****************************        ");
            Console.WriteLine("            ........./,,,,,,,,***********   &******************************       ");
            Console.WriteLine("        /..........,,,,,,,,,*************.  &**/****************************      ");
            Console.WriteLine("  .......,(.... ,,,,,,,,,,****************  &********************************.    ");
            Console.WriteLine("            %&&/       ,******************  &**********************************   ");
            Console.WriteLine("                    *&&&&&&&.     ,       , &&@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%/. ");
            Console.WriteLine("                       &&&&&&&&&&&&&&&&&&&&&&&&&&&&@&&&&#     &&&&&&   &&&&&&&    ");
            Console.WriteLine("                       &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &    ");
            Console.WriteLine("                         &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%%#(//*,..          ");
            Console.WriteLine();
        }

        public void DrawShipSailingAway(Player player)
        {
            int ms = 20;
            var ship = new List<string>()
            {
            "                                            (                                      ",
            "                                            (                                      ",
            "                                            &&&&&&                                 ",
            "                                            &.                                     ",
            "                                            &                   & &                ",
            "                                            &                &****                 ",
            "                                        ,*  &             &*******                 ",
            "                                      ,   , &.         /***********                ",
            "                                   ..  .   *&,      /**************.               ",
            "                               *...  *,    .&,  .******/************               ",
            "                            #..... ,,,  ** .&#***********************              ",
            "                        , ......*,,,, ***. *&*************************             ",
            "                      .......,,,,,,,*****  ,&/(****************/*******            ",
            "                  .........*,,,,,,*******   &***************************/          ",
            "               #........*,,,,,,,*********   &*****************************         ",
            "            ........./,,,,,,,,***********   &******************************        ",
            "        /..........,,,,,,,,,*************.  &**/****************************       ",
            "  .......,(.... ,,,,,,,,,,****************  &********************************.     ",
            "            %&&/       ,******************  &**********************************    ",
            "                    *&&&&&&&.     ,       , &&@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%/.  ",
            "                       &&&&&&&&&&&&&&&&&&&&&&&&&&&&@&&&&#     &&&&&&   &&&&&&&     ",
            "                       &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &     ",
            "                         &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%%#(//*,..           "
            };

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Welcome to the best adventure game, {player.Name}. Let the adventure begin!");
            Thread.Sleep(2000);

            for (int j = ship[0].Length - 25; j > 0; j--)
            {
                Console.SetCursorPosition(0, 3);
                foreach (var str in ship)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine();
                Thread.Sleep(ms);

                try
                {
                    for (int i = 0; i < ship.Count; i++)
                    {
                        ship[i] += "  ";
                    }
                    ship = ship.Select(str => str = str.Remove(0, 2)).ToList();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        public void DrawPrayingHands()
        {
            Console.Clear();
            string message = "Congratulations! You did what nobody else has done, you won!!!\n" +
                "Thank you for finding Jesus, and thank you for playing the game!\n" +
                " \n END CREDITS: \n Sandra\n Rasmus\n Kim\n Setrag\n Vincent\n LEGENDARY TEAM 6\n";
            Console.WriteLine(message);


            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(0, 9);
                
                Console.WriteLine("\n");
                Console.WriteLine(@"                 _.-._         ");
                Console.WriteLine(@"               /| | | |_       ");
                Console.WriteLine(@"               || | | | |      ");
                Console.WriteLine(@"               || | | | |      ");
                Console.WriteLine(@"              _||     ` |      ");
                Console.WriteLine(@"             \\`\       ;      ");
                Console.WriteLine(@"              \\        |      ");
                Console.WriteLine(@"               \\      /       ");
                Console.WriteLine(@"               | |    |        ");
                Console.WriteLine(@"               | |    |        ");
                Console.WriteLine(@"                               ");

                Thread.Sleep(700);

                Console.SetCursorPosition(0, 9);

                Console.WriteLine();
                Console.WriteLine(@"                                ");
                Console.WriteLine(@"                                ");
                Console.WriteLine(@"                     _.-/`)    ");
                Console.WriteLine(@"                   // / / )    ");
                Console.WriteLine(@"                .=// / / / )   ");
                Console.WriteLine(@"               //`/ / / / /    ");
                Console.WriteLine(@"              // /     ` /     ");
                Console.WriteLine(@"             ||         /      ");
                Console.WriteLine(@"              \\       /       ");
                Console.WriteLine(@"               ))    .'        ");
                Console.WriteLine(@"              //    /          ");
                Console.WriteLine(@"                   /           ");

                Thread.Sleep(700);
            }
        }

        public static void DrawPirate()
        {
            ConsoleColor pirateColor = ConsoleColor.DarkGreen;
            ConsoleColor hatColor = ConsoleColor.DarkYellow;
            ConsoleColor parrotColor = ConsoleColor.DarkRed;
            ConsoleColor shirtColor = ConsoleColor.DarkCyan;

            Console.ForegroundColor = hatColor;
            Console.WriteLine(@"                 _____                      ");
            Console.WriteLine(@"              .-''.-.''-.                   ");
            Console.WriteLine(@"            _/ '=(0.0)=' \_                 ");
            Console.WriteLine(@"          /`   .='|m|'=.   `\               ");
            Console.WriteLine(@"          \________________ /               ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"      .--.__");
            Console.ForegroundColor = pirateColor;
            Console.WriteLine(@"///`'-,__~\\\\~`                ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"     / /6|__\");
            Console.ForegroundColor = pirateColor;
            Console.WriteLine(@"// a (__)-\\\\                 ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"     \ \/--`");
            Console.ForegroundColor = pirateColor;
            Console.WriteLine(@"((   ._\   ,)))                 ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"     /  \\");
            Console.ForegroundColor = pirateColor;
            Console.WriteLine(@"  ))\  -==-  ())(                 ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"    /    )\");
            Console.ForegroundColor = pirateColor;
            Console.WriteLine(@"((((\   .  /)))))                ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"   /  _.' /  ");
            Console.ForegroundColor = shirtColor;
            Console.WriteLine(@"__(`~~~~`)__                   ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"  //''\\");
            Console.ForegroundColor = shirtColor;
            Console.WriteLine(@",-'-''`   `~~~~\\~~`''-.            ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@" //");
            Console.ForegroundColor = shirtColor;
            Console.WriteLine(@"  /`''              `      `\            ");
            Console.ForegroundColor = parrotColor;
            Console.Write(@"//");
            Console.ForegroundColor = shirtColor;
            Console.WriteLine(@"  /                           \           ");
            Console.ResetColor();
        }

        private static string GetPirateName()
        {
            string name;
            while (true)
            {
                Console.WriteLine("Hello and welcome to The Pirate Game!");
                Console.WriteLine("Your mission is to find all of the items hidden away on the islands.");
                Console.WriteLine("Use the arrow keys to move your pirates boat and crew.");
                DrawPirate();

                Console.WriteLine("Enter your pirates name:");
                name = Console.ReadLine();
                if (true)
                {
                    bool istrue = true;
                    foreach (var character in name)
                    {
                        if (Char.IsLetter(character))
                        {
                            istrue = false;
                        }
                    }
                    if (!istrue && name.Length > 1)
                    {
                        break;
                    }
                }
                Console.Clear();
            }
            return name;
        }
    }
}