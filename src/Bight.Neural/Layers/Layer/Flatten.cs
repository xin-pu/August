using System.Collections.Generic;
using Bight.Neural.Core;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Bight.Neural.Layers
{
    public class Flatten : Layer
    {


        public override DenseMatrix Call(DenseMatrix input)
        {
            InputShape = Shape.From(input);
            var level = InputShape.Levels;
            OutputShape = new Shape(level);
            var rowMajorvalues = input.Enumerate();
            return DenseMatrix.OfColumnMajor(OutputShape.Height, OutputShape.Width, rowMajorvalues);
        }

        public override Dictionary<string, object> GetConfigs()
        {
            return new Dictionary<string, object>();
        }
    }
}
