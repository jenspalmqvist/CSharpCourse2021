using System;

namespace Adventure_Game
{
    internal class Player
    {
        private const int startingX = 1;
        private const int startingY = 1;

        public int xPos;
        public int yPos;

        public Player()
        {
            SetToStartingPos();
        }

        public void SetToStartingPos()
        {
            xPos = startingX;
            yPos = startingY;
        }

        public GameState Move(ConsoleKey key, Map map)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return MoveToFrom(xPos, yPos, xPos - 1, yPos, map);

                case ConsoleKey.DownArrow:
                    return MoveToFrom(xPos, yPos, xPos + 1, yPos, map);

                case ConsoleKey.RightArrow:
                    return MoveToFrom(xPos, yPos, xPos, yPos + 1, map);

                case ConsoleKey.LeftArrow:
                    return MoveToFrom(xPos, yPos, xPos, yPos - 1, map);

                default:
                    return GameState.Running;
            }
        }

        private GameState MoveToFrom(int fromX, int fromY, int toX, int toY, Map map)
        {
            if (Graphics.IsWall(map.GetPosContent(toX, toY)))
            {
                return GameState.Running;
            }
            else if (Graphics.IsEnemy(map.GetPosContent(toX, toY)))
            {
                return GameState.EnemyEncountered;
            }
            else if (map.GetPosContent(toX, toY) == Graphics.Coin)
            {
                map.PutCharAtPos(toX, toY, Graphics.Player);
                map.PutCharAtPos(fromX, fromY, Graphics.Empty);
                xPos = toX;
                yPos = toY;
                return GameState.CoinCollected;
            }
            else
            {
                map.PutCharAtPos(toX, toY, Graphics.Player);
                map.PutCharAtPos(fromX, fromY, Graphics.Empty);
                xPos = toX;
                yPos = toY;
                return GameState.Running;
            }
        }

        public void BackToStart(Map map)
        {
            map.PutCharAtPos(xPos, yPos, Graphics.Empty);
            map.PutCharAtPos(startingX, startingY, Graphics.Player);
            SetToStartingPos();
        }
    }
}