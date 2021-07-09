using System;
using MathNet.Numerics.LinearAlgebra.Double;
using NUnit.Framework;

namespace Bight.UnitTest.MathematicsTest
{
    [TestFixture]
    public class Marrix
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPrintMatrix()
        {
            var mat = DenseMatrix.Build.DenseDiagonal(3, 3, 1);
            Console.WriteLine(mat);
        }
    }
}