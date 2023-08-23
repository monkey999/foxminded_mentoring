using System;
using System.Collections.Generic;

namespace Task2
{
    public class Matrix
    {
        public int MatrixTrace { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public readonly int[,] _matrixArray;

        private static readonly Random _rnd = new();

        public Matrix(int nRows, int nColumns)
        {
            if (nRows <= 0 || nColumns <= 0)
            {
                throw new ArgumentException("You can't have x<=0 dimension!");
            }

            Rows = nRows;
            Columns = nColumns;

            _matrixArray = new int[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _matrixArray[i, j] = _rnd.Next(0, 101);
                }
            }
        }

        public Matrix(int[,] matrixArray)
        {
            _matrixArray = matrixArray;
            Rows = matrixArray.GetLength(0);
            Columns = matrixArray.GetLength(1);
        }

        public void DisplayMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(_matrixArray[i, j] + "\t");
                        Console.ResetColor();

                        continue;
                    }

                    Console.Write(_matrixArray[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        public int GetMatrixTrace()
        {
            for (int i = 0; i < (Rows < Columns ? Rows : Columns); i++)
            {
                MatrixTrace += _matrixArray[i, i];
            }

            return MatrixTrace;
        }

        public void DisplaySnailShellMatrix()
        {
            List<int> snailShellyMatrix = new();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    snailShellyMatrix.Add(_matrixArray[i, j]);
                }
            }

            foreach (var element in snailShellyMatrix)
            {
                Console.Write(element.ToString().PadRight(element.ToString().Length + 1));
            }
        }
    }
}
