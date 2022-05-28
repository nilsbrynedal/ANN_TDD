using System;


namespace ANN_TDD
{
    public class OutputNeuron : Neuron, IOutputNeuron
    {
        private readonly Func<float, float> derivativeOfActivationFunc;

        public OutputNeuron(float[] weights, Func<float, float> activationFunction, Func<float, float> derivativeOfActivationFunc, float learningRate) :
            base(weights, activationFunction, learningRate)
        {
            this.derivativeOfActivationFunc = derivativeOfActivationFunc;
        }

        public void UpdateErrorTerm(float correctValue)
        {
            ErrorTerm = (correctValue - output) * derivativeOfActivationFunc(output);
        }
    }
}
