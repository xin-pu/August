using MvvmCross.ViewModels;

namespace Bight.Neural.Core
{
    public class NeuronOutput : MvxViewModel
    {
        private double _netActivate;
        private double _netInput;


        public NeuronOutput(double netInput, double netActivate)
        {
            NetInput = netInput;
            NetActivate = netActivate;
        }


        public double NetInput
        {
            get => _netInput;
            private set => SetProperty(ref _netInput, value);
        }

        public double NetActivate
        {
            get => _netActivate;
            private set => SetProperty(ref _netActivate, value);
        }
    }
}