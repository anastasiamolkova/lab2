using System;

namespace MatrixLibrary
{
    public static class MatrixOperations
    {
        // Перегрузка оператора сложения для матриц
        public static Matrix<T> Add<T>(Matrix<T> a, Matrix<T> b) where T : struct
        // остальное было избыточным поскольку нам не нужно было сравнивать элементы матрицы, их менять, преобразовывать матрицы 
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Матрицы должны иметь одинаковые размеры для сложения.");

            Matrix<T> result = new Matrix<T>(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = (dynamic)a[i, j] + b[i, j];
                }
            }
            return result;
        }
        // Перегрузка оператора умножения для матриц
        public static Matrix<T> Multiply<T>(Matrix<T> a, Matrix<T> b) where T : struct//struct гарантирует что это тип значения, помогает сохранять больше памяти
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");

            Matrix<T> result = new Matrix<T>(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    T sum = default(T);
                    for (int k = 0; k < a.Columns; k++)
                    {
                        // динамическое разрешение во времы выполнения, а не во время компиляции, нужен для того чтоб заранее определить какая операция будет выполняться
                        sum = (dynamic)sum + ((dynamic)a[i, k] * b[k, j]);
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
    }
}