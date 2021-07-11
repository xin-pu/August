using System.Linq;
using Bight.Neural.Layers;
using MathNet.Numerics.LinearAlgebra;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.FNNTest
{
    public class FnnLinearTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly int Iterations = 100;
        private readonly double[] price = {3000, 5000, 7002, 9010, 10990};
        private readonly double[] years = {2000, 2001, 2002, 2003, 2004};
        private double LearningRate = 1E-3;

        public FnnLinearTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        [Fact]
        public void TestCreateFNN()
        {
            var x = getMatrix(price);
            var y = getMatrix(years);

            var flatten = new Flatten();
            var dense = new Dense(10);

            foreach (var i in Enumerable.Range(1, Iterations))
            {
                var x_temp = flatten.Call(x);
                x_temp = dense.Call(x_temp);
                _testOutputHelper.WriteLine($"Ite:{i:D}\r{x_temp}");
            }
        }

        private Matrix<double> getMatrix(double[] array)
        {
            return CreateMatrix.Dense(array.Length, 1, array);
        }
    }
}