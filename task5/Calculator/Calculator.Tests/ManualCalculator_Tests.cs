using System;
using Xunit;

namespace Calculator.Tests
{
    public class ManualCalculator_Tests
    {
        [Theory]
        [InlineData("2+2", 4)]
        [InlineData("10-5", 5)]
        [InlineData("3*4", 12)]
        [InlineData("12/4", 3)]
        [InlineData("1+2*3", 7)]
        [InlineData("(1+2)*3", 9)]
        [InlineData("1+(2*3)", 7)]
        [InlineData("2+15/3+4*2", 15)]
        [InlineData("1+2*(3+2)", 11)]
        [InlineData("(3+2)*2", 10)]
        [InlineData("3*(2+5*(3-1))-6/3", 34)]
        [InlineData("-5*2", -10)]
        public void Evaluate_ShouldReturnCorrectResult(string expression, double expected)
        {
            CalculatorBase<double> manualCalculator = new ManualCalculator(() => $"{expression}", _ => { });
            double manualResult = manualCalculator.Calculate();

            Assert.Equal(expected, manualResult);
        }

        [Theory]
        [InlineData("1/0")]
        public void Evaluate_ShouldThrowException_WhenDividingByZero(string expression)
        {
            CalculatorBase<double> manualCalculator = new ManualCalculator(() => $"{expression}", _ => { });

            Assert.Throws<DivideByZeroException>(() => manualCalculator.Calculate());
        }

        [Theory]
        [InlineData("1+*2-3")]
        public void TestCalculateExpressionWithInvalidInput(string expression)
        {
            CalculatorBase<double> manualCalculator = new ManualCalculator(() => $"{expression}", _ => { });

            Assert.Throws<ArgumentException>(() => manualCalculator.Calculate());
        }

        [Theory]
        [InlineData("3*(2+5*(3-1)-6/3")]
        [InlineData("1+2*(3+2")]
        public void TestCalculateExpressionWithInvalidNestedParentheses(string expression)
        {
            CalculatorBase<double> manualCalculator = new ManualCalculator(() => $"{expression}", _ => { });

            Assert.Throws<ArgumentException>(() => manualCalculator.Calculate());
        }
    }
}
