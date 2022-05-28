using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ANN_TDD
{
    [TestClass]
    public class DataSplitterTests
    {
        private List<Data> trainingSet;
        private List<Data> testingSet;
        private List<Data> validationSet;

        [TestInitialize]
        public void Setup()
        {
            List<Data> input = new List<Data>()
            {
                new Data(0, null),
                new Data(1, null),
                new Data(2, null),
                new Data(3, null),
                new Data(4, null),
                new Data(5, null),
                new Data(6, null),
                new Data(7, null),
                new Data(8, null),
                new Data(9, null)
            };
            double proportionTraining = 0.7;
            double proportionTesting = 0.2;

            (trainingSet, testingSet, validationSet) = DataSplitter.Split(input, proportionTraining, proportionTesting);
        }

        [TestMethod]
        public void ShallSplitDataWithCorrectLengths()
        {
            Assert.AreEqual(7, trainingSet.Count);
            Assert.AreEqual(2, testingSet.Count);
            Assert.AreEqual(1, validationSet.Count);
        }
        
        [TestMethod]
        public void ShallSplitDataWithCorrectTrainingSet()
        {
            for (int i = 0; i < 7; i++)
                Assert.AreEqual(i, trainingSet[i].Label);
        }

        [TestMethod]
        public void ShallSplitDataWithCorrectTestingSet()
        {
            Assert.AreEqual(7, testingSet[0].Label);
            Assert.AreEqual(8, testingSet[1].Label);
        }

        [TestMethod]
        public void ShallSplitDataWithCorrectValidationSet()
        {
            Assert.AreEqual(9, validationSet[0].Label);
        }

        [TestMethod]
        public void CorrectTestingSet()
        {
            List<Data> input = new List<Data>()
            {
                new Data(0, null),
                new Data(1, null),
                new Data(2, null),
                new Data(3, null),
            };
            double proportionTraining = 0.0;
            double proportionTesting = 0.75;

            (trainingSet, testingSet, validationSet) = DataSplitter.Split(input, proportionTraining, proportionTesting);

            Assert.AreEqual(3, testingSet.Count);
            Assert.AreEqual(0, testingSet[0].Label);
            Assert.AreEqual(1, testingSet[1].Label);
            Assert.AreEqual(2, testingSet[2].Label);
        }

        [TestMethod]
        public void CorrectValidationSet()
        {
            List<Data> input = new List<Data>()
            {
                new Data(0, null),
                new Data(1, null),
                new Data(2, null),
                new Data(3, null),
            };
            double proportionTraining = 0.0;
            double proportionTesting = 0.25;

            (trainingSet, testingSet, validationSet) = DataSplitter.Split(input, proportionTraining, proportionTesting);

            Assert.AreEqual(3, validationSet.Count);
            Assert.AreEqual(1, validationSet[0].Label);
            Assert.AreEqual(2, validationSet[1].Label);
            Assert.AreEqual(3, validationSet[2].Label);
        }
    }
}
