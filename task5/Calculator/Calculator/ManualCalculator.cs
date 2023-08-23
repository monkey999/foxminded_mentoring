using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class ManualCalculator : CalculatorBase<double>
    {
        public ManualCalculator(Func<string> inputProvider, Action<string> outputProvider)
            : base(inputProvider, outputProvider)
        {
        }

        public override double Calculate()
        {
            _outputProvider("Enter expression: ");
            _input = _inputProvider();

            return ProcessExpression();
        }
    }
}
