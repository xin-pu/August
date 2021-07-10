using System;
using MathNet.Numerics.LinearAlgebra;
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
            var m1 = CreateMatrix.Diagonal<double>(3, 3, 1);
            var m2 = CreateVector.Dense(3, 0.1);

        }

        [Fact]
        public void TestPrintMatrix()
        {
            var mat = CreateMatrix.Diagonal<double>(3, 3, 1);
            _testOutputHelper.WriteLine(mat.ToString());
        }
    }
}