using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANN_TDD.Interfaces;

namespace ANN_TDD
{
    internal class HiddenNeuron : Neuron, IHiddenNeuron
    {
        private readonly Func<float, float> derivationFunction;

        public HiddenNeuron(float[] weights, Func<float, float> activationFunction, Func<float, float> derivationFunction, float learningRate) :
            base(weights, activationFunction, learningRate)
        {
            this.derivationFunction = derivationFunction;
        }

        public void UpdateErrorTerm(float downstreamError)
        {
            ErrorTerm = derivationFunction(output) * downstreamError;
        }
    }
}
