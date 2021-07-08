using Bight.Neural.Core;
using Bight.Neural.Neurons;
using NUnit.Framework;
using System;

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
    }
}