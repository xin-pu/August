using Bight.Mathematics.Activator;
using NUnit.Framework;

namespace Bight.UnitTest.MathematicsTest
{
    public class ActivatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestActivator()
        {
            var res0 = Activation.Logistic(0);
            var res1 = Activation.ReLU(0);
            var res2 = Activation.Tanh(0);
            Assert.AreEqual(0.5, res0, 1E-4);
            Assert.AreEqual(0, res1, 1E-4);
            Assert.AreEqual(0, res2, 1E-4);
        }
    }
}