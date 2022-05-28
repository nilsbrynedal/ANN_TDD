namespace ANN_TDD
{
    public interface INeuron
    {
        float ErrorTerm { get; }
        float[] Weights { get; }

        float Update(float[] data);
        
    }
}