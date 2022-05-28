using System;

namespace ANN_TDD
{
    public class Neuron : INeuron
    {
        private readonly Func<float, float> activationFunction;
        private readonly float learningRate;
        private float errorTerm;
        protected float output;
        protected float[] inputs;
        protected float activation;

        public Neuron(float[] weights, Func<float, float> activationFunction, float learningRate = (float)0.04)
        {
            this.Weights = weights;
            this.activationFunction = activationFunction;
            this.learningRate = learningRate;
        }

        public float Update(float[] inputs)
        {
            if (inputs.Length != Weights.Length - 1)
            {
                throw new ArgumentException();
            }

            this.inputs = inputs;

            activation = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                activation += inputs[i] * Weights[i];
            }
            activation += Weights[Weights.Length - 1];

            output = activationFunction(activation);
            return output;
        }

        public float ErrorTerm
        {
            get => errorTerm;
            protected set
            {
                errorTerm = value;
                UpdateWeights();
            }
        }

        public float[] Weights { get; }

        private void UpdateWeights()
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                Weights[i] += learningRate * ErrorTerm * inputs[i];
            }
            //this is the last weight and input is 1 since Weights are 1 more than the inputs
            Weights[Weights.Length - 1] += learningRate * ErrorTerm;
        }
    }
}