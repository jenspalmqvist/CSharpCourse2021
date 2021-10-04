using System;
using System.Collections.Generic;

namespace Adventure_Game
{
    internal class Game
    {
        public List<Map> maps = new List<Map>();
        public int currentMapIndex = 0;
        public Map currentMap;
        public Player player;
        public List<IEnemy> enemies = new List<IEnemy>();
        public CoinTracker coinTracker;
        public HealthTracker health;

        public Game()
        {
            var level = new Level();
            var levels = level.Levels();
            foreach (var grid in levels)
            {
                maps.Add(new Map(grid));
            }

            currentMap = maps[currentMapIndex];

            player = new Player();

            health = new HealthTracker(3);

            coinTracker = new CoinTracker();
            coinTracker.TrackMap(currentMap);
            SetUp();
        }

        private void SetUp()
        {
            List<(int, int, char)> enemiesToBe = currentMap.GetEnemyPos();
            enemies.Clear();
            foreach (var enemy in enemiesToBe)
            {
                if (enemy.Item3 == Graphics.Snake)
                {
                    enemies.Add(new Snake(enemy.Item1, enemy.Item2));
                }
                else if (enemy.Item3 == Graphics.Rat)
                {
                    enemies.Add(new Rat(enemy.Item1, enemy.Item2));
                }
            }
            player.SetToStartingPos();
            currentMap.DrawMap();
        }

        public GameState Update()
        {
            GameState gameState = player.Move(GetUserInput(), currentMap);
            switch (gameState)
            {
                case GameState.CoinCollected:
                    if (coinTracker.CoinCollected() == GameState.LevelComplete)
                    {
                        currentMapIndex++;
                        if (maps.Count <= currentMapIndex)
                        {
                            return GameState.Victory;
                        }
                        else
                        {
                            currentMap = maps[currentMapIndex];
                            coinTracker.TrackMap(currentMap);
                            SetUp();
                        }
                    }
                    break;

                case GameState.EnemyEncountered:
                    player.BackToStart(currentMap);
                    if (TakeDamageCheckDead()) return GameState.GameOver;
                    break;

                default:
                    break;
            }

            foreach (IEnemy enemy in enemies)
            {
                if (enemy.Move(currentMap) == GameState.EnemyEncountered)
                {
                    player.BackToStart(currentMap);
                    if (TakeDamageCheckDead())
                    {
                        return GameState.GameOver;
                    }
                }
            }
            currentMap.DrawMap();
            Console.WriteLine(health.GetCurretnHealthString());

            return GameState.Running;
        }

        private bool TakeDamageCheckDead()
        {
            health.TakeDamage(1);
            if (health.PlayerIsDead())
            { return true; }
            return false;
        }

        private ConsoleKey GetUserInput()
        {
            return Console.ReadKey().Key;
        }
    }
}