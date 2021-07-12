using System;
using MathNet.Numerics;
using MvvmCross.ViewModels;
using YamlDotNet.Serialization;

namespace Bight.Neural.Activator
{
    public class Activation : MvxViewModel
    {
        private ActivationType activatorType;
        private double β = 0.1;
        private double λ = 0.1;

        /// <summary>
        ///     Generate Activation
        /// </summary>
        public Activation() :
            this(ActivationType.ReLU)
        {
        }

        public Activation(
            ActivationType activator,
            double γ = 0.1,
            double β = 0.1)
        {
            switch (activator)
            {
                case ActivationType.Logistic:
                    ActivateFunc = ActivationFunc.Logistic;
                    break;
                case ActivationType.Tanh:
                    ActivateFunc = ActivationFunc.Tanh;
                    break;
                case ActivationType.HardLogistic:
                    ActivateFunc = ActivationFunc.HardLogistic;
                    break;
                case ActivationType.HardTanh:
                    ActivateFunc = ActivationFunc.HardTanh;
                    break;
                case ActivationType.ReLU:
                    ActivateFunc = ActivationFunc.ReLU;
                    break;
                case ActivationType.LeakyReLu:
                    ActivateFunc = u => ActivationFunc.LeakyReLu(u, γ);
                    break;
                case ActivationType.PReLu:
                    ActivateFunc = u => ActivationFunc.PReLu(u, γ);
                    break;
                case ActivationType.ELU:
                    ActivateFunc = u => ActivationFunc.ELU(u, γ);
                    break;
                case ActivationType.Softplus:
                    ActivateFunc = ActivationFunc.Softplus;
                    break;
                case ActivationType.Swish:
                    ActivateFunc = u => ActivationFunc.Swish(u, β);
                    break;
                case ActivationType.GELU:
                    ActivateFunc = ActivationFunc.GELU;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(activator), activator, null);
            }

            FirstDerivativeFunc = Differentiate.FirstDerivativeFunc(ActivateFunc);
        }


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

        [YamlIgnore] public Func<double, double> ActivateFunc { get; }

        [YamlIgnore] public Func<double, double> FirstDerivativeFunc { get; }

        public double Activate(double u)
        {
            return ActivateFunc(u);
        }

        public override string ToString()
        {
            return $"Activator:{ActivatorType}\tΛ:{Λ}\tΒ{Β}";
        }
    }
}