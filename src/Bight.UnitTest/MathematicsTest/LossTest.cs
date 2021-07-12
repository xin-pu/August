using Bight.Losser.Loss;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.MathematicsTest
{
    public class LossTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LossTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            Y = new double[] {1, 2, 3, 4, 5};
            YEstimate = new[] {1.0, 2.1, 2.9, 4, 5.3};
        }

        private double[] Y { get; }
        private double[] YEstimate { get; }


        [Fact]
        public void TestLostL1()
        {
            var lossL1 = LossFunc.GetL1Loss(Y, YEstimate);
            var lossL2 = LossFunc.GetL2Loss(Y, YEstimate);
            var lossL2Mean = LossFunc.GetL2MeanLoss(Y, YEstimate);
            _testOutputHelper.WriteLine($"LossL1\t{lossL1}\rLossL2\t{lossL2}\rLossL2Mean\t{lossL2Mean}");
        }
    }
}