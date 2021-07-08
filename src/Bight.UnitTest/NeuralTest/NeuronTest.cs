using Bight.Neural.Core;
using Bight.Neural.Neurons;
using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Bight.UnitTest.NeuralTest
{
    public class NeuralTest
    {
        public Neuron Neuron { set; get; }

        [SetUp]
        public void Setup()
        {
            Neuron = new PerceptronNeuron(new Shape(3, 4));
        }

        [Test]
        public void TestPrintNeuron()
        {
            Console.WriteLine(Neuron);
        }

        [Test]
        public void TestClone()
        {
            var clone = Neuron.Clone();
            Assert.AreNotEqual(Neuron, clone);
            Console.WriteLine(clone);
        }

        [Test]
        public void TestMul()
        {
            var neu1 = new PerceptronNeuron(3, 3);
            var neu2 = new PerceptronNeuron(3, 3);


            neu1.Weight = DenseMatrix.Create(3, 3, 1);
            neu2.Weight = DenseMatrix.CreateDiagonal(3, 3, 2);

            var clone1 = neu1.Clone() as PerceptronNeuron;
            var clone2 = neu2.Clone() as PerceptronNeuron;

            neu1.Weight = Matrix.op_DotMultiply(neu1.Weight, neu2.Weight) as DenseMatrix;
            Console.WriteLine(neu1);


            clone1.Weight= Matrix.op_DotMultiply(clone1.Weight, clone2.Weight) as DenseMatrix;
            Console.WriteLine(clone1);
        }
    }
}