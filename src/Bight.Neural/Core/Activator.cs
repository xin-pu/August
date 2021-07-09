using System;
using Bight.Mathematics.Activator;
using MathNet.Numerics;
using MvvmCross.ViewModels;
using YamlDotNet.Serialization;

namespace Bight.Neural.Core
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

        [YamlIgnore]
        public Func<double, double> ActivateFunc { set; get; }

        [YamlIgnore]
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
                    ActivateFunc = Activation.Logistic;
                    break;
                case ActivationType.Tanh:
                    ActivateFunc = Activation.Tanh;
                    break;
                case ActivationType.HardLogistic:
                    ActivateFunc = Activation.HardLogistic;
                    break;
                case ActivationType.HardTanh:
                    ActivateFunc = Activation.HardTanh;
                    break;
                case ActivationType.ReLU:
                    ActivateFunc = Activation.ReLU;
                    break;
                case ActivationType.LeakyReLu:
                    ActivateFunc = (u) => Activation.LeakyReLu(u, γ);
                    break;
                case ActivationType.PReLu:
                    ActivateFunc = (u) => Activation.PReLu(u, γ);
                    break;
                case ActivationType.ELU:
                    ActivateFunc = (u) => Activation.ELU(u, γ);
                    break;
                case ActivationType.Softplus:
                    ActivateFunc = Activation.Softplus;
                    break;
                case ActivationType.Swish:
                    ActivateFunc = (u) => Activation.Swish(u, β);
                    break;
                case ActivationType.GELU:
                    ActivateFunc = Activation.GELU;
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
