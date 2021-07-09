using System;
using Bight.Neural.Core;
using Bight.Neural.Layers;
using FluentAssertions;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;
using NUnit.Framework;

namespace Bight.UnitTest.LayerTest
{
    public class LayerTest
    {
        private readonly Flatten flatten = new Flatten();
        private readonly Normal random = new Normal();

        private void Print(object obj)
        {
            Console.WriteLine(obj);
        }


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PrintLayerTest()
        {

            Print(flatten);
            var outMatrix = flatten.Call(DenseMatrix.CreateRandom(3, 3, random));
            Print(flatten);
            Print(outMatrix);
            flatten.InputShape.Should().Be(new Shape(3, 3));
            flatten.OutputShape.Should().Be(new Shape(9));
        }


    }
}
