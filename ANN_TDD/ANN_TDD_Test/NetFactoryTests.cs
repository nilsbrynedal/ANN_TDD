using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace ANN_TDD
{
    [TestClass]
    public class NetFactoryTests
    {
        [TestMethod]
        public void ShallProvideNetWithCorrectNumberOfInputs()
        {
            INetFactory factory = new NetFactory();
            const int inputCount = 100;
            const int outputCount = 10;
            INet net = factory.CreateNet(inputCount, outputCount, 6);

            float[] input = new float[inputCount];
            float[] output = net.Update(input);

            Assert.AreEqual(outputCount, output.Length);
        }

        [TestMethod]
        public void ShallProvideNetWith3Layers()
        {
            INetFactory factory = new NetFactory();
            const int inputCount = 100;
            const int outputCount = 10;
            INet net = factory.CreateNet(inputCount, outputCount, 6);

            Assert.AreEqual(3, net.Layers.Count);
        }
    }
}
