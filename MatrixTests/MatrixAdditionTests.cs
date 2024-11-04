using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixTests
{
    [TestClass]
    public class MatrixAdditionTests
    {
        [TestMethod]
        public void TestMatrixAddition()
        {
            // Arrange
            int[,] arrayA = { { 1, 2 }, { 3, 4 } };
            int[,] arrayB = { { 5, 6 }, { 7, 8 } };
            int[,] expectedResult = { { 6, 8 }, { 10, 12 } };

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
            Matrix<int> resultMatrix = MatrixOperations.Add(matrixA, matrixB);

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
        public void TestMatrixAdditionDifferentSizes()
        {
            // Arrange
            Matrix<int> matrixA = new Matrix<int>(2, 2);
            Matrix<int> matrixB = new Matrix<int>(3, 3);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => MatrixOperations.Add(matrixA, matrixB));
        }

        [TestMethod]
        public void TestMatrixAdditionEmptyMatrix()
        {
            // Arrange
            Matrix<int> matrixA = new Matrix<int>(0, 0);
            Matrix<int> matrixB = new Matrix<int>(0, 0);

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Add(matrixA, matrixB);

            // Assert
            Assert.AreEqual(0, resultMatrix.Rows);
            Assert.AreEqual(0, resultMatrix.Columns);
        }

        [TestMethod]
        public void TestMatrixAdditionSingleElement()
        {
            // Arrange
            Matrix<int> matrixA = new Matrix<int>(1, 1);
            Matrix<int> matrixB = new Matrix<int>(1, 1);
            matrixA[0, 0] = 5;
            matrixB[0, 0] = 10;

            // Act
            Matrix<int> resultMatrix = MatrixOperations.Add(matrixA, matrixB);

            // Assert
            Assert.AreEqual(15, resultMatrix[0, 0]);
        }
    }
}
