using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ANN_TDD
{
    [TestClass]
    public class OutputNeuronTests
    {
        [TestMethod]
        public void BackpropagationShallContinouslyImproveAccuracy()
        {
            float newError = 0;

            // given
            const float correctValue = 1;

            float[] weights = new float[] { (float)0.1, (float)0.11, (float)-0.2 };
            float[] inputs = new float[] { (float)-0.1, (float)0.21 };

            IOutputNeuron neuron = new OutputNeuron(weights, NetFactory.Sigmoid, NetFactory.DerivativeOfSigmoid, (float)0.4);

            for (int i = 0; i < 100; i++)
            {
                // when
                var previousError = neuron.Update(inputs) - correctValue;
                neuron.UpdateErrorTerm(correctValue);
                newError = neuron.Update(inputs) - correctValue;

                // then
                Assert.IsTrue(Math.Abs(newError) < Math.Abs(previousError));
            }
        }

    }
}
