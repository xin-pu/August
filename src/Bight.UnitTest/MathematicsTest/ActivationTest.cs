using Bight.Mathematics.Activator;
using FluentAssertions;
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
            res0.Should().BeInRange(0.4, 0.6);
            res1.Should().BeInRange(-0.1, 0.1);
            res2.Should().BeInRange(-0.1, 0.1);
        }
    }
}