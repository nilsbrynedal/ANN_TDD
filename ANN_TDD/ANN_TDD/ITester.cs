using System.Collections.Generic;

namespace ANN_TDD
{
    public interface ITester
    {
        float Test(IIdentifier identifier, List<Data> data);
    }
}