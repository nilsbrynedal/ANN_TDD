using System.Collections.Generic;

namespace ANN_TDD
{
    public class Net : INet
    {
        private readonly List<ILayer> layers;

        public Net(List<ILayer> hiddenLayers, IOutputLayer outputLayer)
        {
            layers = hiddenLayers;
            layers.Add(outputLayer);
        }

        public IReadOnlyCollection<ILayer> Layers => layers.AsReadOnly();

        public void Backpropagate(float[] correctValues)
        {
            (layers[layers.Count - 1] as IOutputLayer).Backpropagate(correctValues);
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