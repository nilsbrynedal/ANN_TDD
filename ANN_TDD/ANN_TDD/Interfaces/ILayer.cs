namespace ANN_TDD
{
    public interface ILayer
    {
        float[] Update(float[] data);
        float DownstreamError(int i);
    }
}