using System;
using System.IO;

namespace Calculator
{
    public class FileCalculator : CalculatorBase<bool>
    {
        private readonly string _inputPath;
        private readonly string _outputPath;

        public FileCalculator(Func<string> inputProvider, Action<string> outputProvider, string inputPath, string outputPath) : base(inputProvider, outputProvider)
        {
            if (string.IsNullOrEmpty(inputPath)
                            || string.IsNullOrEmpty(outputPath))
            {
                throw new ArgumentException("DefaultInputPath and DefaultOutputPath filepath values must be specified in appSettings.json!");
            }

            _inputPath = inputPath;
            _outputPath = outputPath;
        }

        public override bool Calculate()
        {
            try
            {
                string[] lines = File.ReadAllLines(_inputPath);

                using StreamWriter writer = new(_outputPath);
                foreach (string line in lines)
                {
                    try
                    {
                        _input = line;
                        double result = ProcessExpression();
                        writer.WriteLine($"{line} = {result}");
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"{line} = Exception. Wrong input.");
                    }
                }
            }
            catch (Exception ex)
            {
                _outputProvider($"An error occurred: {ex.Message}");
            }

            return true;
        }
    }
}

