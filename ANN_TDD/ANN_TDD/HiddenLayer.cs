using System.Collections.Generic;

namespace ANN_TDD
{
    internal class HiddenLayer : Layer, IHiddenLayer
    {
        public HiddenLayer(List<INeuron> neurons) : base(neurons)
        {
        }

        public void Backpropagate(ILayer downstreamLayer)
        {
            
        }
    }
}