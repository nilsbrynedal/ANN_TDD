using ANN_TDD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ANN_TDD
{
    internal class HiddenLayer : Layer, IHiddenLayer
    {
        public HiddenLayer(List<IHiddenNeuron> neurons) : base(neurons.Select(x => (INeuron)x).ToList())
        {
        }

        public void Backpropagate(ILayer downstreamLayer)
        {
            for (int i = 0; i < neurons.Count; i++)
            {
                (neurons[i] as IHiddenNeuron).UpdateErrorTerm(downstreamLayer.DownstreamError(i));
            }
        }
    }
}