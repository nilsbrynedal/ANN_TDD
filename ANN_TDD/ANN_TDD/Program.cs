using System.Collections.Generic;

namespace ANN_TDD
{
    class Program
    {
        static void Main(string[] args)
        {
            const int possibleAnswers = 10;

            List<Data> data = Data.ReadFile();
            INetFactory factory = new NetFactory();

            INet net = factory.CreateNet(data[0].Pixles.Length, possibleAnswers, 6);

            var output = net.Update(data[0].Pixles);
        }
    }
}
