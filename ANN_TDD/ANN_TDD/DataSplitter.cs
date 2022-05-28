using System.Collections.Generic;

namespace ANN_TDD
{
    internal static class DataSplitter
    {
        internal static (List<Data> trainingSet, List<Data> testingSet, List<Data> validationSet) Split(List<Data> input, double proportionTraining, double proportionTesting)
        {
            var trainingSet = new List<Data>();
            trainingSet.AddRange(input.GetRange(0, (int)(proportionTraining * input.Count)));

            List<Data> testingSet = new List<Data>();
            testingSet.AddRange(input.GetRange(trainingSet.Count, (int)(proportionTesting * input.Count)));

            List<Data> validationSet = new List<Data>();
            int count = input.Count - trainingSet.Count - testingSet.Count;
            validationSet.AddRange(input.GetRange(trainingSet.Count + testingSet.Count, count));

            return (trainingSet, testingSet, validationSet);
        }
    }
}