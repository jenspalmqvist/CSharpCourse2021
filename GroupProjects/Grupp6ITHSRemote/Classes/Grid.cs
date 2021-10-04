using RollSpelGrupp6.Classes.UIs;
using RollSpelGrupp6.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RollSpelGrupp6.Classes
{
    internal class Grid
    {
        public int GridOffsetRight { get; } = 30;
        public Monster LastAddedMonster { get; set; }
        public UI UI { get; set; }
        public Player Player { get; set; }
        public char[][] GameGrid { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<Monster> Boss { get; set; }
        public int MaxMonstersOnBoard { get; set; }
        public bool IsMonsterSpawning { get; set; }
        public bool IsRespawnedMonsterPrinted { get; set; }
        public bool IsRespawnedBossPrinted { get; set; }
        public bool IsBossSpawning { get; set; }
        public bool IsFightUICurrentUI { get; set; }
        public readonly object MonsterLock = new object();

        public Grid(Player player, UI ui)
        {
            Player = player;
            UI = ui;
            MaxMonstersOnBoard = 4;
            GameGrid = new char[18][];
            for (int i = 0; i < GameGrid.Length; i++)
            {
                GameGrid[i] = new char[90];
            }
            Boss = new List<Monster>();

            Monsters = new List<Monster>();

            IsMonsterSpawning = false;
            IsBossSpawning = false;
            IsFightUICurrentUI = false;
            IsRespawnedMonsterPrinted = true;
            IsRespawnedBossPrinted = true;
        }

        public void GenerateGrid()
        {
            Console.CursorVisible = false;
            GameGrid[0] = GameGrid[0].Select(c => '_').ToArray();
            GameGrid[^1] = GameGrid[^1].Select(c => '_').ToArray();
            for (int i = 1; i < GameGrid.Length - 1; i++)
            {
                for (int j = 0; j < GameGrid[i].Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            GameGrid[i][j] = '|';
                            break;

                        case 89:
                            GameGrid[i][j] = '|';
                            break;

                        default:
                            GameGrid[i][j] = ' ';
                            break;
                    }
                }
            }
            for (int i = 13; i < GameGrid.Length; i++)
            {
                GameGrid[i][53] = '_';
                GameGrid[i][53] = '|';
            }
            for (int i = 57; i < GameGrid[12].Length - 1; i++)
            {
                GameGrid[12][i] = '_';
            }
            GameGrid[^1][0] = '|';
            GameGrid[^1][^1] = '|';
            SpawnBoss();
            for (int i = 0; i < MaxMonstersOnBoard; i++)
            {
                SpawnMonster();
            }
        }

        public void PrintGrid()
        {
            for (int i = 0; i < GameGrid.Length; i++)
            {
                Console.SetCursorPosition(30, i);
                for (int j = 0; j < GameGrid[i].Length; j++)
                {
                    bool isMonster = false;
                    foreach (Monster monster in Monsters)
                    {
                        if (monster.Location.Equals(new Coordinate(i, j + GridOffsetRight)))
                        {
                            isMonster = true;
                            Printer.PrintInColor(ConsoleColor.DarkYellow, 'x', false);
                            break;
                        }
                    }
                    if (Boss.Count != 0 && Boss[0].Location.Equals(new Coordinate(i, j + GridOffsetRight)))
                    {
                        isMonster = true;
                        Printer.PrintInColor(ConsoleColor.Red, 'X', false);
                    }
                    if (!isMonster)
                    {
                        Printer.PrintInColor(ConsoleColor.DarkGray, GameGrid[i][j], false);
                    }
                }
                Console.Write("\n");
            }
        }

        public void RespawnMonster()
        {
            lock (MonsterLock)
            {
                Thread.Sleep(5000);
                LastAddedMonster = SpawnMonster();
                if (!IsFightUICurrentUI)
                {
                    Console.SetCursorPosition(LastAddedMonster.Location.Col, LastAddedMonster.Location.Row);
                    Printer.PrintInColor(ConsoleColor.DarkYellow, 'x', false);
                    IsRespawnedMonsterPrinted = true;
                }
                IsMonsterSpawning = false;
            }
        }

        public void RespawnBoss()
        {
            lock (MonsterLock)
            {
                Thread.Sleep(10000);
                Monster spawnedMonster = SpawnBoss();
                if (!IsFightUICurrentUI)
                {
                    Console.SetCursorPosition(spawnedMonster.Location.Col, spawnedMonster.Location.Row);
                    Printer.PrintInColor(ConsoleColor.Red, 'X', false);
                    Console.SetCursorPosition(0, 18);
                    UI.PrintUserInformation();
                }
                IsBossSpawning = false;
            }
        }

        public Monster SpawnMonster()
        {
            bool monsterAdded = false;
            Monster monsterToReturn = new Monster(1, 1, 1);

            while (!monsterAdded)
            {
                Monster monster = new Monster(Player.Level, Generator.RandomNumber(1, 15), Generator.RandomNumber(1, 88));
                if (Monsters.Count == 0 &&
                    !monster.Location.Equals(Player.Location) &&
                    !(GameGrid[monster.Location.Row][monster.Location.Col - GridOffsetRight] is '_') &&
                    !(GameGrid[monster.Location.Row][monster.Location.Col - GridOffsetRight] is '|'))
                {
                    monster.DressUp();
                    Monsters.Add(monster);
                    return monster;
                }
                foreach (Monster monsterInList in Monsters)
                {
                    if (!monster.Location.Equals(monsterInList.Location) &&
                        !monster.Location.Equals(Player.Location) &&
                        !(GameGrid[monster.Location.Row][monster.Location.Col - GridOffsetRight] is '_') &&
                        !(GameGrid[monster.Location.Row][monster.Location.Col - GridOffsetRight] is '|'))
                    {
                        monster.DressUp();
                        Monsters.Add(monster);
                        monsterAdded = true;
                        return monster;
                    }
                }
            }
            return monsterToReturn;
        }

        public Monster SpawnBoss()
        {
            bool monsterAdded = false;
            Monster monsterToReturn = new Monster(1, 1, 1, true);
            while (!monsterAdded)
            {
                Monster monster = new Monster(Player.Level + 1, Generator.RandomNumber(14, 16), Generator.RandomNumber(55, 88), true);
                if (Boss.Count == 0 &&
                   !monster.Location.Equals(Player.Location) &&
                   !(GameGrid[monster.Location.Row][monster.Location.Col - GridOffsetRight] is '_') &&
                   !(GameGrid[monster.Location.Row][monster.Location.Col - GridOffsetRight] is '|'))
                {
                    monster.DressUp();
                    Boss.Add(monster);
                    return monster;
                }
            }
            return monsterToReturn;
        }
    }
}