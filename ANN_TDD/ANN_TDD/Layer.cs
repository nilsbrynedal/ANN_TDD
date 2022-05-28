using System.Collections.Generic;
using System.Linq;

namespace ANN_TDD
{
    public class Layer : ILayer
    {
        protected readonly List<INeuron> neurons;

        public Layer(List<INeuron> neurons)
        {
            this.neurons = neurons;
        }

        public float[] Update(float[] data)
        {
            var output = neurons.Select(neuron => neuron.Update(data));
            return output.ToArray();
        }

        public float DownstreamError(int index)
        {
            float sum = 0;
            neurons.ForEach(n => sum += n.ErrorTerm * n.Weights[index]);

            return sum;
        }
    }
}