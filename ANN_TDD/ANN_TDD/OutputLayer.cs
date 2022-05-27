using System;
using System.Collections.Generic;

namespace ANN_TDD
{
    public class OutputLayer : Layer, IOutputLayer
    {
        public OutputLayer(List<INeuron> neurons) : base(neurons)
        {
        }

        public void Backpropagate(float[] correctValues)
        {
            
        }
    }
}
