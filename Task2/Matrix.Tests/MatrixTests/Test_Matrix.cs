using System;
using Xunit;

namespace Matrix.Tests.MatrixTests
{
    public class Test_Matrix
    {
        [Fact]
        public void IsExpectedResult_5x5()
        {
            int[,] matrixArray = {  { 23, 34, 54, 62, 43 },
                                    { 87, 87, 54, 65, 34 },
                                    { 76, 83, 42, 54, 65 },
                                    { 54, 43, 32, 76, 34 },
                                    { 54, 43, 23, 23, 43 } };

            Task2.Matrix matrix = new(matrixArray);

            int expectedResult = 271;

            var testResult = matrix.GetMatrixTrace();

            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void IsExpectedResult_10x5()
        {
            int[,] matrixArray = {  { 23, 34, 54, 62, 43 },
                                    { 87, 87, 54, 65, 34 },
                                    { 76, 83, 42, 54, 65 },
                                    { 54, 43, 32, 76, 34 },
                                    { 54, 43, 23, 23, 43 },
                                    { 23, 34, 54, 62, 43 },
                                    { 87, 87, 54, 65, 34 },
                                    { 76, 83, 42, 54, 65 },
                                    { 54, 43, 32, 76, 34 },
                                    { 54, 43, 23, 23, 43 } };

            Task2.Matrix matrix = new(matrixArray);
            int expectedResult = 271;

            var testResult = matrix.GetMatrixTrace();

            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void IsExpectedResult_5X10()
        {
            int[,] matrixArray = {  { 23, 34, 54, 62, 43, 23, 34, 54, 62, 43 },
                                    { 87, 87, 54, 65, 34, 87, 87, 54, 65, 34 },
                                    { 76, 83, 42, 54, 65, 76, 83, 42, 54, 65 },
                                    { 54, 43, 32, 76, 34, 54, 43, 32, 76, 34 },
                                    { 54, 43, 23, 23, 43, 54, 43, 23, 23, 43 } };

            Task2.Matrix matrix = new(matrixArray);
            int expectedResult = 271;

            var testResult = matrix.GetMatrixTrace();

            Assert.Equal(expectedResult, testResult);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(10, 5)]
        [InlineData(5, 5)]
        public void IsInvalidDimensionsCapacityAsItWasInputtedInitially_ThrowsFalseIfFails(int nRows, int nColumns)
        {
            Task2.Matrix matrix = new(nRows, nColumns);
            bool result = true;

            if (matrix.Rows != nRows || matrix.Columns != nColumns)
            {
                result = false;
            }

            Assert.True(result);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(10, 5)]
        [InlineData(5, 5)]
        public void IsValidVariablesValuesRange_TrueIfYes(int nRows, int nColumns)
        {
            Task2.Matrix matrix = new(nRows, nColumns);
            bool result = true;

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    if (matrix._matrixArray[i, j] > 100 || matrix._matrixArray[i, j] < 0)
                    {
                        result = false;
                    }
                }
            }

            Assert.True(result);
        }

        [Theory]
        [InlineData(-1, 5)]
        [InlineData(5, -1)]
        [InlineData(0, -3)]
        [InlineData(-15, -10)]
        public void IsInvalid_IsNegativeOrZeroDimensions_ThrowsExcpetionIfYes(int nRows, int nColumns)
        {
            Assert.Throws<ArgumentException>(() => new Task2.Matrix(nRows, nColumns));
        }
    }
}
