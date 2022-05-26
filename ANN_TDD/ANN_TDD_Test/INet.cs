namespace ANN_TDD
{
    public interface INet
    {
        /// <summary>
        /// Inputs data to the net. Shall update each layer.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        float[] Update(float[] data);
    }
}