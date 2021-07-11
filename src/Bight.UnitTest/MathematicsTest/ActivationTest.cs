using Bight.Mathematics.Activator;
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
            var res0 = Activation.Logistic(0);
            var res1 = Activation.Tanh(0);
            var res2 = Activation.HardLogistic(0);
            var res3 = Activation.HardTanh(0);
            _testOutputHelper.WriteLine(res0.ToString());
            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
            _testOutputHelper.WriteLine(res3.ToString());
        }

        [Fact]
        public void TestRelu()
        {
            var res1 = Activation.ReLU(0);
            var res2 = Activation.LeakyReLu(0, 1);
            var res3 = Activation.PReLu(0, 1);

            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
            _testOutputHelper.WriteLine(res3.ToString());
        }

        [Fact]
        public void TestELU()
        {
            var res1 = Activation.GELU(0);
            var res2 = Activation.ELU(0, 0);
            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
        }


        [Fact]
        public void TestActivatorMore()
        {
            var res1 = Activation.Swish(0, 0);
            var res2 = Activation.Softplus(0);
            _testOutputHelper.WriteLine(res1.ToString());
            _testOutputHelper.WriteLine(res2.ToString());
        }
    }
}