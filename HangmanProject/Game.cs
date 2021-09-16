using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game
    {
        static string[] wordArray = { "HANGMAN", "ICECREAM", "TRAIN", "DEVELOPER", "NONSENSE" };
        static string wordtoGuess;
        static int incorrectGuesses = 0;
        static char[] hiddenWord;
        static List<char> guessedLetters = new List<char>();
        static bool gameOver = false;

        public string WordToGuess { get; set; }
        public char[] HiddenWord { get; set; }

        public Game()
        {
            GameSetup();
        }

        public void GameSetup()
        {
            Random randomNumber = new Random();
            WordToGuess = wordArray[randomNumber.Next(wordArray.Length)];
            HiddenWord = new char[WordToGuess.Length];
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                HiddenWord[i] = '_';
            }
        }
    }
}