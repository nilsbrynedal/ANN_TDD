using System;

namespace ANN_TDD
{
    public class Neuron : INeuron
    {
        private readonly float[] weights;
        private readonly Func<float, float> activationFunction;

        public Neuron(float[] weights, Func<float, float> activationFunction)
        {
            this.weights = weights;
            this.activationFunction = activationFunction;
        }

        public float Update(float[] data)
        {
            if (data.Length != weights.Length - 1)
            {
                throw new ArgumentException();
            }

            float activation = 0;

            for (int i = 0; i < data.Length; i++)
            {
                activation += data[i] * weights[i];
            }
            activation += weights[weights.Length - 1];

            return activationFunction(activation);
        }
    }
}