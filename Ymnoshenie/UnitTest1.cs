using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixOperation;
namespace Ymnoshenie
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrixMultiplication()
        {
            // Arrange
            int[,] arrayA = { { 1, 2 }, { 3, 4 } };
            int[,] arrayB = { { 5, 6 }, { 7, 8 } };
            int[,] expectedResult = { { 19, 22 }, { 43, 50 } };

            Matrix matrixA = new Matrix(arrayA);
            Matrix matrixB = new Matrix(arrayB);

            // Act
            Matrix resultMatrix = matrixA * matrixB;

            // Assert
            CollectionAssert.AreEqual(expectedResult, resultMatrix.Array);
        }
    }
}