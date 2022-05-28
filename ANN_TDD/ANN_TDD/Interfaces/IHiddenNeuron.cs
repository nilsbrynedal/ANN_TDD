namespace ANN_TDD.Interfaces
{
    interface IHiddenNeuron : INeuron
    {
        void UpdateErrorTerm(float downstreamError);
    }
}
