using System.IO;
using Bight.Neural.Core;
using Bight.Neural.Layers;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;
using MvvmCross.ViewModels;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YAXLib;


namespace Bight.Neural.Neurons
{
    public abstract class Neuron : MvxViewModel
    {


        private uint _id;
        private string _name;
        private Layer _parentLayer;
        private Shape _shape;
        private DenseMatrix _weight;
        private double _offset;
        private Activator _activator;
        private IContinuousDistribution _distribution;

        protected Neuron()
        {

        }


        /// <summary>
        /// Generate Neuron with RELU function as Activation Function
        /// </summary>
        /// <param name="shape"></param>
        protected Neuron(Shape shape)
            : this(shape, new Activator(), new Normal())
        {

        }

        /// <summary>
        /// Generate Neuron with RELU function as Activation Function
        /// </summary>
        /// <param name="shape"></param>
        protected Neuron(ushort height, ushort width)
            : this(new Shape(height, width), new Activator(), new Normal())
        {

        }

        protected Neuron(Shape shape, Activator activator)
            : this(shape, activator, new Normal())
        {

        }

        protected Neuron(Shape shape, Activator activator,
            IContinuousDistribution distribution)
        {
            Shape = shape;
            Activator = activator;
            Distribution = distribution;
            InitialWeightAndOffset();
        }


        public uint Id
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

        public DenseMatrix Weight
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

        public IContinuousDistribution Distribution
        {
            get => _distribution;
            set => SetProperty(ref _distribution, value);
        }

        private void InitialWeightAndOffset()
        {
            Weight = DenseMatrix.CreateRandom(Shape.Height, Shape.Height, Distribution);
            OffSet = Distribution.Sample();
        }


        public abstract NeuronOut Activate(DenseMatrix inputMatrix);
        public abstract void UpdateWeihtAndOffset(DenseMatrix weight, double offset);



        public object Clone()
        {
            var serializer = new YAXSerializer(GetType());
            var res = serializer.Serialize(this);
            return serializer.Deserialize(res);
        }

        public override string ToString()
        {

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(this);
            return yaml;
        }


    }

}
