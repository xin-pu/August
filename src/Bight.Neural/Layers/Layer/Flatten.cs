using System.Collections.Generic;
using System.Linq;
using Bight.Neural.Core;
using MathNet.Numerics.LinearAlgebra;

namespace Bight.Neural.Layers
{
    public class Flatten : Layer
    {


        public override Matrix<double> Call(Matrix<double> intPut)
        {
            InputShape = Shape.From(intPut);
            var level = InputShape.Levels;
            OutputShape = new Shape(level);
            var rowMajorvalues = intPut.Enumerate().ToArray();

            return CreateMatrix.Dense(OutputShape.Height, OutputShape.Width, rowMajorvalues);
        }



        public override Dictionary<string, object> GetConfigs()
        {
            return new Dictionary<string, object>();
        }
    }
}
