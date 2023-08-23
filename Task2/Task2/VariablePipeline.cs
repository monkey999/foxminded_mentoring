using System;

namespace Task2
{
    public class VariablePipeline
    {
        public static (int, int) GetValues()
        {
            var result = (-1, -1);

            result.Item1 = InputPositiveNumber("rows");
            result.Item2 = InputPositiveNumber("columns");

            return result;
        }

        private static int InputPositiveNumber(string greeting)
        {
            bool success = false;
            int result = -1;

            Console.WriteLine($"Input positive number of {greeting}:");

            while (success == false)
            {
                try
                {
                    result = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid type! Try again:");
                }

                if (result > 0)
                {
                    success = true;
                }
            }

            return result;
        }
    }
}
