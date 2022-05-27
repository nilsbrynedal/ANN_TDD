using System.Collections.Generic;

namespace ANN_TDD
{
    public interface ITrainer
    {
        void Train(INet net, List<Data> data);
    }
}