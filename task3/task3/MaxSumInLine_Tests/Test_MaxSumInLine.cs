using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using task3;
using Xunit;

namespace MaxSumInLine_Tests
{
    public class Test_MaxSumInLine
    {
        [Theory]
        [InlineData("1.1,2.2,3.3\n4.4,5.5,6.6\n7.7,8.8,9.9")]
        [InlineData("1.1,2.2,3.3\n,,,,,,\n7.7,8.8,9.9")]
        [InlineData(" \nfwe,5.5,6.6\n7.7,8.8,9.9")]
        public void TestMaxSumInLineAndExpectedLine(string test)
        {
            string testFilePath = "C:\\Users\\Andrey\\source\\repos\\task3\\task3\\test_num_dataset.txt";

            File.WriteAllText(testFilePath, test);

            MaxSumInLine maxSumInLine = new(testFilePath);

            int expectedLine = 3;
            int actualLine = maxSumInLine.GetMaxSumLine().Item2;

            double expectedMaxSumValue = 26.4;
            double actualExpectedMaxSumValue = maxSumInLine.MaxSum;

            Assert.Equal(expectedLine, actualLine);
            Assert.Equal(expectedMaxSumValue, actualExpectedMaxSumValue);

            File.Delete(testFilePath);
        }

        [Theory]
        [InlineData("sdsf\n,,,,,,,,,,\n-12, -12, -999999\n-12,-1.55\n-999\n \n-128")]
        public void TestMaxSumInLineAndExpectedLineWithAllNegativeNums(string test)
        {
            string testFilePath = "C:\\Users\\Andrey\\source\\repos\\task3\\task3\\test_num_dataset.txt";

            File.WriteAllText(testFilePath, test);

            MaxSumInLine maxSumInLine = new(testFilePath);

            int expectedLine = 4;
            int actualLine = maxSumInLine.GetMaxSumLine().Item2;

            double expectedMaxSumValue = -13.55;
            double actualExpectedMaxSumValue = maxSumInLine.MaxSum;

            Assert.Equal(expectedLine, actualLine);
            Assert.Equal(expectedMaxSumValue, actualExpectedMaxSumValue);

            File.Delete(testFilePath);
        }



        [Fact]
        public void TestNonNumericElements()
        {
            string testFilePath = "C:\\Users\\Andrey\\source\\repos\\task3\\task3\\test_num_dataset.txt";
            File.WriteAllText(testFilePath, "1.1,2.2,3.3\n4.4,Artem,6.6\n7.7,8.8,9.9");

            MaxSumInLine maxSumInLine = new(testFilePath);
            (string, int) mockModule = maxSumInLine.GetMaxSumLine();

            int expectedCountOfWrongLines = 1;
            int actualCountOfWrongLines = maxSumInLine.GetListOfWrongLineNumbers().Count;

            Assert.Equal(expectedCountOfWrongLines, actualCountOfWrongLines);

            Assert.Equal("4.4,Artem,6.6", maxSumInLine.GetWrongLinesNumValues()[0]);

            File.Delete(testFilePath);
        }

        [Fact]
        public void TestInvalidFilePath()
        {
            string invalidFilePath = "C:\\Users\\Andrey\\source\\repos\\task3\\task3\\num1_dataset.txt";

            Assert.Throws<ArgumentException>(() => new MaxSumInLine(invalidFilePath));
        }
    }
}
