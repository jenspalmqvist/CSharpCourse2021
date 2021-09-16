using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine(game.WordToGuess);

            //game.WordToGuess = "Hej!";
            //while (!gameOver && incorrectGuesses < 6)
            //{
            //    gameOver = true;
            //    char guess = AskForPlayerGuess();
            //    CheckGuess(guess);
            //    RefreshWindow();
            //    CheckVictory();
            //}
            //if (incorrectGuesses >= 6)
            //{
            //    Console.WriteLine("Dåligt.");
            //}
            //else
            //{
            //    Console.WriteLine("Hipp hurra!");
            //}
        }

        private static void CheckVictory()
        {
            //for (int i = 0; i < hiddenWord.Length; i++)
            //{
            //    if (hiddenWord[i] == '_') { gameOver = false; }
            //}
        }

        private static void RefreshWindow()
        {
            //Console.Clear();
            //Console.WriteLine(hiddenWord);
            //Console.WriteLine();
            //Console.WriteLine($"Antal felgissningar: {incorrectGuesses}");
            //Console.WriteLine();
            //Console.Write("Gissade bokstäver: ");
            //foreach (char c in guessedLetters)
            //{
            //    Console.Write($"{c} ");
            //}
        }

        private static void CheckGuess(char guess)
        {
            //bool correctGuess = false;
            //for (int i = 0; i < wordtoGuess.Length; i++)
            //{
            //    if (guess == wordtoGuess[i])
            //    {
            //        hiddenWord[i] = guess;
            //        correctGuess = true;
            //    }
            //}
            //if (!correctGuess)
            //{
            //    incorrectGuesses++;
            //}
            //guessedLetters.Add(guess);
        }

        //private static char AskForPlayerGuess()
        //{
        //while (true)
        //{
        //    Console.Write("Gissa en bokstav: ");
        //    string guessedCharacter = Console.ReadLine().ToUpper();
        //    if (char.TryParse(guessedCharacter, out char character) && char.IsLetter(character) && !guessedLetters.Contains(character))
        //    {
        //        return character;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Felaktig inmatning!");
        //    }
        //}
        //}
    }
}