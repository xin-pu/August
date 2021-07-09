using System.Collections.Generic;
using Bight.Neural.Core;
using MathNet.Numerics.LinearAlgebra.Double;
using MvvmCross.ViewModels;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YAXLib;

namespace Bight.Neural.Layers
{
    public abstract class Layer : MvxViewModel
    {

    private bool _trainable;
    private Shape _inputShape;
    private Shape _outputShape;

    public uint ID { set; get; }

    public bool Trainable
    {
        get => _trainable;
        set => SetProperty(ref _trainable, value);
    }

    public Shape InputShape
    {
        get => _inputShape;
        set => SetProperty(ref _inputShape, value);
    }

    public Shape OutputShape
    {
        get => _outputShape;
        set => SetProperty(ref _outputShape, value);
    }

    internal Layer()
    {

    }


    public abstract DenseMatrix Call(DenseMatrix denseMatrix);

    public abstract Dictionary<string, object> GetConfigs();



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
