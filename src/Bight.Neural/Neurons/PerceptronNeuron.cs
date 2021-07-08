using System.Linq;
using Bight.Neural.Core;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Bight.Neural.Neurons
{
    public class PerceptronNeuron : Neuron
    {
        public PerceptronNeuron()
        {
        }

        public PerceptronNeuron(Shape shape) : base(shape)
        {
        }

        public PerceptronNeuron(ushort height, ushort width) : base(height, width)
        {
        }

        public PerceptronNeuron(Shape shape, Activator activator) : base(shape, activator)
        {
        }

        public PerceptronNeuron(Shape shape, Activator activator, IContinuousDistribution distribution) : base(shape,
            activator, distribution)
        {
        }

        public override NeuronOut Activate(DenseMatrix inputMatrix)
        {
            var weight = inputMatrix.PointwiseMultiply(Weight).Enumerate().Sum();
            var activate = Activator.ActivateFunc(weight + OffSet);
            return new NeuronOut(weight, activate);
        }

        public override void UpdateWeihtAndOffset(DenseMatrix weight, double offset)
        {
            Weight =(Weight + weight);
            OffSet += offset;
        }
    }
}
