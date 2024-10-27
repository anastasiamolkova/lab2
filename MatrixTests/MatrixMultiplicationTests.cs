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
    }
}
