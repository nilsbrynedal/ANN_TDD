namespace ANN_TDD
{
    public interface IHiddenLayer : ILayer
    {
        /// <summary>
        /// Runs backpropagation on this layer
        /// </summary>
        /// <param name="downstreamLayer">The layer that is after this layer.</param>
        void Backpropagate(ILayer downstreamLayer);
    }
}