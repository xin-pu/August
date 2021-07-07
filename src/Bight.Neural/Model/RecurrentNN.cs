using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Bight.Neural.Model
{
    public class RecurrentNN : NeuralNetwork
    {



        public virtual void Serializer()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build(); 
            var yaml = serializer.Serialize(this);
        }
    }
}
