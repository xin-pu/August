using System.Linq;
using Bight.Neural.Core;
using MathNet.Numerics.LinearAlgebra;

namespace Bight.Neural.Neurons
{
    public class PerceptronNeuron : Neuron<Matrix<double>>
    {
        public PerceptronNeuron(Shape shape, Activator activator)
            : base(shape, activator)
        {
        }

        public PerceptronNeuron(Shape shape)
            : base(shape)
        {
        }

        public PerceptronNeuron(ushort height, ushort width)
            : base(height, width)
        {
        }

        public override NeuronOut Activate(Matrix<double> inputMatrix)
        {
            var weight = inputMatrix.PointwiseMultiply(Weight).Enumerate().Sum();
            var activate = Activator.ActivateFunc(weight + OffSet);
            return new NeuronOut(weight, activate);
        }

        public override void UpdateWeihtAndOffset(Matrix<double> weight, double offset)
        {
            Weight += weight;
            OffSet += offset;
        }
    }
}
