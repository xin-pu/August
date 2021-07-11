using System;
using System.Collections.Generic;
using Bight.Neural.Core;
using MathNet.Numerics.LinearAlgebra;

namespace Bight.Neural.Layers
{
    public class Reshape : Layer
    {
        public Reshape(Shape shape)
        {
            OutputShape = shape;
        }

        public override Matrix<double> Call(Matrix<double> inPut)
        {
            throw new NotImplementedException();
        }

        public override Matrix<double> CallBack(Matrix<double> inPut)
        {
            return inPut;
        }

        public override Dictionary<string, object> GetConfigs()
        {
            throw new NotImplementedException();
        }
    }
}