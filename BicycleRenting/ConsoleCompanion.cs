using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRenting
{
    public enum CharType
    {
        Letter,
        Digit
    }

    public class ConsoleCompanion
    {
        public int AskForInt(string question = "Mata in en siffra", string errorMessage = "")
        {
            (int left, int top) = (Console.CursorLeft, Console.CursorTop);
            int number;
            bool validInput = true;

            do
            {
                if (!validInput)
                {
                    WriteError(string.IsNullOrWhiteSpace(errorMessage) ? "Felaktig inmatning" : errorMessage);
                }
                ClearCurrentConsoleLine(top);
                Console.Write($"{question}: ");
                validInput = int.TryParse(Console.ReadLine(), out number);
            } while (!validInput);
            return number;
        }

        public char AskForChar(string question = "Mata in ett tecken: ")
        {
            (int left, int top) = (Console.CursorLeft, Console.CursorTop);
            ClearCurrentConsoleLine(top);
            Console.Write(question);
            char character = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return character;
        }

        public char AskForChar(CharType type, string question = "Mata in ett tecken: ", string errorMessage = "")
        {
            (int left, int top) = (Console.CursorLeft, Console.CursorTop);
            char character;
            bool validInput = true;
            do
            {
                if (!validInput)
                {
                    WriteError(string.IsNullOrWhiteSpace(errorMessage) ? "Felaktig inmatning" : errorMessage);
                }
                ClearCurrentConsoleLine(top);
                Console.Write(question);
                character = Console.ReadKey().KeyChar;
                Console.WriteLine();
                validInput = type == CharType.Letter ? char.IsLetter(character) : char.IsDigit(character);
            } while (!validInput);
            return character;
        }

        public string AskForString(string question = "Mata in en textsträng: ")
        {
            (int left, int top) = (Console.CursorLeft, Console.CursorTop);
            Console.Write(question);
            return Console.ReadLine();
        }

        public int AskForInt(int min, int max, string question = "Mata in ett heltal: ", string errorMessage = "")
        {
            (int left, int top) = (Console.CursorLeft, Console.CursorTop);

            int result;
            bool validInput = true;
            do
            {
                if (!validInput)
                {
                    WriteError(string.IsNullOrWhiteSpace(errorMessage) ? "Felaktig inmatning" : errorMessage);
                }
                ClearCurrentConsoleLine(top);
                Console.Write(question);
                validInput = int.TryParse(Console.ReadLine(), out result);
            } while (!validInput || result < min || result > max);
            return result;
        }

        public double AskForDouble(string question = "Mata in ett decimaltal: ", string errorMessage = "")
        {
            (int left, int top) = (Console.CursorLeft, Console.CursorTop);

            double result;
            bool validInput = true;
            do
            {
                if (!validInput)
                {
                    WriteError(string.IsNullOrWhiteSpace(errorMessage) ? "Felaktig inmatning" : errorMessage);
                }

                ClearCurrentConsoleLine(top);
                Console.Write(question);
                validInput = double.TryParse(Console.ReadLine(), out result);
            } while (!validInput);
            return result;
        }

        public void WriteError(string errorMessage = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        public void WriteWarning(string warningMessage = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(warningMessage);
            Console.ResetColor();
        }

        public void WriteSuccess(string successMessage = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(successMessage);
            Console.ResetColor();
        }

        public void WriteAtPosition(int left, int top, string message)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(message);
        }

        public void WriteAtPosition(int left, string message)
        {
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(message);
        }

        public void ClearCurrentConsoleLine(int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
        }

        public int CreateMenu(string[] options, bool canCancel = false, int startX = 8, int startY = 15, int optionsPerColumn = 3, int columnSpacing = 14, bool enumerate = true)
        {
            int currentSelection = 1;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(i / optionsPerColumn >= 1 ? startX + columnSpacing * (i / optionsPerColumn) : startX, startY + i % optionsPerColumn);

                    if (i + 1 == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(enumerate ? $"{i + 1}. {options[i]}" : options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection - 1 % optionsPerColumn > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection % optionsPerColumn <= optionsPerColumn && currentSelection < options.Length)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection - 1 >= optionsPerColumn)
                                currentSelection -= optionsPerColumn;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection - 1 + optionsPerColumn < options.Length)
                                currentSelection += optionsPerColumn;
                            else if (optionsPerColumn < options.Length)
                                currentSelection = options.Length;
                            break;
                        }
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (options.Length >= 1)
                        {
                            return 1;
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (options.Length >= 2)
                        {
                            return 2;
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (options.Length >= 3)
                        {
                            return 3;
                        }
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (options.Length >= 4)
                        {
                            return 4;
                        }
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        if (options.Length >= 5)
                        {
                            return 5;
                        }
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        if (options.Length >= 6)
                        {
                            return 6;
                        }
                        break;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        if (options.Length >= 7)
                        {
                            return 7;
                        }
                        break;

                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        if (options.Length >= 8)
                        {
                            return 8;
                        }
                        break;

                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        if (options.Length >= 9)
                        {
                            return 9;
                        }
                        break;

                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter || (key != ConsoleKey.Escape && canCancel));

            Console.CursorVisible = true;

            return currentSelection;
        }

        public (int, int) NavigateGrid(int rows, int columns, int left, int top, ConsoleColor color = ConsoleColor.Red)
        {
            Console.CursorVisible = false;
            (int currentRow, int currentCol, bool exitGrid) = (0, 0, false);
            (int previousRow, int previousCol) = (currentRow, currentCol);
            //bool exitGrid = false
            while (!exitGrid)
            {
                Console.ResetColor();
                Console.SetCursorPosition(previousCol + left, previousRow + top);
                Console.Write(' ');
                Console.ForegroundColor = color;
                Console.SetCursorPosition(currentCol + left, currentRow + top);
                Console.Write('@');
                (previousCol, previousRow) = (currentCol, currentRow);
                ConsoleKey key = Console.ReadKey(true).Key;
                (currentRow, currentCol, exitGrid) = GetUserInput(key, currentCol, currentRow, rows, columns);
            }
            return (0, 0);
        }

        private (int, int, bool) GetUserInput(ConsoleKey key, int currentCol, int currentRow, int rows, int columns) => key switch
        {
            ConsoleKey.UpArrow => currentRow - 1 < 0 ? (currentRow, currentCol, false) : (currentRow - 1, currentCol, false),
            ConsoleKey.DownArrow => currentRow + 1 > rows ? (currentRow, currentCol, false) : (currentRow + 1, currentCol, false),

            ConsoleKey.LeftArrow => currentCol - 1 < 0 ? (currentRow, currentCol, false) : (currentRow, currentCol - 1, false),
            ConsoleKey.RightArrow => currentCol + 1 > rows ? (currentRow, currentCol, false) : (currentRow, currentCol + 1, false),

            ConsoleKey.NumPad1 => (currentRow + 1 > rows || currentCol - 1 < 0) ? (currentRow, currentCol, false) : (currentRow + 1, currentCol - 1, false),
            ConsoleKey.NumPad2 => currentRow + 1 > rows ? (currentRow, currentCol, false) : (currentRow + 1, currentCol, false),
            ConsoleKey.NumPad3 => (currentRow + 1 > rows || currentCol + 1 > columns) ? (currentRow, currentCol, false) : (currentRow + 1, currentCol + 1, false),
            ConsoleKey.NumPad4 => currentCol - 1 < 0 ? (currentRow, currentCol, false) : (currentRow, currentCol - 1, false),
            ConsoleKey.NumPad6 => currentCol + 1 > rows ? (currentRow, currentCol, false) : (currentRow, currentCol + 1, false),
            ConsoleKey.NumPad7 => (currentRow - 1 < 0 || currentCol - 1 < 0) ? (currentRow, currentCol, false) : (currentRow - 1, currentCol - 1, false),
            ConsoleKey.NumPad8 => currentRow - 1 < 0 ? (currentRow, currentCol, false) : (currentRow - 1, currentCol, false),
            ConsoleKey.NumPad9 => (currentRow - 1 < 0 || currentCol + 1 > columns) ? (currentRow, currentCol, false) : (currentRow - 1, currentCol + 1, false),
            ConsoleKey.Escape => (0, 0, true),
            ConsoleKey.Enter => (currentRow, currentCol, true),

            _ => (currentRow, currentCol, false),
        };
    }
}