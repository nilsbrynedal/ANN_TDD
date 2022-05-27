namespace ANN_TDD
{
    public interface IOutputLayer : ILayer
    {
        /// <summary>
        /// Starts backpropagation
        /// </summary>
        /// <param name="correctValues">The correct values for 
        /// each neuron of the outut layer.</param>
        void Backpropagate(float[] correctValues);
    }
}