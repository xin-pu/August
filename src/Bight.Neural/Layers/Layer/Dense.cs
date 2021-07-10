using Bight.Mathematics.Activator;
using Bight.Neural.Core;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
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


        public Matrix<double> Kenerl { set; get; }

        public Vector<double> Bias { set; get; }

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

        public override Matrix<double> Call(Matrix<double> denseMatrix)
        {
            InputShape = Shape.From(denseMatrix);
            if (InputShape.Width != 1)
                throw new Exception();

            if (Kenerl == null)
            {
                Kenerl = CreateMatrix.Random<double>(InputShape.Height, Uints, new Normal());
                //Bias = CreateVector.Random<double>(Uints, new Normal());
            }

            var outRes = denseMatrix.TransposeThisAndMultiply(Kenerl);
            var res = outRes;
            return CreateMatrix.Dense(outRes.RowCount, outRes.ColumnCount,
                (i, j) => Activator.ActivateFunc(res[i, j])).Transpose();
        }

        public override Dictionary<string, object> GetConfigs()
        {
            return new Dictionary<string, object>();
        }
    }
}
