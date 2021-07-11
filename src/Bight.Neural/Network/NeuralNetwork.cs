using MvvmCross.ViewModels;

namespace Bight.Neural.Network
{
    public abstract class NeuralNetwork : MvxViewModel
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}