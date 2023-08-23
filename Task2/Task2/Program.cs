using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixVariables = VariablePipeline.GetValues();

            Matrix matrix = new(matrixVariables.Item1, matrixVariables.Item2);

            matrix.DisplayMatrix();

            int matrixTrace = matrix.GetMatrixTrace();

            Console.WriteLine($"Matrix trace: {matrixTrace}");

            Console.WriteLine("Matrix displayed in snail-shell manner:");
            matrix.DisplaySnailShellMatrix();
        }
    }
}
