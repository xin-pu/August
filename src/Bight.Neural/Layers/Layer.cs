
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
        public uint ID { set; get; }

        public bool Trainable { set; get; }

        public Shape Shape { set; get; }



        public abstract Matrix Call(Matrix denseMatrix);

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
