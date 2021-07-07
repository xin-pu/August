using System;
using System.Linq;

namespace Bight.Mathematics.Activator
{
    public class Activator
    {

        #region sigmod function

        public Func<double, double> Logistic =>
            u => 1 / (1 + Math.Pow(Math.E, -u));


        public Func<double, double> Tanh =>
            u => (Math.Pow(Math.E, u) - Math.Pow(Math.E, -u)) /
                 (Math.Pow(Math.E, u) + Math.Pow(Math.E, -u));


        public Func<double, double> HardLogistic =>
            u => new[] {new[] {0.25 * u + 0.5, 1}.Min(), 0}.Max();

        public Func<double, double> HardTanh =>
            u => new[] {new[] {u, 1}.Min(), -1}.Max();

        #endregion

        #region ReLu function

        public Func<double, double> ReLU =>
            u => new[] {u, 0}.Max();


        public Func<double, double, double> LeakyReLu =>
            (u, γ) => new[] {u, γ * u}.Max();

        public Func<double, double, double> PReLu =>
            (u, γ) =>
            {
                var arr = new[] {0, u};
                return arr.Max() + γ * arr.Min();
            };


        public Func<double, double, double> ELU =>
            (u, γ) =>
            {
                var arr1 = new[] {0, u}.Max();
                var arr2 = new[] {0, γ * (Math.Pow(Math.E, u) - 1)}.Min();
                return arr1 + arr2;
            };

        public Func<double, double> Softplus =>
            u => Math.Log(1 + Math.Pow(Math.E, u));

        #endregion



        #region Switch function

        public Func<double, double, double> Swish =>
            (u, β) => u * Logistic(u);

        #endregion


        #region RELU function

        public Func<double, double> GELU =>
            u => u * Logistic(1.702 * u);


        #endregion


        #region Maxout unit




        #endregion
    }
}
