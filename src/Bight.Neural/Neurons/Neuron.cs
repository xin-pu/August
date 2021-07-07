using Bight.Neural.Core;
using Bight.Neural.Layers;
using MathNet.Numerics.LinearAlgebra;
using MvvmCross.ViewModels;

namespace Bight.Neural.Neurons
{
    public abstract class Neuron<U> : MvxViewModel
        where U : Matrix<double>
    {
        private uint _id;
        private string _name;
        private Layer _parentLayer;
        private Shape _shape;
        public U _weight;
        private double _offset;
        private Activation _activation;

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

        public U Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        public double OffSet
        {
            get => _offset;
            set => SetProperty(ref _offset, value);
        }

        public Activation Activation
        {
            get => _activation;
            set => SetProperty(ref _activation, value);
        }

        public Neuron(Shape shape, Activation activation)
        {
            Shape = shape;
            Activation = activation;
        }

        /// <summary>
        /// Generate Neuron with RELU function as Activation Function
        /// </summary>
        /// <param name="shape"></param>
        public Neuron(Shape shape)
            :this(shape,new Activation())
        {

        }

        /// <summary>
        /// Generate Neuron with RELU function as Activation Function
        /// </summary>
        /// <param name="shape"></param>
        public Neuron(ushort height, ushort width)
            : this(new Shape(height, width))
        {

        }



    }
}
