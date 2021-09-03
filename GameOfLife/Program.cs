using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static int size = 60;
        static int[][] currentBoard = new int[size][];

        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(62, 62);
            InitializeBoard();

            while (true)
            {
                UpdateWindow();
                GetNextBoardState();
            }
        }

        private static int[][] CloneArray(int[][] original)
        {
            int[][] cloneArray = new int[size][];
            for (int i = 0; i < original.Length; i++)
            {
                cloneArray[i] = new int[size];
                for (int j = 0; j < original.Length; j++)
                {
                    cloneArray[i][j] = original[i][j];
                }
            }
            return cloneArray;
        }

        private static void GetNextBoardState()
        {
            int[][] futureBoard = CloneArray(currentBoard);

            for (int row = 0; row < currentBoard.Length; row++)
            {
                int previousRow = row == 0 ? size - 1 : row - 1;
                int middleRow = row;
                int nextRow = row == size - 1 ? 0 : row + 1;
                for (int col = 0; col < currentBoard.Length; col++)
                {
                    int previousColumn = col == 0 ? size - 1 : col - 1;
                    int middleColumn = col;
                    int nextColumn = col == size - 1 ? 0 : col + 1;
                    int liveNeighbours = currentBoard[previousRow][previousColumn]
                        + currentBoard[previousRow][middleColumn]
                        + currentBoard[previousRow][nextColumn]
                        + currentBoard[middleRow][previousColumn]
                        + currentBoard[middleRow][nextColumn]
                        + currentBoard[nextRow][previousColumn]
                        + currentBoard[nextRow][middleColumn]
                        + currentBoard[nextRow][nextColumn];

                    if (currentBoard[row][col] is 1 && liveNeighbours is 2 or 3)
                    {
                        futureBoard[row][col] = 1;
                    }
                    else if (currentBoard[row][col] is 0 && liveNeighbours is 3)
                    {
                        futureBoard[row][col] = 1;
                    }
                    else
                    {
                        futureBoard[row][col] = 0;
                    }
                }
            }
            currentBoard = CloneArray(futureBoard);
        }

        private static void UpdateWindow()
        {
            Console.SetCursorPosition(0, 0);
            foreach (int[] row in currentBoard)
            {
                foreach (int col in row)
                {
                    Console.Write(col == 0 ? ' ' : '*');
                }
                Console.WriteLine();
            }
        }

        private static void InitializeBoard()
        {
            for (int i = 0; i < size; i++)
            {
                currentBoard[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    currentBoard[i][j] = rand.Next(2);
                }
            }
        }
    }
}