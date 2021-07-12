using System;
using System.Linq;

namespace Bight.Losser.Loss
{
    // Todo Add More Loss Basic function

    /// <summary>
    ///     Loss function, Cost function
    /// </summary>
    public static class LossFunc
    {
        public static Func<double[], double[], double> GetL1Loss =>
            (y_actual, y_estimatee) =>
            {
                return y_actual.Zip(y_estimatee, (d, d1) =>
                    Math.Abs(d - d1)).Sum();
            };

        /// <summary>
        ///     L2 Loss
        /// </summary>
        public static Func<double[], double[], double> GetL2Loss =>
            (y_actual, y_estimatee) =>
            {
                return y_actual.Zip(y_estimatee, (d, d1) =>
                    Math.Pow(d - d1, 2)).Sum();
            };

        /// <summary>
        ///     Mean squared error
        /// </summary>
        public static Func<double[], double[], double> GetL2MeanLoss =>
            (y_actual, y_estimatee) =>
            {
                return y_actual.Zip(y_estimatee, (d, d1) =>
                    Math.Pow(d - d1, 2)).Average();
            };
    }
}