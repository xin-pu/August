using Bight.Mathematics.Activator;
using Bight.Neural.Core;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.Neural
{
    public class CoreTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Activator activator = new Activator(ActivationType.Logistic);

        public CoreTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(ActivationType.Logistic)]
        [InlineData(ActivationType.ReLU)]
        public void CreateActivator(ActivationType activationType)
        {
            activator = new Activator(activationType, 0.2);
            _testOutputHelper.WriteLine(activator.ToString());
        }

        [Theory]
        [InlineData(3F)]
        [InlineData(1E-5)]
        public void TestActivate(double input)
        {
            var act = activator.ActivateFunc(input);
            _testOutputHelper.WriteLine($"activate {input} --->{act}");
        }

        [Theory]
        [InlineData(3F)]
        [InlineData(1E-5)]
        public void TestFirstDerivative(double input)
        {
            var act = activator.FirstDerivativeFunc(input);
            _testOutputHelper.WriteLine($"first derivative {input} --->{act}");
        }
    }
}