using ConsoleTables;
using RollSpelGrupp6.Classes.UIs;
using RollSpelGrupp6.Structures;
using System;
using System.Threading;

namespace RollSpelGrupp6.Classes
{
    internal class UI
    {
        public FightUI FightUI { get; set; }
        public Grid GameGrid { get; set; }
        public Player Player { get; set; }
        public Generator Generator { get; set; }
        public Monster Monster { get; set; }
        public string PlayerUsername { get; set; }
        public bool StopGame { get; set; }
        public bool IsConsoleCleared { get; set; }
        public bool IsPlayerFightWinner { get; set; }

        private Coordinate NewPlayerLocation;

        public UI()
        {
            Generator = new Generator();
            SetUpUI();
            GameGrid = new Grid(Player, this);
            FightUI = new FightUI(Generator);
            StopGame = false;
            IsConsoleCleared = false;
            IsPlayerFightWinner = true;

            NewPlayerLocation = new Coordinate();
        }

        public void StartUI()
        {
            Console.WindowHeight = 28;
            Console.WindowWidth = 125;
            GameGrid.GenerateGrid();
            GameGrid.PrintGrid();
            Console.SetCursorPosition(Player.Location.Col, Player.Location.Row);
            Console.WriteLine("@");
            Console.SetCursorPosition(0, 18);
            PrintUserInformation();
            Console.SetCursorPosition(0, 1);
            PrintPlayerRankings();
            while (!StopGame)
            {
                if (!GameGrid.IsMonsterSpawning && GameGrid.Monsters.Count < GameGrid.MaxMonstersOnBoard)
                {
                    if (!GameGrid.IsRespawnedMonsterPrinted)
                    {
                        Console.SetCursorPosition(GameGrid.LastAddedMonster.Location.Col, GameGrid.LastAddedMonster.Location.Row);
                        Printer.PrintInColor(ConsoleColor.DarkYellow, 'x', false);
                    }
                    GameGrid.IsMonsterSpawning = true;
                    Thread addMonster = new Thread(GameGrid.RespawnMonster);
                    addMonster.Start();
                }
                if (!GameGrid.IsBossSpawning && GameGrid.Boss.Count == 0)
                {
                    GameGrid.IsBossSpawning = true;
                    Thread addBoss = new Thread(GameGrid.RespawnBoss);
                    addBoss.Start();
                }

                if (IsConsoleCleared)
                {
                    Console.Clear();
                    GameGrid.PrintGrid();
                    Console.SetCursorPosition(Player.Location.Col, Player.Location.Row);
                    Console.WriteLine("@");
                    Console.SetCursorPosition(0, 18);
                    PrintUserInformation();
                    Console.SetCursorPosition(0, 1);
                    PrintPlayerRankings();
                    IsConsoleCleared = false;
                }
                TakeInput();
                if (Player.PlayerInventory.IsContentUpdated)
                {
                    //update the bag shown on screen
                }
            }
            if (StopGame)
            {
                if (Player.Lives.LivesLeft == 0)
                {
                    Player.ResetPlayer();
                    PlayerDatabase.AddUserToPlayerDatabase(PlayerUsername, Player);
                    PlayerDatabase.WriteToPlayerDatabase();
                }
                else
                {
                    PlayerDatabase.AddUserToPlayerDatabase(PlayerUsername, Player);
                    PlayerDatabase.WriteToPlayerDatabase();
                    Console.SetCursorPosition(0, 29);
                }
            }
        }

        private void SetUpUI()
        {
            Console.CursorVisible = false;
            StartScreen();

            bool isUsernameAccepted = false;
            Printer.PrintInColor(ConsoleColor.Yellow, "Välkommen till spelet");
            Printer.PrintInColor(ConsoleColor.Yellow, "\nAnge användarnamn: ", false);
            Console.CursorVisible = true;
            PlayerUsername = Console.ReadLine().ToUpper();
            while (!isUsernameAccepted)
            {
                if (PlayerUsername.Length > 1
                    && PlayerUsername.Length <= 11
                    && !PlayerUsername.Contains(" ")
                    && !PlayerUsername.Contains("\\"))
                {
                    isUsernameAccepted = true;
                    break;
                }
                Printer.PrintInColor(ConsoleColor.Red, "\nOgiltigt värde.\nAnvändarnamnet måste vara mellan 2 och 11 tecken lång och kan inte innehålla ' ' och '\\'");
                PlayerUsername = Console.ReadLine().ToLower();
            }
            PlayerDatabase.ReadFromPlayerDatabase();
            Player = PlayerDatabase.GetUserFromPlayerDatabase(PlayerUsername);
            Console.Clear();
        }

        private void TakeInput()
        {
            var keyPressed = Console.ReadKey(true).Key;
            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    NewPlayerLocation.SetCoordinate(Player.Location.Row - 1, Player.Location.Col);
                    MovePlayer();
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    NewPlayerLocation.SetCoordinate(Player.Location.Row + 1, Player.Location.Col);
                    MovePlayer();
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    NewPlayerLocation.SetCoordinate(Player.Location.Row, Player.Location.Col - 1);
                    MovePlayer();
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    NewPlayerLocation.SetCoordinate(Player.Location.Row, Player.Location.Col + 1);
                    MovePlayer();
                    break;

                case ConsoleKey.Escape:
                    StopGame = true;
                    break;

                case ConsoleKey.P:
                    Player.TakePotion();
                    Console.SetCursorPosition(0, 18);
                    PrintUserInformation();
                    break;

                case ConsoleKey.R:
                    Player.ResetPlayer();
                    break;
            }
        }

        private void MovePlayer()
        {
            if ((NewPlayerLocation.Row >= 0
                && NewPlayerLocation.Row < GameGrid.GameGrid.Length))
            {
                if (!(GameGrid.GameGrid[NewPlayerLocation.Row][NewPlayerLocation.Col - GameGrid.GridOffsetRight] == '_' ||
                GameGrid.GameGrid[NewPlayerLocation.Row][NewPlayerLocation.Col - GameGrid.GridOffsetRight] == '|'))
                {
                    foreach (Monster monster in GameGrid.Monsters)
                    {
                        if (NewPlayerLocation.Equals(monster.Location))
                        {
                            FightUiTransition(monster);
                            if (IsPlayerFightWinner)
                            {
                                lock (GameGrid.MonsterLock)
                                {
                                    GameGrid.Monsters.Remove(monster);
                                }
                            }
                            break;
                        }
                    }
                    if (GameGrid.Boss.Count > 0)
                    {
                        if (NewPlayerLocation.Equals(GameGrid.Boss[0].Location))
                        {
                            FightUiTransition(GameGrid.Boss[0]);
                            if (IsPlayerFightWinner)
                            {
                                lock (GameGrid.MonsterLock)
                                {
                                    GameGrid.Boss.RemoveAt(0);
                                }
                            }
                        }
                    }
                    if (IsPlayerFightWinner)
                    {
                        Console.SetCursorPosition(Player.Location.Col, Player.Location.Row);
                        Printer.PrintInColor(ConsoleColor.Black, ' ');
                        Console.SetCursorPosition(NewPlayerLocation.Col, NewPlayerLocation.Row);
                        Console.Write('@');
                        Player.Location.SetCoordinate(NewPlayerLocation.Row, NewPlayerLocation.Col);
                    }
                    IsPlayerFightWinner = true;
                }
            }
        }

        private void FightUiTransition(Monster monster)
        {
            GameGrid.IsFightUICurrentUI = true;
            Console.Clear();
            IsPlayerFightWinner = FightUI.Combat(Player, monster);
            Console.Clear();
            if (Player.Lives.LivesLeft == 0)
            {
                Printer.PrintInColor(ConsoleColor.Red, ($"SLUT PÅ LIV. DIN POÄNG BLEV {Player.Score} !!!"));
                Thread.Sleep(3000);
                StopGame = true;
            }

            GameGrid.IsFightUICurrentUI = false;
            IsConsoleCleared = true;
        }

        public void PrintUserInformation()
        {
            string bossDamage = GameGrid.Boss.Count is 0 ? "SPAWNAR" : GameGrid.Boss[0].MaxHP.ToString();
            var tableUserInformation = new ConsoleTable("SPELARE    ", "LIV KVAR", "LEVEL", "EXP", "NY LEVEL VID", "HÄLSA", "HP-FLASKA", "ATTACKSKADA", "BOSS-HP", "POÄNG", "HIGH SCORE");
            tableUserInformation.AddRow($"{Player.Name}", $"{Player.Lives.LivesLeft}", $"{Player.Level}", $"{Player.Experience} ", $"{Player.ExperienceBreakpoint} ", $"{Player.HP}", $"{Player.Potions}", $"{Player.Weapon.LowDamage} - {Player.Weapon.HighDamage}", $"{bossDamage}", $"{Player.Score}", $"{Player.HighScore}");
            tableUserInformation.Write(Format.Alternative);
            string controls = "MOVE: WASD/piltangenter\tANVÄNDA HP-FLASKA: P\tÅTERSTÄLLA SPELET: R\tSPARA OCH STANG: Esc";
            Printer.PrintInColor(ConsoleColor.Blue, controls);
            Printer.PrintInColor(ConsoleColor.Blue, "SPELARE: ", false);
            Console.Write("@");
            Printer.PrintInColor(ConsoleColor.Blue, "\tMONSTER: ", false);
            Printer.PrintInColor(ConsoleColor.Yellow, 'x', false);
            Printer.PrintInColor(ConsoleColor.Blue, "\tBOSS: ", false);
            Printer.PrintInColor(ConsoleColor.Red, 'X');
        }

        public void StartScreen()
        {
            var wordsInt = new int[3];
            wordsInt = Generator.RandomNumberList(wordsInt, 0, 5);

            var wordCollection1 = new string[6] { "otroligt", "vansinnigt", "fruktansvärt", "förvånansvärt", "ganska", "relativt" };
            var wordCollection2 = new string[6] { "fantastiska", "slätstrukna", "omöjliga", "deprimerande", "nervkittlande", "dråpliga" };
            var wordCollection3 = new string[6] { "äventyret", "strövtåget", "exkursionen", "irrfärden", "odyssén", "eskapaden" };

            string word2 = wordCollection1[wordsInt[0]];
            string word3 = wordCollection2[wordsInt[1]];
            string word4 = wordCollection3[wordsInt[2]];
            string word1 = DenOrDet(word4);

            Console.WriteLine("\n\n\t\t<<<══════════════════════════════════════════>>>");
            Printer.PrintInColor(ConsoleColor.DarkRed, ($"\t\t    {word1} {word2} {word3} {word4}!"));
            //Console.WriteLine($"\t\t    Det {word1} {word2} äventyret! ");
            Console.WriteLine("\t    <<<══════════════════════════════════════════════════>>>");

            Console.Write("\n\n\n\t\t\t\t   Ett mästerverk från "); Printer.PrintInColor(ConsoleColor.DarkYellow, ("6rupp"));

            Console.WriteLine("\n\n\n\n\n\t\t\t\t  Tryck för att starta spelet");
            Console.ReadKey();
            Console.Clear();
        }

        public string DenOrDet(string word)
        {
            if (word == "äventyret" || word == "strövtåget")
            {
                return "Det";
            }
            return "Den";
        }

        private void PrintPlayerRankings()
        {
            var tableOfHighScores = new ConsoleTable("SPELARE      ", "HIGH SCORE");
            foreach (Player player in PlayerDatabase.ListOfTop10Players)
            {
                tableOfHighScores.AddRow($"{player.Name}", $"{player.HighScore}");
            }
            tableOfHighScores.Write(Format.Alternative);
        }
    }
}