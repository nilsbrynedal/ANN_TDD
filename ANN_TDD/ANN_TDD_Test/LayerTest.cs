using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace ANN_TDD
{
    [TestClass]
    public class LayerTest
    {
        [TestMethod]
        public void UpdateShallUpdateAllNeurons()
        {
            // given
            List<Mock<INeuron>> mocks = new List<Mock<INeuron>>()
            {
                new Mock<INeuron>(),
                new Mock<INeuron>(),
                new Mock<INeuron>(),
                new Mock<INeuron>()
            };

            List<INeuron> neurons = mocks.Select(x => x.Object).ToList();

            float[] data = { 1, 4, 76 };

            ILayer layer = new Layer(neurons);

            // when
            layer.Update(data);

            // then
            mocks.ForEach(mock => mock.Verify(neuron => neuron.Update(data)));
        }

        [TestMethod]
        public void UpdateShallOutputNeuronsOutputs()
        {
            // given
            float[] inputs = { 1, 4, 76 };
            float[] expected = { 3, 4, 6, 9 };
            List<Mock<INeuron>> mocks = new List<Mock<INeuron>>()
            {
                new Mock<INeuron>(),
                new Mock<INeuron>(),
                new Mock<INeuron>(),
                new Mock<INeuron>()
            };

            for(int i = 0; i < mocks.Count; i++)
            {
                mocks[i].Setup(x => x.Update(inputs)).Returns(expected[i]);
            }

            List<INeuron> neurons = mocks.Select(x => x.Object).ToList();
            ILayer layer = new Layer(neurons);

            // when
            var output = layer.Update(inputs);

            // then
            CollectionAssert.AreEqual(expected, output);
        }
    }
}
