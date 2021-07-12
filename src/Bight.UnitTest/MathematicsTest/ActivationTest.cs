using Bight.Neural.Activator;
using Xunit;
using Xunit.Abstractions;

namespace Bight.UnitTest.MathematicsTest
{
    public class ActivatorTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ActivatorTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestSigmod()
        {
            var res0 = ActivationFunc.Logistic(0);
            var res1 = ActivationFunc.Tanh(0);
            var res2 = ActivationFunc.HardLogistic(0);
            var res3 = ActivationFunc.HardTanh(0);
            _testOutputHelper.WriteLine(res0.ToString());
            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
            _testOutputHelper.WriteLine(res3.ToString());
        }

        [Fact]
        public void TestRelu()
        {
            var res1 = ActivationFunc.ReLU(0);
            var res2 = ActivationFunc.LeakyReLu(0, 1);
            var res3 = ActivationFunc.PReLu(0, 1);

            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
            _testOutputHelper.WriteLine(res3.ToString());
        }

        [Fact]
        public void TestELU()
        {
            var res1 = ActivationFunc.GELU(0);
            var res2 = ActivationFunc.ELU(0, 0);
            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
        }


        [Fact]
        public void TestActivatorMore()
        {
            var res1 = ActivationFunc.Swish(0, 0);
            var res2 = ActivationFunc.Softplus(0);
            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
        }
    }
}