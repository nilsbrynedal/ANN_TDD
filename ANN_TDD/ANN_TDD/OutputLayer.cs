using System;
using System.Collections.Generic;
using System.Linq;

namespace ANN_TDD
{
    public class OutputLayer : Layer, IOutputLayer
    {
        public OutputLayer(List<IOutputNeuron> neurons) : base(neurons.Select(x => (INeuron)x).ToList()) 
        {
        }

        public void Backpropagate(float[] correctValues)
        {
            if(correctValues.Length != neurons.Count)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < neurons.Count; i++)
            {
                (neurons[i] as IOutputNeuron).UpdateErrorTerm(correctValues[i]);
            }
        }
    }
}
