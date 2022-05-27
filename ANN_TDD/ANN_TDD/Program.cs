using System;
using System.Collections.Generic;

namespace ANN_TDD
{
    class Program
    {
        static void Main()
        {
            const int possibleAnswers = 10;

            List<Data> data = Data.ReadFile();
            INetFactory factory = new NetFactory();

            INet net = factory.CreateNet(data[0].Pixles.Length, possibleAnswers, 6);
            IIdentifier identifier = new Identifier(net);
            
            identifier.Identify(data[0].Pixles);
            Tester tester = new Tester();

            float proportion = tester.Test(identifier, data);

            Console.WriteLine("Identified " + (proportion * 100).ToString() + "% correctly");

            Console.ReadKey();
        }
    }
}
