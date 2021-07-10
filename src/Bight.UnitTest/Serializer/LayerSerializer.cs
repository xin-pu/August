using Bight.Neural.Layers;
using FluentAssertions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;
using Xunit;
using Xunit.Abstractions;
using YAXLib;

namespace Bight.UnitTest.Serializer
{
    public class LayerSerializer
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Flatten flatten = new Flatten();
        private readonly Dense dense = new Dense(10);

        public LayerSerializer(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
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


        [Theory]
        [InlineData(3, 1.0)]
        public void SerializerVectorDouble(int length, double value)
        {
            var denseVector = CreateVector.Dense(length, value);
            var serializer = new YAXSerializer(denseVector.GetType());
            var str = serializer.Serialize(denseVector);
            var obj = serializer.Deserialize(str);
            obj.Should().Be(denseVector);
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



    }


}
