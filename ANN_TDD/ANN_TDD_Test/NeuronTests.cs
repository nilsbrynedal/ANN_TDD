using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANN_TDD
{
    /// <summary>
    /// Summary description for NeuronTests
    /// </summary>
    [TestClass]
    public class NeuronTests
    {

        [TestMethod]
        public void ShallHaveWeights()
        {
            float[] weights = new float[] { 1, 1, (float)0.3};
            INeuron neuron = new Neuron(weights);
        }

        [TestMethod]
        public void ShallUpdateWithCorrectNumberOfInputs()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights);
            neuron.Update(new float[] { 1, 0  });
        }

        [TestMethod]
        public void UpdateShallCrashWithTooManyInputs()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights);
            Assert.ThrowsException<ArgumentException>(() => { neuron.Update(new float[] { 1, 0, 1 }); });
        }

        [TestMethod]
        public void UpdateShallCrashWithTooFewInputs()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights);
            Assert.ThrowsException<ArgumentException>(() => { neuron.Update(new float[] { 1 }); });
        }

        [TestMethod]
        public void UpdateShallCalculateOutput()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights);
            var output = neuron.Update(new float[] { 1, (float)0.5 });
            Assert.AreEqual((float)0.8, output);
        }
    }
}
