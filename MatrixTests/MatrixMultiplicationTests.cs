using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixTests
{
    [TestClass]
    public class MatrixMultiplicationTests
    {
        [TestMethod]
        public void TestMatrixMultiplication()
        {
            // Arrange
            int[,] arrayA = { { 1, 2 }, { 3, 4 } };
            int[,] arrayB = { { 5, 6 }, { 7, 8 } };
            int[,] expectedResult = { { 19, 22 }, { 43, 50 } };

            Matrix<int> matrixA = new Matrix<int>(2, 2);
            Matrix<int> matrixB = new Matrix<int>(2, 2);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrixA[i, j] = arrayA[i, j];
                    matrixB[i, j] = arrayB[i, j];
                }
            }

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Multiply(matrixA, matrixB);

            // Assert
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], resultMatrix[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestMatrixMultiplicationDifferentSizes()
        {
            // Arrange
            Matrix<int> matrixA = new Matrix<int>(2, 3);
            Matrix<int> matrixB = new Matrix<int>(2, 2);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => MatrixOperations.Multiply(matrixA, matrixB));
        }

        [TestMethod]
        public void TestMatrixMultiplicationEmptyMatrix()
        {
            // Arrange
            Matrix<int> matrixA = new Matrix<int>(0, 0);
            Matrix<int> matrixB = new Matrix<int>(0, 0);

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Multiply(matrixA, matrixB);

            // Assert
            Assert.AreEqual(0, resultMatrix.Rows);
            Assert.AreEqual(0, resultMatrix.Columns);
        }


        [TestMethod]
        public void TestMatrixMultiplicationNonSquareMatrices()
        {
            // Arrange
            int[,] arrayA = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arrayB = { { 7, 8 }, { 9, 10 }, { 11, 12 } };
            int[,] expectedResult = { { 58, 64 }, { 139, 154 } };

            Matrix<int> matrixA = new Matrix<int>(2, 3);
            Matrix<int> matrixB = new Matrix<int>(3, 2);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixA[i, j] = arrayA[i, j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrixB[i, j] = arrayB[i, j];
                }
            }

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Multiply(matrixA, matrixB);

            // Assert
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], resultMatrix[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestMatrixMultiplicationIdentityMatrix()
        {
            // Arrange
            int[,] arrayA = { { 1, 2 }, { 3, 4 } };
            int[,] arrayB = { { 1, 0 }, { 0, 1 } };
            int[,] expectedResult = { { 1, 2 }, { 3, 4 } };

            Matrix<int> matrixA = new Matrix<int>(2, 2);
            Matrix<int> matrixB = new Matrix<int>(2, 2);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrixA[i, j] = arrayA[i, j];
                    matrixB[i, j] = arrayB[i, j];
                }
            }

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Multiply(matrixA, matrixB);

            // Assert
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], resultMatrix[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestMatrixMultiplicationZeroMatrix()
        {
            // Arrange
            int[,] arrayA = { { 1, 2 }, { 3, 4 } };
            int[,] arrayB = { { 0, 0 }, { 0, 0 } };
            int[,] expectedResult = { { 0, 0 }, { 0, 0 } };

            Matrix<int> matrixA = new Matrix<int>(2, 2);
            Matrix<int> matrixB = new Matrix<int>(2, 2);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrixA[i, j] = arrayA[i, j];
                    matrixB[i, j] = arrayB[i, j];
                }
            }

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Multiply(matrixA, matrixB);

            // Assert
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], resultMatrix[i, j]);
                }
            }
        }
    }
}
