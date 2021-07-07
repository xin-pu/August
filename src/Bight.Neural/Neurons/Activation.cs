using System;
using Bight.Mathematics.Activator;
using MvvmCross.ViewModels;
using Activator = Bight.Mathematics.Activator.Activator;

namespace Bight.Neural.Neurons
{
    public class Activation : MvxViewModel
    {

        private ActivatorType activatorType;
        private double β = 0.1;
        private double λ = 0.1;


        public ActivatorType ActivatorType
        {
            get => activatorType;
            set => SetProperty(ref activatorType, value);
        }

        public double Λ
        {
            get => λ;
            set => SetProperty(ref λ, value);
        }

        public double Β
        {
            get => β;
            set => SetProperty(ref β, value);
        }

        public Func<double, double> ActivateFunc { set; get; }

        /// <summary>
        /// Generate Activation
        /// </summary>
        public Activation() :
            this(ActivatorType.ReLU)
        {

        }

        public Activation(
            ActivatorType activator,
            double γ = 0.1,
            double β = 0.1)
        {
            switch (activator)
            {
                case ActivatorType.Logistic:
                    ActivateFunc = Activator.Logistic;
                    break;
                case ActivatorType.Tanh:
                    ActivateFunc = Activator.Tanh;
                    break;
                case ActivatorType.HardLogistic:
                    ActivateFunc = Activator.HardLogistic;
                    break;
                case ActivatorType.HardTanh:
                    ActivateFunc = Activator.HardTanh;
                    break;
                case ActivatorType.ReLU:
                    ActivateFunc = Activator.ReLU;
                    break;
                case ActivatorType.LeakyReLu:
                    ActivateFunc = (u) => Activator.LeakyReLu(u, γ);
                    break;
                case ActivatorType.PReLu:
                    ActivateFunc = (u) => Activator.PReLu(u, γ);
                    break;
                case ActivatorType.ELU:
                    ActivateFunc = (u) => Activator.ELU(u, γ);
                    break;
                case ActivatorType.Softplus:
                    ActivateFunc = Activator.Softplus;
                    break;
                case ActivatorType.Swish:
                    ActivateFunc = (u) => Activator.Swish(u, β);
                    break;
                case ActivatorType.GELU:
                    ActivateFunc = Activator.GELU;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(activator), activator, null);
            }
        }

        public double Activate(double u)
        {
            return ActivateFunc(u);
        }

    }
}
