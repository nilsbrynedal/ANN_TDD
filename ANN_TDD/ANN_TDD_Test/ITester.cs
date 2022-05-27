using System.Collections.Generic;

namespace ANN_TDD
{
    internal interface ITester
    {
        float Test(IIdentifier identifier, List<Data> data);
    }
}