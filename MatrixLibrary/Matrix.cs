using System;
using System.IO;

namespace MatrixLibrary
{
    public class Matrix<T> where T : struct
    {
        private T[,] _data;
        public int Rows { get; }
        public int Columns { get; }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _data = new T[rows, columns];
        }
        // Индексатор для доступа к элементам матрицы
        public T this[int row, int column]
        {
            get => _data[row, column];
            set => _data[row, column] = value;
        }

        public T[,] Array => _data;

        public void SaveToCsv(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        writer.Write(_data[i, j]);
                        if (j < Columns - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }
        }

        public static Matrix<T> GenerateMatrix(int rows, int columns, Func<int, int, T> generator)
        {
            Matrix<T> matrix = new Matrix<T>(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = generator(i, j);
                }
            }
            return matrix;
        }
    }
}