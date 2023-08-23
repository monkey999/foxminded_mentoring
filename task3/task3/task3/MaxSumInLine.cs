using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace task3
{
    public class MaxSumInLine
    {
        private readonly string _filePath;
        private readonly List<int> _wrongLineNumbers;
        private readonly List<string> _wrongLinesNumValues;
        private int _maxSumLineNumber;
        public double MaxSum { get; private set; }

        public MaxSumInLine(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File not found!", nameof(filePath));
            }

            _filePath = filePath;
            _wrongLineNumbers = new();
            _maxSumLineNumber = -1;
            MaxSum = double.MinValue;
            _wrongLinesNumValues = new();
        }

        public (string, int) GetMaxSumLine()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            NumberFormatInfo formatInfo = culture.NumberFormat;

            List<string> lines;

            try
            {
                lines = File.ReadAllLines(_filePath).ToList();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return ("Error status code:", 400);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                string[] numbers = lines[i].Split(',');
                double sum = 0;

                foreach (string number in numbers)
                {
                    if (double.TryParse(number, NumberStyles.Float, formatInfo, out double parsedNumber))
                    {
                        sum += parsedNumber;
                    }
                    else
                    {
                        _wrongLineNumbers.Add(i + 1);
                        sum = double.MinValue;
                        _wrongLinesNumValues.Add(lines[i]);

                        break;
                    }
                }

                if (sum > MaxSum)
                {
                    _maxSumLineNumber = i + 1;
                    MaxSum = sum;
                }
            }

            if (_wrongLineNumbers.Count == lines.Count)
            {
                return ("MaxSumInLine: AllLinesAreInvalid status code:", 400);
            }

            return ("MaxSumInLine:", _maxSumLineNumber);
        }

        public void DisplayWrongLineNumbers()
        {
            if (_wrongLineNumbers.Count > 0)
            {
                Console.WriteLine("Lines with wrong elements:");

                foreach (int lineNumber in _wrongLineNumbers)
                {
                    Console.WriteLine(lineNumber);
                }
            }
            else
            {
                Console.WriteLine("There are no lines with wrong elements");
            }
        }

        public List<int> GetListOfWrongLineNumbers()
        {
            return _wrongLineNumbers;
        }

        public List<string> GetWrongLinesNumValues()
        {
            return _wrongLinesNumValues;
        }
    }
}
