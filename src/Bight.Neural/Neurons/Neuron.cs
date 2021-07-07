
using Bight.Neural.Layers;
using MvvmCross.ViewModels;

namespace Bight.Neural.Neurons
{
    public abstract class Neuron : MvxViewModel
    {
        private uint _id;
        private string _name;
        private Layer _parentLayer;

        public uint ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public Layer ParentLayer
        {
            get => _parentLayer;
            set => SetProperty(ref _parentLayer, value);

        }



    }
}
