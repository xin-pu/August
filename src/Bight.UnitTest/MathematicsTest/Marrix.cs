using System;
using MathNet.Numerics.LinearAlgebra.Double;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.MathematicsTest
{

    public class Marrix
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Marrix(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Setup()
        {
        }

        [Fact]
        public void TestPrintMatrix()
        {
            var mat = DenseMatrix.Build.DenseDiagonal(3, 3, 1);
            _testOutputHelper.WriteLine(mat.ToString());
        }
    }
}