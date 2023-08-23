using System;
using System.IO;
using System.Linq;
using task3;

namespace MaxSumLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args.FirstOrDefault();

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                filePath = Console.ReadLine();
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var maxSumInLine = new MaxSumInLine(filePath);

            var maxSumLineNumber = maxSumInLine.GetMaxSumLine();

            Console.WriteLine($"{maxSumLineNumber.Item1} {maxSumLineNumber.Item2}");

            maxSumInLine.DisplayWrongLineNumbers();

            Console.ReadLine();
        }
    }
}
