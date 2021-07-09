using System;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;
using Bight.Mathematics.Activator;
using Bight.Neural.Core;
using MathNet.Numerics.Distributions;
using Activator = Bight.Neural.Core.Activator;

namespace Bight.Neural.Layers
{
    /// <summary>
    /// ust your regular densely-connected NN layer.
    /// 
    /// `Dense` implements the operation:
    /// `output = activation(dot(input, kernel) + bias)`
    /// where `activation` is the element-wise activation function passed as the `activation` argument,
    /// `kernel` is a weights matrix created by the layer,
    /// `bias` is a bias vector created by the layer
    /// (only applicable if `use_bias` is `True`).
    /// </summary>
    public class Dense : Layer
    {
        private int _uints = default;
        private Activator _activator = default;

        public int Uints
        {
            get => _uints;
            set => SetProperty(ref _uints, value);
        }

        public Activator Activator
        {
            get => _activator;
            set => SetProperty(ref _activator, value);
        }


        public DenseMatrix Kenerl { set; get; }

        public DenseVector Bias { set; get; }

        /// <summary>
        /// works for clone
        /// </summary>
        public Dense()
        {

        }

        public Dense(int uints)
            : this(uints, ActivationType.ReLU)
        {

        }

        public Dense(int uints, ActivationType activationType)
        {
            Uints = uints;
            Activator = new Activator(activationType);
        }

        public override DenseMatrix Call(DenseMatrix denseMatrix)
        {
            InputShape = Shape.From(denseMatrix);
            if (InputShape.Width != 1)
                throw new Exception();

            if (Kenerl == null || Bias == null)
            {
                Kenerl = DenseMatrix.CreateRandom(InputShape.Height, Uints, new Normal());
                Bias = DenseVector.CreateRandom(Uints, new Normal());
            }

            var outRes = denseMatrix.TransposeThisAndMultiply(Kenerl);
            var res = outRes;
            outRes = DenseMatrix.Create(outRes.RowCount, outRes.ColumnCount,
                (i, j) => Activator.ActivateFunc(res[i, j])).Transpose();
            return outRes as DenseMatrix;
        }

        public override Dictionary<string, object> GetConfigs()
        {
            return new Dictionary<string, object>();
        }
    }
}
