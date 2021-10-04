using System;
using System.Diagnostics;

/*

Labyrintho: a labyrinth game created by

Emil Waara
Tobias Persson
Daniel Olsen
Iriny Metry

*/

namespace Labyrintho
{
    class Labyrintho
    {
        //Labyrinten inklusive väggar kommer bli vald storlek * 2 + 1
        //Siffrorna nedan blir antalet "rum", sedan läggs det till en vägg till höger och under varje rum (därav * 2), + 1 är för den västliga ytterväggen.
        private int gameBoardSizeX = 50;
        private int gameBoardSizeY = 20;

        private GameBoard gameBoard;
        // * 2 + 1, är en hack för att lösa att randomMaze spottar ut en dubbelt stor int[,]
        private Player player;
        //private Enemy enemy;
        private Position newPosition;

        private bool isWin = false;
        Stopwatch stopWatch = new Stopwatch();
        private int numberOfObstacles;

        public Labyrintho()
        {

            //Console.ReadLine();
            Menu menu = new Menu();
            //menu.Logo();

            //Console.Clear();
            int difficultyLevel = menu.SetDifficulty();
            switch (difficultyLevel)
            {
                case (1):
                    {
                        gameBoardSizeX = 20;
                        gameBoardSizeY = 10;
                        numberOfObstacles = 5;
                        break;
                    }
                case (2):
                    {
                        gameBoardSizeX = 25;
                        gameBoardSizeY = 15;
                        numberOfObstacles = 10;
                        break;
                    }
                case (3):
                    {
                        gameBoardSizeX = 50;
                        gameBoardSizeY = 20;
                        numberOfObstacles = 20;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
            }

            gameBoard = new GameBoard(gameBoardSizeX, gameBoardSizeY, numberOfObstacles);
            player = new Player(new Position((gameBoardSizeX - 1) * 2 + 1, (gameBoardSizeY - 1) * 2 + 1), new Tile('█', ConsoleColor.Red, false));

            //enemy = new Enemy(new Position(1, 1), new Tile('█', ConsoleColor.Blue, false));

            Console.Clear();
            gameBoard.Draw();

            while (!isWin)
            {
                Console.CursorVisible = false;      // if resize screen it will reappear. So now it will automatically dissapear again.
                player.Draw();
                newPosition = player.getInput();
                stopWatch.Start();

                int validationValue = gameBoard.CheckValidPosition(newPosition);

                switch (validationValue)
                {
                    case -2:
                    case -1:
                        break;
                    case 0:
                        break;
                    default:
                        player.numberOfSteps += validationValue;
                        break;
                }

                if ( validationValue >= 0 || validationValue < -2 )
                {
                    gameBoard.WriteTileInGameBoard(gameBoard.GetTileInGameBoard(player.PlayerPosition), player.PlayerPosition);
                    player.UpdatePosition(newPosition);
                    isWin = gameBoard.CheckWinPosition(newPosition);
                    player.numberOfSteps++;
                }

                //enemy.Draw();
                //enemy.Move();

                Console.SetCursorPosition(gameBoardSizeX * 2 + 2, gameBoardSizeY + 10);
                Console.WriteLine($"{player.numberOfSteps} steps!");
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Console.SetCursorPosition(0, gameBoardSizeY + 20);
            Console.WriteLine($"You Win with {player.numberOfSteps} steps!");
            Console.WriteLine($"{ts.Minutes} minutes and {ts.Seconds}.{ts.Milliseconds} seconds elapsed");
        }
    }
}
