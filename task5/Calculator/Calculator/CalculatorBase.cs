using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    public abstract class CalculatorBase<T>
    {
        protected readonly Func<string> _inputProvider;
        protected readonly Action<string> _outputProvider;
        protected string _input;

        protected CalculatorBase(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public abstract T Calculate();

        protected double ProcessExpression()
        {
            _input = _input.Replace(" ", "");

            if (!Regex.IsMatch(_input, @"^[\d(-](?!.*[\+\-\*/](?![\d)])[\+\-\*/])(?<![^\d(][\+\-\*/])[\d+\-*/().]+$"))
            {
                throw new ArgumentException("Invalid character detected.");
            }

            var stack = new Stack<char>();
            foreach (char c in _input)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        throw new ArgumentException("Mismatched parentheses detected.");
                    }

                    stack.Pop();
                }
            }

            if (stack.Count > 0)
            {
                throw new ArgumentException("Mismatched parentheses detected.");
            }

            var tokens = new List<string>();
            string token = "";
            for (int i = 0; i < _input.Length; i++)
            {
                char c = _input[i];
                if (char.IsDigit(c) || c == '.' || (c == '-' && i == 0 && char.IsDigit(_input[i + 1])))
                {
                    token += c;
                }
                else
                {
                    if (token != "")
                    {
                        tokens.Add(token);
                    }

                    tokens.Add(c.ToString());
                    token = "";
                }
            }

            if (token != "")
            {
                tokens.Add(token);
            }

            var operands = new Stack<double>();
            var operators = new Stack<char>();
            foreach (string t in tokens)
            {
                if (double.TryParse(t, out double operand))
                {
                    operands.Push(operand);
                }
                else if (t == "+" || t == "-" || t == "*" || t == "/")
                {
                    while (operators.Count > 0 && HasHigherPriority(operators.Peek().ToString(), t))
                    {
                        ProcessFragment(operators, operands);
                    }

                    operators.Push(char.Parse(t));
                }
                else if (t == "(")
                {
                    operators.Push(char.Parse(t));
                }
                else if (t == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        ProcessFragment(operators, operands);
                    }
                    operators.Pop();
                }
            }
            while (operators.Count > 0)
            {
                ProcessFragment(operators, operands);
            }

            return operands.Pop();
        }

        protected bool HasHigherPriority(string op1, string op2)
        {
            if ((op1 == "*" || op1 == "/") && (op2 == "+" || op2 == "-"))
            {
                return true;
            }

            return false;
        }

        protected void ProcessFragment(Stack<char> operatorStack, Stack<double> operandStack)
        {
            char op = operatorStack.Pop();
            double operand2 = operandStack.Pop();
            double operand1 = operandStack.Pop();
            double result = 0.0;
            switch (op)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
                case '*':
                    result = operand1 * operand2;
                    break;
                case '/':
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException("Attempted to divide by zero.");
                    }

                    result = operand1 / operand2;

                    break;
            }

            operandStack.Push(result);
        }
    }
}
