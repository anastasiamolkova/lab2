using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixOperation; 

namespace Sloshenie
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrixAddition()
        {
            // Arrange
            int[,] arrayA = { { 1, 2 }, { 3, 4 } };
            int[,] arrayB = { { 5, 6 }, { 7, 8 } };
            int[,] expectedResult = { { 6, 8 }, { 10, 12 } };

            Matrix matrixA = new Matrix(arrayA);
            Matrix matrixB = new Matrix(arrayB);

            // Act
            Matrix resultMatrix = matrixA + matrixB;

            // Assert
            CollectionAssert.AreEqual(expectedResult, resultMatrix.Array);
        }
    }
}