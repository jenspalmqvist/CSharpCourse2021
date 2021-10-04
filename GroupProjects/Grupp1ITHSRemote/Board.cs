using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Group1Game
{
    public class Board
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public Player CurrentPlayer { get; set; }
        public int BoardSize { get; set; }
        public string[,] Boardfield { get; set; }

        public Board()
        {
            Rows = 5;
            Cols = 5;
        }
        public Board(int boardSize)
        {          
            BoardSize = boardSize;
            Boardfield = new string[boardSize, boardSize];
        }        
        public void ResetBoard()
        {  
            Console.WriteLine("Game is starting!");

            for (int x = 0; x < BoardSize-1; x++)
            {
                for (int y = 0; y < BoardSize-1; y++)
                {
                    Boardfield[x, y] = ".";
                    //Console.SetCursorPosition(x, y);
                }                
            }
            Console.WriteLine("\n\nPress any key to exit...");       
        }
        public void PrintBoard(Player player1, Player player2, bool currentPlayer)
        {
            Console.Clear();
            Console.WriteLine();
            for (int x = BoardSize-1; x >= 0; x--)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    if(x == BoardSize-1 && y == BoardSize-1)
                    {
                        Boardfield[x, y] = "F";
                        Console.Write(Boardfield[x, y]);
                        continue;
                    }
                    if (x == player1.playerRow && y == player1.playerColumn && (x == player2.playerRow && y == player2.playerColumn))
                    {
                        Boardfield[x, y] = "$";
                    }
                    else if (x == player1.playerRow && y == player1.playerColumn)
                    {
                        Boardfield[x, y] = player1.BoardSign;
                    }
                    else if (x == player2.playerRow && y == player2.playerColumn)
                    {
                        Boardfield[x, y] = player2.BoardSign;
                    }
                    else if (Boardfield[x, y] == "O")
                        Boardfield[x, y] = "O";
                    else if (Boardfield[x, y] == "!")
                        Boardfield[x, y] = "!";
                    else if (Boardfield[x, y] == "@")
                        Boardfield[x, y] = "@";
                    else if (Boardfield[x, y] == "W")
                        Boardfield[x, y] = "W";
                    else
                        Boardfield[x, y] = ".";
                    Console.Write(Boardfield[x,y]);          
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            if(currentPlayer == true)
            {
                Console.WriteLine(player1.Name);
                Console.Write(player1.playerRow + " , ");
                Console.WriteLine(player1.playerColumn);
                Console.WriteLine("You have " + player1.NumberOfPickaxes + " Pickaxes");
                Console.WriteLine("You have " + player1.shoes + " SpeedShoes");
            }
            else 
            {
                Console.WriteLine(player2.Name);
                Console.Write(player2.playerRow + " , ");
                Console.WriteLine(player2.playerColumn);
                Console.WriteLine("You have " + player2.NumberOfPickaxes + " Pickaxes");
                Console.WriteLine("You have " + player2.shoes + " SpeedShoes");
            }
        }
        public void PlayerMovement(Player currentplayer)
        {
            bool validMove = false;
            while (validMove == false)
            {
                Console.SetCursorPosition(0, 12);
                ConsoleKey input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.A:
                        validMove = PlayerGoLeft(currentplayer);
                        break;
                    case ConsoleKey.S:
                        validMove = PlayerGoDown(currentplayer);
                        break;
                    case ConsoleKey.D:
                        validMove = PlayerGoRight(currentplayer);
                        break;
                    case ConsoleKey.W:
                        validMove = PlayerGoUp(currentplayer);
                        break;
                }
            }
        }
        
        public bool PlayerGoRight(Player currentPlayer)
        {
            if (currentPlayer.playerColumn < BoardSize-1)
            { 
                string a = Boardfield[currentPlayer.playerRow, currentPlayer.playerColumn + 1];
                if (a != "O")
                {
                    currentPlayer.playerColumn++;
                    ItemCheck(currentPlayer, a);
                    return true;
                }
                else if (a == "O" && currentPlayer.NumberOfPickaxes > 0)
                {
                    currentPlayer.UsePickaxe();
                    currentPlayer.playerColumn++;
                    return true;
                }
            }
            return false;            
        }
        public bool PlayerGoLeft(Player currentPlayer)
        {

            if (currentPlayer.playerColumn > 0)
            {
                string a = Boardfield[currentPlayer.playerRow, currentPlayer.playerColumn - 1];
                if (a != "O") 
                {
                    currentPlayer.playerColumn--;
                    ItemCheck(currentPlayer, a);
                    return true;
                }
                else if (a == "O" && currentPlayer.NumberOfPickaxes > 0)
                {
                    currentPlayer.UsePickaxe();
                    currentPlayer.playerColumn--;
                    return true;
                }
            }
            return false;
        }
        public bool PlayerGoUp(Player currentPlayer)
        {
            if(currentPlayer.playerRow < BoardSize-1)
            {
                string a = Boardfield[currentPlayer.playerRow + 1, currentPlayer.playerColumn];
                if(a != "O")
                {
                    currentPlayer.playerRow++;
                    ItemCheck(currentPlayer, a);
                    return true;
                }
                else if (a == "O" && currentPlayer.NumberOfPickaxes > 0)
                {
                    currentPlayer.UsePickaxe();
                    currentPlayer.playerRow++;
                    return true;
                }
            }
            return false;
        }
        public bool PlayerGoDown(Player currentPlayer)
        {
            if(currentPlayer.playerRow > 0)
            {
                string a = Boardfield[currentPlayer.playerRow -1 , currentPlayer.playerColumn];
                if(a != "O")
                { 
                    currentPlayer.playerRow--;
                    ItemCheck(currentPlayer, a);

                    return true;
                }
                else if (a == "O" && currentPlayer.NumberOfPickaxes > 0)
                {
                    currentPlayer.UsePickaxe();
                    currentPlayer.playerRow--;
                    return true;
                }
            }
            return false;
        }
        public void AddRockToBoard(Board board)
        {
            Rock smallRock = new Rock(2, 2);
            Rock bigrock = new Rock(3, 2);
            Rock mediumrock = new Rock(1, 2);
            int numberOfrocks = board.BoardSize - 4;
            int a;
            Random rockSize = new Random();
            for (int i = 0; i < numberOfrocks; i++)
            {
                a = rockSize.Next(1, 4);
                if (a == 1)
                    smallRock.AddRock(board);
                else if
                    (a == 2)
                    mediumrock.AddRock(board);
                else if
                    (a == 3)
                    bigrock.AddRock(board);
            }
        }
        public void AddItemToBoard(Board board)
        {
            Item item = new Item();
            int numberOfshoes = 6;
            for (int i = 0; i < numberOfshoes; i++)
            {
                item.AddItem(board);
            }
        }
        public void ItemCheck(Player currentPlayer, string a)
        {
            if (a == "!")
            {
                Random random = new Random();
                int myTal = random.Next(1, 3);
                if (myTal == 1)
                {
                    currentPlayer.GetDistanceWithSpeedShoes();
                }
                else if (myTal == 2)
                {
                    currentPlayer.PickUpPickaxe();
                }
            }
        }
        public void AddWaterToBoard(Board board)
        {
            Water smallWater = new Water(3, 1);
            Water bigWater = new Water(2, 3);
            Water mediumWater = new Water(1, 4);
            int numberOfWater = board.BoardSize - 4;
            int a;
            Random waterSize = new Random();
            for (int i = 0; i < numberOfWater; i++)
            {
                a = waterSize.Next(1, 4);
                if (a == 1)
                    smallWater.AddWater(board);
                else if
                    (a == 2)
                    mediumWater.AddWater(board);

                else if
                    (a == 3)
                    bigWater.AddWater(board);
            }
        }
        public void AddSwimGearToBoard(Board board)
        {
            SwimGear swimGear = new SwimGear();
            int numberOfSwimgear = 3;
            for (int i = 0; i < numberOfSwimgear; i++)
            {
                swimGear.AddSwimGear(board);
            }
        }
        public bool CheckIfWin(Player currentPlayer) //nytt
        {
            if (currentPlayer.playerRow == BoardSize - 1 && currentPlayer.playerColumn == BoardSize - 1)
            {
                Console.WriteLine($"{currentPlayer} has won!");             
            }
            return true;
        }
    }
}