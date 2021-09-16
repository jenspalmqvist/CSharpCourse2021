using System;

namespace MethodsAndLists
{
    public class GuessingGame
    {
        public int GuessesLeft = 0;
        public int CorrectGuess = 0;
        public int NumberOfGuesses = 0;
        public bool retry = true;

        public GuessingGame(int correct, int numberOfGuesses)
        {
            if (correct <= 0 || numberOfGuesses <= 0)
                throw new ArgumentException();
            NumberOfGuesses = numberOfGuesses;
            GuessesLeft = numberOfGuesses;
            CorrectGuess = correct;
        }

        public object Guess(int guess)
        {

            while (GuessesLeft > 0)
            {
                if (GuessesLeft == 0)
                {
                    return GuessResult.Fail;
                }

                if (guess > CorrectGuess)
                {
                    GuessesLeft--;
                    return GuessResult.Higher;
                }
                else if (guess < CorrectGuess)
                {
                    GuessesLeft--;
                    return GuessResult.Lower;
                }
                else
                {
                    GuessesLeft--;
                    return GuessResult.Success;
                }
            }
            throw new Exception();


        }
    }
    public class GuessResult
    {
        public static object Higher;
        public static object Lower;
        public static object Success;
        public static object Fail;
    }
}