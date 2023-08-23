using System;
using System.IO;
using Xunit;

namespace Calculator.Tests
{
    public class FileCalculator_Tests
    {
        [Fact]
        public void ProcessFile_ShouldCalculateValuesFromFile_AndWriteResultsToOutputFile()
        {
            string inputPath = "C:\\Users\\Andrey\\source\\repos\\task5\\Calculator\\calcInputDataTest.txt";
            string outputPath = "C:\\Users\\Andrey\\source\\repos\\task5\\Calculator\\calcResDataTest.txt";

            CalculatorBase<bool> fileCalculator = new FileCalculator(Console.ReadLine, Console.WriteLine, inputPath, outputPath);

            bool fileResult = fileCalculator.Calculate();

            Assert.True(File.Exists(outputPath));
            Assert.True(fileResult);

            string[] expectedResults =
            {
                "3*(2+5*(3-1))-6/3 = 34",
                 "(3+2)*2 = 10",
                 "1+2*(3+2) = 11",
                 "2+15/3+4*2 = 15",
                 "1+2*3 = 7",
                 "2*3 = 6",
                 "1+2 = 3",
                 "10-5 = 5",
                 "12/4 = 3",
                 "1+(2*3) = 7",
                 "1+x+4 = Exception. Wrong input.",
                 "-5*2 = -10"
            };

            string[] actualResults = File.ReadAllLines(outputPath);

            Assert.Equal(expectedResults.Length, actualResults.Length);

            for (int i = 0; i < expectedResults.Length; i++)
            {
                Assert.Equal(expectedResults[i], actualResults[i]);
            }
        }

        [Fact]
        public void TestIFThrowsArgumentExceptionWhenInvalidFilePaths()
        {
            string inputPath = "";
            string outputPath = "";

            Assert.Throws<ArgumentException>(() => new FileCalculator(Console.ReadLine, Console.WriteLine, inputPath, outputPath));
        }

        [Fact]
        public void TestIfDirectoryDoesNotExist()
        {
            string inputPath = "D:\\Uses\\Andrey\\source\\repos\\task5\\Phishing\\";
            string outputPath = "C:\\Users\\Andre\\souce\repos\\task5\\AnonymousHackers\\";

            Assert.False(Directory.Exists(inputPath));
            Assert.False(Directory.Exists(outputPath));
        }
    }
}
