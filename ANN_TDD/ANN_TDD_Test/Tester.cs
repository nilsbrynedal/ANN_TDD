using System.Collections.Generic;

namespace ANN_TDD
{
    internal class Tester : ITester
    {
        public Tester()
        {
        }

        public float Test(IIdentifier identifier, List<Data> data) => 
            (float)data.FindAll(x => identifier.Identify(x.Pixles) == x.Label).Count / data.Count;
    }
}