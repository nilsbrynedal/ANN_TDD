using System.Collections.Generic;
using System.Linq;

namespace ANN_TDD
{
    public class Trainer : ITrainer
    {
        public void Train(INet net, List<Data> data)
        {
            foreach (Data element in data)
            {
                net.Update(element.Pixles);
                net.Backpropagate(ExpectedOutput(element.Label));
            }
        }

        private float[] ExpectedOutput(int label)
        {
            var output = Enumerable.Repeat((float)-1.0, 10).ToArray();
            output[label] = (float)1.0;
            return output;
        }
    }
}