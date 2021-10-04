using System;

namespace Labyrintho
{
    //class Enemy : IConsoleDrawable
    //{
    //    private Tile enemyMarker;
    //    public Position EnemyPosition { get; set; }
    //    //public int numberOfSteps { get; set; } = 0;
    //    private int enemyDirection;

    //    public Enemy(Position startingPosition, Tile newEnemyMarker)
    //    {
    //        EnemyPosition = startingPosition;
    //        enemyMarker = newEnemyMarker;
    //        enemyDirection = 0;
    //    }

    //    public void MoveEnemy()
    //    {
    //        Random rnd = new Random();
    //        Position newPosition;
    //        bool validDir = false;
    //        while (!validDir)
    //        {
    //            switch (enemyDirection)
    //            {
    //                case (0):
    //                    {
    //                        Console.SetCursorPosition(EnemyPosition.X, EnemyPosition.Y - 1);
    //                        if (gameBoard.CheckValidPosition(newPosition) == 1)
    //                            enemy.UpdatePosition;
    //                        validDir = true;
    //                        break;
    //                    }
    //                case (1):
    //                    {
    //                        newPosition = new Position(EnemyPosition.X + 1, EnemyPosition.Y);
    //                        if (gameBoard.CheckValidPosition(newPosition) == 1)
    //                            enemy.UpdatePosition;
    //                        validDir = true;
    //                        break;
    //                    }
    //                case (2):
    //                    {
    //                        newPosition = new Position(EnemyPosition.X, EnemyPosition.Y + 1);
    //                        if (gameBoard.CheckValidPosition(newPosition) == 1)
    //                            enemy.UpdatePosition;
    //                        validDir = true;
    //                        break;
    //                    }
    //                case (3):
    //                    {
    //                        newPosition = new Position(EnemyPosition.X + 1, EnemyPosition.Y);
    //                        if (gameBoard.CheckValidPosition(newPosition) == 1)
    //                            enemy.UpdatePosition;
    //                        validDir = true;
    //                        break;
    //                    }
    //                default:
    //                    {
    //                        Console.Write("ERROR!");
    //                        break;
    //                    }
    //            }
    //            EnemyDirection = rnd.Next(0, 4);
    //        }

    //    }

    //    public void UpdatePosition(Position checkPosition)
    //    {
    //        EnemyPosition = checkPosition;
    //    }

    //    public void Draw()
    //    {
    //        Console.SetCursorPosition(EnemyPosition.X, EnemyPosition.Y);
    //        Console.ForegroundColor = enemyMarker.Color;
    //        Console.Write(enemyMarker.TileMarker);
    //    }
    //}
}
