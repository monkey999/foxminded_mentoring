using System;

namespace GuessNum
{
    public class NumGuesser
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private static readonly Random _random = new();
        public int NumToGuess { get; private set; }

        public NumGuesser(Func<string> inputProvider, Action<string> outputProvider, int random1, int random2)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            NumToGuess = _random.Next(random1, random2);
        }

        public bool TryToGuess()
        {
            _outputProvider("Enter your guess: ");
            string input = _inputProvider() ?? string.Empty;

            if (!int.TryParse(input, out int guess))
            {
                _outputProvider("Error: please enter a valid number!");
                return false;
            }

            int signCheck = Math.Sign(guess - NumToGuess);

            switch (signCheck)
            {
                case -1:
                    _outputProvider("My number is bigger. Try again!");
                    return false;
                case 1:
                    _outputProvider("My number is smaller. Try again!");
                    return false;
                case 0:
                    _outputProvider("Congratulations! You guessed my number!");
                    break;
            }

            _outputProvider("Do you want to play again? (y/n) ");

            string playAgain = _inputProvider();

            if (playAgain.ToLower() == "y")
            {
                NumToGuess = _random.Next(0, 101);
                return false;
            }

            _outputProvider("Thanks for playing!");
            return true;
        }
    }
}
