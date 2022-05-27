using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ANN_TDD
{
    [TestClass]
    public class NetFactoryTests
    {

        private INet net;
        private const int inputCount = 100;
        private const int outputCount = 10;

        [TestInitialize]
        public void Setup()
        {
            INetFactory factory = new NetFactory();            
            net = factory.CreateNet(inputCount, outputCount, 6);
        }

        [TestMethod]
        public void ShallProvideNetWithCorrectNumberOfInputs()
        {
            float[] input = new float[inputCount];
            float[] output = net.Update(input);
            Assert.AreEqual(outputCount, output.Length);
        }

        [TestMethod]
        public void ShallProvideNetWith3Layers()
        {
            Assert.AreEqual(3, net.Layers.Count);
        }

        [TestMethod]
        public void BackpropagateShallNotCrash()
        {
            var input = Enumerable.Repeat((float)0.0, inputCount).ToArray();
            var correctOutput = Enumerable.Repeat((float)0.0, outputCount).ToArray();

            net.Update(input);
            net.Backpropagate(correctOutput);
        }
    }
}
