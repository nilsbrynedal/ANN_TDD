using System;

namespace ANN_TDD
{
    public class Neuron : INeuron
    {
        private readonly float[] weights;

        public Neuron(float[] weights)
        {
            this.weights = weights;
        }

        public float Update(float[] data)
        {
            if (data.Length != weights.Length - 1)
            {
                throw new ArgumentException();
            }

            float output = 0;

            for (int i = 0; i < data.Length; i++)
            {
                output += data[i] * weights[i];
            }
            output += weights[weights.Length - 1];

            return output;
        }
    }
}