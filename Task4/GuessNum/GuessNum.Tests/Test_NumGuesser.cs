using System;
using System.IO;
using Xunit;

namespace GuessNum.Tests
{
    public class Test_NumGuesser
    {
        [Fact]
        public void GuessNum_CorrectGuess_ReturnsTrue()
        {
            int numToGuess = 50;

            var numGuesser = new NumGuesser(() => numToGuess.ToString(), _ => { }, 50, 50);

            bool guessed = numGuesser.TryToGuess();

            Assert.True(guessed);
        }

        [Fact]
        public void GuessNum_TooLowGuess_ReturnsFalse()
        {
            var numGuesser = new NumGuesser(() => "5", _ => { }, 60, 60);

            bool result = numGuesser.TryToGuess();

            Assert.False(result);
        }

        [Fact]
        public void GuessNum_TooHighGuess_ReturnsFalse()
        {
            var numGuesser = new NumGuesser(() => "60", _ => { }, 5, 5);

            bool result = numGuesser.TryToGuess();

            Assert.False(result);
        }

        [Fact]
        public void GuessNum_InvalidGuessVariableType_ReturnsFalse()
        {
            var numGuesser = new NumGuesser(() => "ewr!&#%", _ => { }, 0, 101);

            bool result = numGuesser.TryToGuess();

            Assert.False(result);
        }
    }
}
