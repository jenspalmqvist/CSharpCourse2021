using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Group1Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Super duper mega game";
            int boardSize = 20;
            bool currentPlayer = true;
            Player player1 = new Player();
            Player player2 = new Player();
            player1.BoardSign = "J";
            player2.BoardSign = "S";
            player1.Name = "Johan";
            player2.Name = "Sven";
            Board currentGame = new Board(boardSize);
            currentGame.ResetBoard();
            currentGame.AddRockToBoard(currentGame);
            currentGame.AddWaterToBoard(currentGame);
            currentGame.AddSwimGearToBoard(currentGame);

           
            
            List<IPassable> PassableObjects = new List<IPassable>();
            List<ICollectable> CollectableItems = new List<ICollectable>();

            currentGame.AddItemToBoard(currentGame);
            currentGame.PrintBoard(player1, player2, currentPlayer);
            while (true)
            {
                if(currentPlayer == true)
                {
                    for (int i = 0; i < player1.NumberOfMoves; i++)
                    {
                        currentGame.PlayerMovement(player1);
                        currentGame.PrintBoard(player1, player2, currentPlayer);
                    }
                    currentPlayer = false;
                }
                else
                {
                    for (int i = 0; i < player2.NumberOfMoves; i++)
                    {
                        currentGame.PlayerMovement(player2);
                        currentGame.PrintBoard(player1, player2, currentPlayer);
                    }
                    currentPlayer = true;
                }
                currentGame.PrintBoard(player1, player2, currentPlayer);
                //if (currentGame.CheckIfWin(currentPlayer))
                //{
                //    break;
                //}
            }
        }

    }
}
