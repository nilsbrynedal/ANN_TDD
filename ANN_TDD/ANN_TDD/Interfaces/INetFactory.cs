namespace ANN_TDD
{
    public interface INetFactory
    {
        /// <summary>
        /// Creates a new net
        /// </summary>
        /// <param name="inputCount">How many inputs</param>
        /// <param name="outputCount">How many outputs</param>
        /// <param name="neuronsPerHiddenLayer">How many neurons in the hidden layers</param>
        /// <param name="learningRate">Optional learning rate parameter, i.e. how quickly the net
        /// makes changes based on new learning.</param>
        /// <returns>A finished neural net</returns>
        INet CreateNet(int inputCount, int outputCount, int neuronsPerHiddenLayer, float learningRate = (float)0.04);
    }
}