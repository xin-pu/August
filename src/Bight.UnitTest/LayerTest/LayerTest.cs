using System;
using Bight.Neural.Core;
using Bight.Neural.Layers;
using FluentAssertions;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;
using Xunit;

namespace Bight.UnitTest.LayerTest
{
    public class LayerTest
    {
        private readonly Flatten flatten = new Flatten();
        private readonly Dense dense = new Dense(10);
        private readonly Normal random = new Normal();

        private void Print(object obj)
        {
            Console.WriteLine(obj);
        }


        

        [Fact]
        public void PrintLayerTest()
        {

            Print(flatten);
            var outMatrix = flatten.Call(DenseMatrix.CreateRandom(3, 3, random));
            Print(flatten);
            Print(outMatrix);
            flatten.InputShape.Should().Be(new Shape(3, 3));
            flatten.OutputShape.Should().Be(new Shape(9));
        }



        [Fact]
        public void TransferTest()
        {
            var outMatrix = flatten.Call(DenseMatrix.CreateRandom(3, 3, random));
            outMatrix = flatten.Call(outMatrix);
            outMatrix = dense.Call(outMatrix);
            Print(outMatrix);
        }

        [Fact]
        public void CloneFlatten()
        {
            var clone = flatten.Clone();
            Print(clone);
        }

        [Fact]
        public void CloneDense()
        {
            var clone = dense.Clone();
            Print(clone);
        }

    }
}
