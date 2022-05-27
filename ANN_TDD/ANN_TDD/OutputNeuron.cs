using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_TDD
{
    public class OutputNeuron : Neuron, IOutputNeuron
    {
        public OutputNeuron(float[] weights, Func<float, float> activationFunction) : base(weights, activationFunction)
        {
        }

        public void UpdateErrorTerm(float i)
        {
            
        }
    }
}
