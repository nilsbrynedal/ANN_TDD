using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ANN_TDD
{
    [TestClass]
    public class OutputLayerTests
    {
        private const int numberOfNeurons = 10;

        [TestMethod]
        public void BackpropagateShallUpdateErrorTermOnEachNeuron()
        {
            // given 
            List<Mock<IOutputNeuron>> mocks = new List<Mock<IOutputNeuron>>();
            for(int i = 0; i < numberOfNeurons; i++)
            {
                mocks.Add(new Mock<IOutputNeuron>());
            }

            List<IOutputNeuron> neurons = mocks.Select(x => x.Object).ToList();
            IOutputLayer layer = new OutputLayer(neurons);

            // when
            float[] correctOutput = new float[]
            {
                (float)0.0, (float)1.0, (float)2.0, (float)3.0, (float)4.0, (float)5.0, (float)6.0, (float)7.0, (float)8.0, (float)9.0
            };
            layer.Backpropagate(correctOutput);

            // then
            for (int i = 0; i < 10; i++)
            {
                mocks[i].Verify(x => x.UpdateErrorTerm(correctOutput[i]));
            }
        }

        [DataTestMethod]
        [DataRow(numberOfNeurons + 1)]
        [DataRow(numberOfNeurons - 1)]
        public void BackpropagateShallCrashGivenWrongNumberOfInputs(int inputCount)
        {
            // given 
            List<Mock<IOutputNeuron>> mocks = new List<Mock<IOutputNeuron>>();
            for (int i = 0; i < 10; i++)
            {
                mocks.Add(new Mock<IOutputNeuron>());
            }

            List<IOutputNeuron> neurons = mocks.Select(x => x.Object).ToList();
            IOutputLayer layer = new OutputLayer(neurons);

            float[] correctOutput = Enumerable.Repeat((float)-1.0, inputCount).ToArray();

            // when then
            Assert.ThrowsException<ArgumentException>(() => layer.Backpropagate(correctOutput));
        }
    }
}
