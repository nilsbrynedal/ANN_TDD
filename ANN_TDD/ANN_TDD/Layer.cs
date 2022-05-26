using System.Collections.Generic;
using System.Linq;

namespace ANN_TDD
{
    public class Layer : ILayer
    {
        private readonly List<INeuron> neurons;

        public Layer(List<INeuron> neurons)
        {
            this.neurons = neurons;
        }

        public float[] Update(float[] data)
        {
            var output = neurons.Select(neuron => neuron.Update(data));
            return output.ToArray();
        }
    }
}