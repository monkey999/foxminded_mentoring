using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace GuessNum
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Startup().Configuration;

            int minValue;
            int maxValue;

            if (config.GetChildren().Any())
            {
                minValue = config.GetValue<int>("appSettings:minValue");
                maxValue = config.GetValue<int>("appSettings:maxValue");
            }
            else
            {
                minValue = 0;
                maxValue = 101;
            }

            var numGuesser = new NumGuesser(Console.ReadLine, Console.WriteLine, minValue, maxValue);

            Console.WriteLine("Welcome to Guess My Number game!");
            Console.WriteLine("I'm thinking of a number between 0 and 100 (inclusive). Can you guess it?");

            bool guessed = false;
            while (!guessed)
            {
                guessed = numGuesser.TryToGuess();
            }
        }
    }
}
