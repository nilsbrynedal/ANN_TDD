using System;

namespace ANN_TDD
{
    public class Neuron : INeuron
    {
        private readonly Func<float, float> activationFunction;

        protected readonly float[] weights;
        protected float output;

        public Neuron(float[] weights, Func<float, float> activationFunction)
        {
            this.weights = weights;
            this.activationFunction = activationFunction;
        }

        public virtual float Update(float[] inputs)
        {
            if (inputs.Length != weights.Length - 1)
            {
                throw new ArgumentException();
            }

            float activation = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                activation += inputs[i] * weights[i];
            }
            activation += weights[weights.Length - 1];

            output = activationFunction(activation);
            return output;
        }
    }
}