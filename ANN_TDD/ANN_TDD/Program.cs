using System;
using System.Collections.Generic;

namespace ANN_TDD
{
    class Program
    {
        static void Main()
        {
            //Test();
            //return;

            const int possibleAnswers = 10;
            float proportion;
            List<Data> data = Data.ReadFile();

            (var trainingSet, var testingSet, var validationSet) = DataSplitter.Split(data, 0.7, 0.2);

            INetFactory factory = new NetFactory();
            INet net = factory.CreateNet(data[0].Pixles.Length, possibleAnswers, 10, (float)0.04);
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

        /// <summary>
        /// Test program to run on a small subset of the data
        /// </summary>
        private static void Test()
        {
            const int possibleAnswers = 10;
            float proportion;
            List<Data> data = Data.ReadFile();

            Console.WriteLine("Testing with a very small part of the test data\n");

            (var trainingSet, var testingSet, var validationSet) = DataSplitter.Split(data, 0.01, 0.2);

            INetFactory factory = new NetFactory();
            INet net = factory.CreateNet(data[0].Pixles.Length, possibleAnswers, 10, (float)0.01);
            IIdentifier identifier = new Identifier(net);
            ITrainer trainer = new Trainer();
            Tester tester = new Tester();

            for (int i = 0; i < 1000; i++)
            {
                trainer.Train(net, trainingSet);
                proportion = tester.Test(identifier, trainingSet);

                Console.WriteLine(i.ToString() + "\tIdentified " + (proportion * 100).ToString() + "% of training set correctly");
            }

            proportion = tester.Test(identifier, trainingSet);
            Console.WriteLine("Identified " + (proportion * 100).ToString() + "% of training set correctly");

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
