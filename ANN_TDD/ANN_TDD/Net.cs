using System.Collections.Generic;

namespace ANN_TDD
{
    public class Net : INet
    {
        private readonly List<ILayer> layers;

        public Net(List<IHiddenLayer> hiddenLayers, IOutputLayer outputLayer)
        {
            layers = new List<ILayer>();
            hiddenLayers.ForEach(x => layers.Add(x));
            layers.Add(outputLayer);
        }

        public IReadOnlyCollection<ILayer> Layers => layers.AsReadOnly();

        public void Backpropagate(float[] correctValues)
        {
            (layers[layers.Count - 1] as IOutputLayer).Backpropagate(correctValues);

            for (int i = layers.Count - 1; i >= 1; i--)
            {
                (layers[i - 1] as IHiddenLayer).Backpropagate(layers[i]);
            }
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