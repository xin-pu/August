using System;
using System.Collections.Generic;
using Bight.Neural.Activator;
using Bight.Neural.Core;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;

namespace Bight.Neural.Layers
{
    /// <summary>
    ///     ust your regular densely-connected NN layer.
    ///     `Dense` implements the operation:
    ///     `output = activation(dot(input, kernel) + bias)`
    ///     where `activation` is the element-wise activation function passed as the `activation` argument,
    ///     Kenerl is a weights matrix created by the layer,
    ///     Bias is a bias vector created by the layer
    ///     (only applicable if `use_bias` is `True`).
    /// </summary>
    public class Dense : Layer
    {
        private Activation _activator = default;
        private Matrix<double> _bias = default;
        private Matrix<double> _kenerl = default;
        private int _uints = default;


        /// <summary>
        ///     works for clone
        /// </summary>
        public Dense()
        {
        }

        public Dense(int uints, ActivationType activationType = ActivationType.ReLU)
        {
            Uints = uints;
            Activator = new Activation(activationType);
        }


        public int Uints
        {
            get => _uints;
            set => SetProperty(ref _uints, value);
        }

        public Activation Activator
        {
            get => _activator;
            set => SetProperty(ref _activator, value);
        }

        /// <summary>
        ///     Height should be Unit
        ///     Width should be
        /// </summary>
        public Matrix<double> Kenerl
        {
            get => _kenerl;
            set => SetProperty(ref _kenerl, value);
        }

        public Matrix<double> Bias
        {
            get => _bias;
            set => SetProperty(ref _bias, value);
        }

        public override Matrix<double> Call(Matrix<double> inPut)
        {
            InputShape = Shape.From(inPut);
            if (InputShape.Width != 1)
                throw new Exception();

            if (Kenerl == null)
            {
                Kenerl = CreateMatrix.Random<double>(InputShape.Height, Uints, new Normal());
                Bias = CreateMatrix.Random<double>(Uints, 1, new Normal());
            }

            var mul = inPut.Transpose().Multiply(Kenerl); /// dot(input, kernel)
            var outRes = mul.Transpose().Add(Bias); /// +bias
            return CreateMatrix.Dense(outRes.RowCount, outRes.ColumnCount, /// activate
                (i, j) => Activator.ActivateFunc(outRes[i, j]));
        }

        public override Matrix<double> CallBack(Matrix<double> inPut)
        {
            throw new NotImplementedException();
        }


        public override Dictionary<string, object> GetConfigs()
        {
            return new Dictionary<string, object>();
        }
    }
}