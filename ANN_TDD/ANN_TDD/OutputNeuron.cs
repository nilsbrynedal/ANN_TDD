using System;


namespace ANN_TDD
{
    public class OutputNeuron : Neuron, IOutputNeuron
    {
        private float[] inputs;
        private float errorTerm;
        private readonly Func<float, float> derivativeOfActivationFunc;
        private readonly float learningRate;

        private float ErrorTerm
        { 
            get => errorTerm;
            set
            {
                errorTerm = value;
                UpdateWeights();
            }
        }

        public OutputNeuron(float[] weights, Func<float, float> activationFunction, Func<float, float> derivativeOfActivationFunc, float learningRate) :
            base(weights, activationFunction)
        {
            this.derivativeOfActivationFunc = derivativeOfActivationFunc;
            this.learningRate = learningRate;
        }

        public override float Update(float[] inputs)
        {
            this.inputs = inputs;
            return base.Update(inputs);
        }

        public void UpdateErrorTerm(float correctValue)
        {
            ErrorTerm = (correctValue - output) * derivativeOfActivationFunc(output);
        }

        private void UpdateWeights()
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                weights[i] += learningRate * ErrorTerm * inputs[i];
            }
            //this is the last weight and input is 1 since Weights are 1 more than the inputs
            weights[weights.Length - 1] += learningRate * ErrorTerm;
        }
    }
}
