using System;
using System.Collections.Generic;

namespace Labyrintho
{
    class GameBoard : IConsoleDrawable
    {
        #region private variables
        private Tile[,] gameBoard;
        private Random random = new Random();
        public List<TileObstacle> obstacles = new List<TileObstacle>();
        #endregion

        #region Public Props 
        public int GameBoardWidth { get; set; }
        public int GameBoardHeight { get; set; }
        #endregion

        public GameBoard( int width, int height, int numberOfObstacles )
        {
            // * 2 + 1, är en hack för att lösa att randomMaze spottar ut en dubbelt stor int[,]
            GameBoardWidth = width * 2 + 1;
            GameBoardHeight = height * 2 + 1;
            gameBoard = new Tile[GameBoardHeight, GameBoardWidth];
            FillGameBoard(new Tile(' ', ConsoleColor.Blue, false));
            gameBoard[1, 1] = new Tile('█', ConsoleColor.Green, false);
            GenerateObstacles(numberOfObstacles);
        }

        public void GenerateObstacles(int numberOfObstacles)
        {
            for (int i = 0; i < numberOfObstacles; i++)
            {
                TileObstacle obstacle = new TileObstacle('O', ConsoleColor.Blue, false, -5);
                TileObstacle obstacle2 = new TileObstacle('X', ConsoleColor.Blue, false, +5);

                obstacle.position = findEmptyTile();
                obstacles.Add(obstacle);
                obstacle2.position = findEmptyTile();
                obstacles.Add(obstacle2);
            }
        }

        public Position findEmptyTile()
        {
            int x, y;

            while (true)
            {
                x = random.Next(0, GameBoardWidth - 1);
                y = random.Next(0, GameBoardHeight - 1);

                if (!gameBoard[y, x].IsWall)
                {
                    break;
                }
            }

            return new Position(x, y);
        }

        public int CheckValidPosition(Position checkPosition)
        {
            if (checkPosition.X < 0 || checkPosition.X > GameBoardWidth - 1)
                return -1;

            if (checkPosition.Y < 0 || checkPosition.Y > GameBoardHeight - 1)
                return -1;

            if (gameBoard[checkPosition.Y, checkPosition.X].IsWall)
                return -2;

            foreach (TileObstacle obstacle in obstacles)
            {
                if (obstacle.position.Equals(checkPosition))
                {
                    return obstacle.StepValue;
                }
            }
            
            return 0;
        }
        
        public bool CheckWinPosition(Position checkPosition)
        {
            if (gameBoard[checkPosition.Y, checkPosition.X] == gameBoard[1, 1])
            {
                return true;
            }
        return false;
        }


        public void FillGameBoard(Tile fillerTile)
        {
            int[,] generatedBoard = RandomMaze.GenerateBoard((GameBoardHeight - 1) / 2, (GameBoardWidth - 1) / 2);
            //int[,] generatedBoard = RandomMaze.GenerateBoard(GameBoardHeight, GameBoardWidth);
            //int[,] generatedBoard = new int[,]
            //{
            //    { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            //    { 1,0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,1,0,1},
            //    { 1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1},
            //    { 0,0,0,0,1,0,0,0,1,0,1,0,1,1,0,1,0,0,0,1},
            //    { 1,1,1,1,1,1,1,0,1,0,1,0,1,1,0,1,0,1,0,1},
            //    { 1,0,0,0,0,0,0,0,1,0,1,0,1,1,0,0,1,1,0,1},
            //    { 1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,0,0,1,0,1},
            //    { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,1,0,1,0,1},
            //    { 1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1},
            //    { 1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
            //    { 1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1},
            //    { 1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1},
            //    { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            //};

            for (int i = 0; i < GameBoardWidth; i++)
            {
                for (int j = 0; j < GameBoardHeight; j++)
                {
                    if (generatedBoard[j,i] == 1)
                    {
                        gameBoard[j,i] = new Tile('█', ConsoleColor.DarkYellow, true);
                    }
                    else
                    {
                        gameBoard[j, i] = fillerTile;
                    }
                }
            }
        }

        public void WriteTileInGameBoard(Tile fillerTile, Position pos)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = fillerTile.Color;
            Console.Write(fillerTile.TileMarker);
        }

        public Tile GetTileInGameBoard( Position pos )
        {
            return gameBoard[pos.Y, pos.X];
        }
         
        public void Draw()
        {
            for (int i = 0; i < GameBoardHeight; i++)
            {
                for (int j = 0; j < GameBoardWidth; j++)
                {
                    Console.ForegroundColor = gameBoard[i, j].Color;
                    Console.Write(gameBoard[i, j].TileMarker);
                }
                Console.WriteLine();
            }

            foreach (TileObstacle obstacle in obstacles)
            {
                obstacle.Draw();
            }
        }
    }
}
