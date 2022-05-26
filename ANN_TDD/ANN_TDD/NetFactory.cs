﻿using System;
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
        /// <returns>A finished neural net</returns>
        public INet CreateNet(int inputCount, int outputCount, int neuronsPerHiddenLayer)
        {
            // input layer
            List<INeuron> neuronsFirstLayer = new List<INeuron>();
            for(int i = 0; i < neuronsPerHiddenLayer; i++)
            {
                neuronsFirstLayer.Add(new Neuron(CreateWeights(inputCount + 1)));
            }

            // hidden layer
            List<INeuron> neuronsSecondLayer = new List<INeuron>();
            for (int i = 0; i < neuronsPerHiddenLayer; i++)
            {
                neuronsSecondLayer.Add(new Neuron(CreateWeights(neuronsPerHiddenLayer + 1)));
            }

            // output layer
            List<INeuron> neuronsThirdLayer = new List<INeuron>();
            for (int i = 0; i < outputCount; i++)
            {
                neuronsThirdLayer.Add(new Neuron(CreateWeights(neuronsPerHiddenLayer + 1)));
            }

            List<ILayer> layers = new List<ILayer>()
            {
                new Layer(neuronsFirstLayer),
                new Layer(neuronsSecondLayer),
                new Layer(neuronsThirdLayer)
            };
            return new Net(layers);
        }

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