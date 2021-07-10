using Bight.Neural.Core;
using Bight.Neural.Layers;
using FluentAssertions;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;
using Xunit;
using Xunit.Abstractions;
using YAXLib;

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
            var outMatrix = flatten.Call(DenseMatrix.CreateRandom(3, 3, random));
            _testOutputHelper.WriteLine(flatten.ToString());
            _testOutputHelper.WriteLine(outMatrix.ToString());
            flatten.InputShape.Should().Be(new Shape(3, 3));
            flatten.OutputShape.Should().Be(new Shape(9));
        }



        [Fact]
        public void TransferTest()
        {
            var outMatrix = flatten.Call(DenseMatrix.CreateRandom(3, 3, random));
            outMatrix = flatten.Call(outMatrix);
            outMatrix = dense.Call(outMatrix);
            _testOutputHelper.WriteLine(outMatrix.ToString());
        }

        [Fact]
        public void CloneFlatten()
        {
            var clone = flatten.Clone();
            _testOutputHelper.WriteLine(clone.ToString());
        }

        [Fact]
        public void CloneDense()
        {
            var clone = dense.Clone();
            _testOutputHelper.WriteLine(clone.ToString());
        }

        [Fact]
        public void Clone()
        {
            var a = new DenseVector(new[] {1, 1, 1.0});
            var serializer = new YAXSerializer(typeof(DenseVector));
            var res = serializer.Serialize(a);
            _testOutputHelper.WriteLine(res);
            serializer.Deserialize(res);
        }

        [Theory]
        [InlineData(3, 1.0)]
        public void SerializerDenseVectorStorage(int length, double value)
        {
            var denseVectorStorage = new DenseVectorStorage<double>(length, new[] {value, value * 2, value * 3});
            var serializer = new YAXSerializer(typeof(DenseVectorStorage<double>));
            var str = serializer.Serialize(denseVectorStorage);
            var obj = serializer.Deserialize(str);
            obj.Should().Be(denseVectorStorage);
        }

        [Theory]
        [InlineData(3, 1.0)]
        public void SerializerDenseVector(int length, double value)
        {
            var denseVectorStorage = new DenseVectorStorage<double>(length, new[] {value, value * 2, value * 3});
            var denseVector = new DenseVector(denseVectorStorage);
            var serializer = new YAXSerializer(denseVector.GetType());
            var str = serializer.Serialize(denseVector);
            var obj = serializer.Deserialize(str);
            obj.Should().Be(denseVector);
        }


        [Fact]
        public void SerializerVectorDouble()
        {
            var denseVector = CreateVector.Dense<double>(3);
            var serializer = new YAXSerializer(denseVector.GetType());
            var str = serializer.Serialize(denseVector);
            var obj = serializer.Deserialize(str);
            obj.Should().Be(denseVector);
        }

    }


}
