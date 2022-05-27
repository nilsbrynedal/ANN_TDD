namespace ANN_TDD
{
    public interface IOutputNeuron : INeuron
    {
        /// <summary>
        /// Updates the error term on this neuron
        /// </summary>
        /// <param name="correctValue">The expected output of this neuron</param>
        void UpdateErrorTerm(float correctValue);
    }
}