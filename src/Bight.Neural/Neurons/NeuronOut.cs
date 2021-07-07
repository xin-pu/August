namespace Bight.Neural.Neurons
{
    public struct NeuronOut
    {
        public double Weight { set; get; }
        public double Activate { set; get; }

        public NeuronOut(double weight, double activate)
        {
            Weight = weight;
            Activate = activate;
        }
    }
}
