using Bight.Mathematics.Activator;
using Bight.Neural.Core;
using Bight.Neural.Neurons;
using NUnit.Framework;

namespace Bight.UnitTest.NeuralTest
{
    public class NeuralTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestActivator()
        {
            var n = new PerceptronNeuron(new Shape(3, 4));
        }
    }
}