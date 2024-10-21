﻿namespace MatrixOperation
{
    public class Matrix
    {
        private readonly int[,] array;
        public int[,] Array => array;

        public Matrix(int[,] array)
        {
            this.array = array;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            var N = b.array.GetLength(0);
            int[,] totalSum = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    totalSum[i, j] = a.array[i, j] + b.array[i, j];
                }
            }
            Matrix matrix = new Matrix(totalSum);
            return matrix;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            var N = a.array.GetLength(0);
            int[,] totalProduct = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    totalProduct[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        totalProduct[i, j] += a.array[i, k] * b.array[k, j];
                    }
                }
            }
            Matrix matrix = new Matrix(totalProduct);
            return matrix;
        }

        public int this[int index1, int index2]
        {
            get => array[index1, index2];
            set => array[index1, index2] = value;
        }
    }
}
