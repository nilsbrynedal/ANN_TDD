using System.Collections;
using System.Collections.Generic;

namespace ANN_TDD
{
    public interface INet
    {
        IReadOnlyCollection<ILayer> Layers { get; }

        /// <summary>
        /// Inputs data to the net. Shall update each layer.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        float[] Update(float[] data);

        /// <summary>
        /// Starts backpropagation
        /// </summary>
        /// <param name="correctValues">The correct values for 
        /// each neuron of the outut layer.</param>
        void Backpropagate(float[] correctValues);
    }
}