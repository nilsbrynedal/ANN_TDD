using System.Collections;
using System.Collections.Generic;

namespace ANN_TDD
{
    public class Net : INet
    {
        private readonly List<ILayer> layers;

        public Net(List<ILayer> layers)
        {
            this.layers = layers;
        }

        public IReadOnlyCollection<ILayer> Layers => layers.AsReadOnly();

        public void Backpropagate(float[] correctValues1)
        {
            
        }

        public float[] Update(float[] data)
        {
            var output = data;
            foreach(ILayer layer in layers)
            {
                output = layer.Update(output);
            }
            return output;
        }
    }
}