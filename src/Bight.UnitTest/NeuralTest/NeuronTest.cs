using Bight.Neural.Core;
using Bight.Neural.Neurons;
using FluentAssertions;
using MathNet.Numerics.LinearAlgebra.Double;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.NeuralTest
{
    public class NeuralTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public NeuralTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public Neuron Neuron { set; get; } = new PerceptronNeuron(new Shape(3, 4));



        [Fact]
        public void TestPrintNeuron()
        {
            _testOutputHelper.WriteLine(Neuron.ToString());
        }

        [Fact]
        public void TestClone()
        {
            var clone = Neuron.Clone();
            clone.Should().NotBe(Neuron, "It is clone");
        }

        [Fact]
        public void TestMul()
        {
            var neu1 = new PerceptronNeuron(3, 3);
            var neu2 = new PerceptronNeuron(3, 3);


            neu1.Weight = DenseMatrix.Create(3, 3, 1);
            neu2.Weight = DenseMatrix.CreateDiagonal(3, 3, 2);

            var clone1 = neu1.Clone() as PerceptronNeuron;
            var clone2 = neu2.Clone() as PerceptronNeuron;

            neu1.Weight = Matrix.op_DotMultiply(neu1.Weight, neu2.Weight) as DenseMatrix;
            _testOutputHelper.WriteLine(neu1.ToString());


            clone1.Weight = Matrix.op_DotMultiply(clone1.Weight, clone2.Weight) as DenseMatrix;
            _testOutputHelper.WriteLine(clone1.ToString());
        }
    }
}