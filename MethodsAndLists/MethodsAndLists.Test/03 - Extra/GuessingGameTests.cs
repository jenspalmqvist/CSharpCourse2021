using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class GuessingGameTests
    {
        [TestMethod]
        public void normal_play_that_ends_with_correct_guess()
        {
            var x = new GuessingGame(73, 4);
            Assert.AreEqual(4, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Higher, x.Guess(50));
            Assert.AreEqual(3, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Lower, x.Guess(80));
            Assert.AreEqual(2, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Success, x.Guess(73));
            Assert.AreEqual(1, x.GuessesLeft);
        }

        [TestMethod]
        public void normal_play_that_ends_with_game_over()
        {
            var x = new GuessingGame(46, 4);
            Assert.AreEqual(4, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Lower, x.Guess(66));
            Assert.AreEqual(3, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Lower, x.Guess(50));
            Assert.AreEqual(2, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Higher, x.Guess(30));
            Assert.AreEqual(1, x.GuessesLeft);

            Assert.AreEqual(GuessResult.Fail, x.Guess(35));
            Assert.AreEqual(0, x.GuessesLeft);
        }

        [TestMethod]
        public void should_return_correct_when_correct_guess()
        {
            var x = new GuessingGame(73, 4);
            Assert.AreEqual(GuessResult.Success, x.Guess(73));
        }

        [TestMethod]
        public void should_return_gameover_when_no_guesses_left()
        {
            var x = new GuessingGame(73, 1);
            Assert.AreEqual(GuessResult.Fail, x.Guess(5));
        }

        [TestMethod]
        public void after_a_lot_of_wrong_guesses_all_remaining_result_should_be_game_over()
        {
            var x = new GuessingGame(73, 4);

            Assert.AreEqual(GuessResult.Higher, x.Guess(5));
            Assert.AreEqual(GuessResult.Higher, x.Guess(5));
            Assert.AreEqual(GuessResult.Higher, x.Guess(5));
            Assert.AreEqual(GuessResult.Fail, x.Guess(5));

            Assert.ThrowsException<Exception>(() => x.Guess(5));
            Assert.ThrowsException<Exception>(() => x.Guess(5));
        }

        [TestMethod]
        public void after_a_lot_of_correct_guesses_all_remaining_result_should_be_game_over()
        {
            var x = new GuessingGame(73, 4);

            Assert.AreEqual(GuessResult.Higher, x.Guess(5));
            Assert.AreEqual(GuessResult.Higher, x.Guess(5));
            Assert.AreEqual(GuessResult.Higher, x.Guess(5));
            Assert.AreEqual(GuessResult.Success, x.Guess(73));

            Assert.ThrowsException<Exception>(() => x.Guess(5));
            Assert.ThrowsException<Exception>(() => x.Guess(5));
        }

        // trivial tests below...

        [TestMethod]
        public void number_of_guesses_should_not_change()
        {
            var x = new GuessingGame(73, 5);
            Assert.AreEqual(5, x.NumberOfGuesses);

            x.Guess(10);
            Assert.AreEqual(5, x.NumberOfGuesses);

            x.Guess(10);
            Assert.AreEqual(5, x.NumberOfGuesses);

            x.Guess(10);
            Assert.AreEqual(5, x.NumberOfGuesses);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        [ExpectedException(typeof(ArgumentException))]
        public void number_of_guesses_have_to_be_positive(int nrOfGuesses)
        {
            new GuessingGame(73, nrOfGuesses);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        [ExpectedException(typeof(ArgumentException))]
        public void secret_number_have_to_be_positive(int secretNumber)
        {
            new GuessingGame(secretNumber, 4);
        }
    }
}