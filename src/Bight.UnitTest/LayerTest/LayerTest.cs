using Bight.Neural.Layers;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.LayerTest
{
    public class LayerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Flatten flatten = new Flatten();
        private readonly Dense dense = new Dense(10);
        private readonly Normal random = new Normal();

        public LayerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        [Fact]
        public void PrintLayerTest()
        {
            _testOutputHelper.WriteLine(flatten.ToString());
            _testOutputHelper.WriteLine(dense.ToString());
        }


        [Fact]
        public void TransferTest()
        {
            var outMatrix = flatten.Call(CreateMatrix.Random<double>(3, 3, random));
            outMatrix = flatten.Call(outMatrix);
            outMatrix = dense.Call(outMatrix);
            _testOutputHelper.WriteLine(outMatrix.ToString());
        }

    }


}
