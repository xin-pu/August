using System.Collections.Generic;
using System.Linq;
using Bight.Neural.Core;
using MathNet.Numerics.LinearAlgebra;

namespace Bight.Neural.Layers
{
    public class Flatten : Layer
    {
        public override Matrix<double> Call(Matrix<double> inPut)
        {
            InputShape = Shape.From(inPut);
            var level = InputShape.Levels;
            OutputShape = new Shape(level);
            var rowMajorvalues = inPut.Enumerate().ToArray();

            return CreateMatrix.Dense(OutputShape.Height, OutputShape.Width, rowMajorvalues);
        }

        public override Matrix<double> CallBack(Matrix<double> inPut)
        {
            return inPut;
        }


        public override Dictionary<string, object> GetConfigs()
        {
            return new Dictionary<string, object>();
        }
    }
}