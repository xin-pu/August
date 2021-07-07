using System;
using Bight.Mathematics.Activator;
using MathNet.Numerics;
using MvvmCross.ViewModels;

namespace Bight.Neural.Neurons
{
    public class Activator : MvxViewModel
    {

        private ActivationType activatorType;
        private double β = 0.1;
        private double λ = 0.1;


        public ActivationType ActivatorType
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
        public Func<double, double> FirstDerivativeFunc { set; get; }

        /// <summary>
        /// Generate Activation
        /// </summary>
        public Activator() :
            this(ActivationType.ReLU)
        {

        }

        public Activator(
            ActivationType activator,
            double γ = 0.1,
            double β = 0.1)
        {
            switch (activator)
            {
                case ActivationType.Logistic:
                    ActivateFunc = Mathematics.Activator.Activation.Logistic;
                    break;
                case ActivationType.Tanh:
                    ActivateFunc = Mathematics.Activator.Activation.Tanh;
                    break;
                case ActivationType.HardLogistic:
                    ActivateFunc = Mathematics.Activator.Activation.HardLogistic;
                    break;
                case ActivationType.HardTanh:
                    ActivateFunc = Mathematics.Activator.Activation.HardTanh;
                    break;
                case ActivationType.ReLU:
                    ActivateFunc = Mathematics.Activator.Activation.ReLU;
                    break;
                case ActivationType.LeakyReLu:
                    ActivateFunc = (u) => Mathematics.Activator.Activation.LeakyReLu(u, γ);
                    break;
                case ActivationType.PReLu:
                    ActivateFunc = (u) => Mathematics.Activator.Activation.PReLu(u, γ);
                    break;
                case ActivationType.ELU:
                    ActivateFunc = (u) => Mathematics.Activator.Activation.ELU(u, γ);
                    break;
                case ActivationType.Softplus:
                    ActivateFunc = Mathematics.Activator.Activation.Softplus;
                    break;
                case ActivationType.Swish:
                    ActivateFunc = (u) => Mathematics.Activator.Activation.Swish(u, β);
                    break;
                case ActivationType.GELU:
                    ActivateFunc = Mathematics.Activator.Activation.GELU;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(activator), activator, null);
            }

            FirstDerivativeFunc = Differentiate.FirstDerivativeFunc(ActivateFunc);
        }

        public double Activate(double u)
        {
            return ActivateFunc(u);
        }

    }
}
