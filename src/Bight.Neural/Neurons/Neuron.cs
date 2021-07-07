using Bight.Neural.Core;
using Bight.Neural.Layers;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MvvmCross.ViewModels;

namespace Bight.Neural.Neurons
{
    public abstract class Neuron : MvxViewModel>
    {


        private uint _id;
        private string _name;
        private Layer _parentLayer;
        private Shape _shape;
        private Matrix<double> _weight;
        private double _offset;
        private Activator _activator;


        protected Neuron(Shape shape, Activator activator)
        {
            Shape = shape;
            Activator = activator;
            var a = DenseMatrix.CreateRandom(shape.Height, shape.Height, new Normal());
        }

        /// <summary>
        /// Generate Neuron with RELU function as Activation Function
        /// </summary>
        /// <param name="shape"></param>
        protected Neuron(Shape shape)
            : this(shape, new Activator())
        {

        }

        /// <summary>
        /// Generate Neuron with RELU function as Activation Function
        /// </summary>
        /// <param name="shape"></param>
        protected Neuron(ushort height, ushort width)
            : this(new Shape(height, width))
        {

        }


        public uint ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public Layer ParentLayer
        {
            get => _parentLayer;
            set => SetProperty(ref _parentLayer, value);
        }

        public Shape Shape
        {
            get => _shape;
            set => SetProperty(ref _shape, value);
        }

        public Matrix<double> Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        public double OffSet
        {
            get => _offset;
            set => SetProperty(ref _offset, value);
        }

        public Activator Activator
        {
            get => _activator;
            set => SetProperty(ref _activator, value);
        }


        public abstract NeuronOut Activate(Matrix<double> inputMatrix);

        public abstract void UpdateWeihtAndOffset(Matrix<double> weight, double offset);


    }
}
