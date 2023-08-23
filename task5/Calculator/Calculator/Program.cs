using Microsoft.Extensions.Configuration;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Startup().Configuration;

            Console.WriteLine("Welcome to Calculator application!");

            while (true)
            {
                Console.WriteLine($"1) To work manually press: y \n2) To read from file press: f \n3) To exit press: x");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "y":
                        CalculatorBase<double> manualCalculator = new ManualCalculator(Console.ReadLine, Console.WriteLine);
                        double manualResult = manualCalculator.Calculate();
                        Console.WriteLine($"Result: {manualResult}\n");

                        break;
                    case "f":
                        string inputPath = config.GetValue<string>("FilePaths:DefaultInputPath");
                        string outputPath = config.GetValue<string>("FilePaths:DefaultOutputPath");

                        CalculatorBase<bool> fileCalculator = new FileCalculator(Console.ReadLine, Console.WriteLine, inputPath, outputPath);

                        bool fileResult = fileCalculator.Calculate();
                        Console.WriteLine(fileResult ? "File was successfully populated with values." : "Something went wrong!");

                        break;
                    case "x":
                        Console.WriteLine("Thanks for playing!");

                        return;
                }
            }
        }
    }
}