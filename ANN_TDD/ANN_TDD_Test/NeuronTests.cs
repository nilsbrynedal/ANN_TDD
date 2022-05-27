using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ANN_TDD
{
    /// <summary>
    /// Test of Neuron
    /// </summary>
    [TestClass]
    public class NeuronTests
    {

        /// <summary>
        /// Activation function for testing.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private float OneToOne(float input) => input;

        [TestMethod]
        public void ShallUpdateWithCorrectNumberOfInputs()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights, OneToOne);
            neuron.Update(new float[] { 1, 0  });
        }

        [TestMethod]
        public void UpdateShallCrashWithTooManyInputs()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights, OneToOne);
            Assert.ThrowsException<ArgumentException>(() => { neuron.Update(new float[] { 1, 0, 1 }); });
        }

        [TestMethod]
        public void UpdateShallCrashWithTooFewInputs()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights, OneToOne);
            Assert.ThrowsException<ArgumentException>(() => { neuron.Update(new float[] { 1 }); });
        }

        [TestMethod]
        public void UpdateShallCalculateActivation()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights, OneToOne);
            var output = neuron.Update(new float[] { 1, (float)0.5 });
            Assert.AreEqual((float)0.8, output);
        }

        private float Sigmoid(float input) => (float)(Math.Exp(input) / (Math.Exp(input) + 1));

        [TestMethod]
        public void UpdateShallUseActivationFunction()
        {
            float[] weights = new float[] { 1, -1, (float)0.3 };
            INeuron neuron = new Neuron(weights, Sigmoid);
            var output = neuron.Update(new float[] { 1, (float)0.5 });

            var expected = Sigmoid((float)0.8);

            Assert.AreEqual(expected, output);
        }


    }
}
