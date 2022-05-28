using System;
using System.Collections.Generic;

namespace ANN_TDD
{
    class Program
    {
        static void Main()
        {
            const int possibleAnswers = 10;
            float proportion;
            List<Data> data = Data.ReadFile();

            (var trainingSet, var testingSet, var validationSet) = DataSplitter.Split(data, 0.7, 0.2);

            INetFactory factory = new NetFactory();
            INet net = factory.CreateNet(data[0].Pixles.Length, possibleAnswers, 6, (float)0.1);
            IIdentifier identifier = new Identifier(net);
            ITrainer trainer = new Trainer();
            Tester tester = new Tester();

            for(int i = 0; i < 100; i++)
            {
                trainer.Train(net, trainingSet);
                proportion = tester.Test(identifier, testingSet);

                Console.WriteLine(i.ToString() + "\tIdentified " + (proportion * 100).ToString() + "% of testing set correctly");
            }

            proportion = tester.Test(identifier, validationSet);
            Console.WriteLine("Identified " + (proportion * 100).ToString() + "% of validation set correctly");

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
