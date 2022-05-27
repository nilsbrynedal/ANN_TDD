using System;
using System.Collections.Generic;

namespace ANN_TDD
{
    public class NetFactory : INetFactory
    {
        private readonly Random random;

        public NetFactory()
        {
            random = new Random();
        }

        /// <summary>
        /// Creates a new net
        /// </summary>
        /// <param name="inputCount">How many inputs</param>
        /// <param name="outputCount">How many outputs</param>
        /// <param name="neuronsPerHiddenLayer">How many neurons in the hidden layers</param>
        /// <param name="learningRate">Optional learning rate parameter, i.e. how quickly the net
        /// makes changes based on new learning.</param>
        /// <returns>A finished neural net</returns>
        public INet CreateNet(int inputCount, int outputCount, int neuronsPerHiddenLayer, float learningRate = (float)0.04)
        {
            // input layer
            List<INeuron> neuronsFirstLayer = new List<INeuron>();
            for(int i = 0; i < neuronsPerHiddenLayer; i++)
            {
                neuronsFirstLayer.Add(new Neuron(CreateWeights(inputCount + 1), Sigmoid));
            }

            // hidden layer
            List<INeuron> neuronsSecondLayer = new List<INeuron>();
            for (int i = 0; i < neuronsPerHiddenLayer; i++)
            {
                neuronsSecondLayer.Add(new Neuron(CreateWeights(neuronsPerHiddenLayer + 1), Sigmoid));
            }

            // output layer
            List<IOutputNeuron> neuronsThirdLayer = new List<IOutputNeuron>();
            for (int i = 0; i < outputCount; i++)
            {
                neuronsThirdLayer.Add(new OutputNeuron(CreateWeights(neuronsPerHiddenLayer + 1), Sigmoid, DerivativeOfSigmoid, learningRate));
            }

            List<IHiddenLayer> layers = new List<IHiddenLayer>()
            {
                new HiddenLayer(neuronsFirstLayer),
                new HiddenLayer(neuronsSecondLayer)
            };
            return new Net(layers, new OutputLayer(neuronsThirdLayer));
        }

        public static float Sigmoid(float input) => (float)(Math.Exp(input) / (Math.Exp(input) + 1));

        public static float DerivativeOfSigmoid(float input) => Sigmoid(input) * (1 - Sigmoid(input));

        private float[] CreateWeights(int count)
        {
            float[] weights = new float[count];
            for (int i = 0; i < count; i++)
            {
                weights[i] = (float)(random.NextDouble() * 2 - 1.0);
            }
            return weights;
        }
    }
}