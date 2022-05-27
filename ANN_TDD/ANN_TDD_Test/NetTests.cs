using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace ANN_TDD
{
    [TestClass]
    public class NetTests
    {

        [TestMethod]
        public void UpdateShallUpdateFirstLayer()
        {
            Mock<IOutputLayer> firstLayerMock = new Mock<IOutputLayer>();
            
            List<IHiddenLayer> layers = new List<IHiddenLayer>();

            INet net = new Net(layers, firstLayerMock.Object);

            float[] input = { 1, 2, 3 };

            net.Update(input);

            firstLayerMock.Verify(x => x.Update(input));
        }

        [TestMethod]
        public void UpdateShallUpdateSecondLayer()
        {
            // Given
            float[] input = { 1, 2, 3 };
            float[] firstLayerOutput = { 2, 4, 5 };

            Mock<IHiddenLayer> firstLayerMock = new Mock<IHiddenLayer>();
            Mock<IOutputLayer> secondLayerMock = new Mock<IOutputLayer>();

            firstLayerMock.Setup(x => x.Update(input)).Returns(firstLayerOutput);

            List<IHiddenLayer> layers = new List<IHiddenLayer>()
            {
                firstLayerMock.Object
                
            };
            INet net = new Net(layers, secondLayerMock.Object);
                        
            // when
            net.Update(input);

            // then
            secondLayerMock.Verify(x => x.Update(firstLayerOutput));
        }

        [TestMethod]
        public void UpdateShallUpdateThirdLayer()
        {
            // Given
            float[] input = { 1, 2, 3 };
            float[] firstLayerOutput = { 2, 4, 5 };
            float[] secondLayerOutput = { 3, 8, 9, 6 };

            Mock<IHiddenLayer> firstLayerMock = new Mock<IHiddenLayer>();
            Mock<IHiddenLayer> secondLayerMock = new Mock<IHiddenLayer>();
            Mock<IOutputLayer> thirdLayerMock = new Mock<IOutputLayer>();

            firstLayerMock.Setup(x => x.Update(input)).Returns(firstLayerOutput);
            secondLayerMock.Setup(x => x.Update(firstLayerOutput)).Returns(secondLayerOutput);

            List<IHiddenLayer> layers = new List<IHiddenLayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object                
            };
            INet net = new Net(layers, thirdLayerMock.Object);

            // when
            net.Update(input);

            // then
            thirdLayerMock.Verify(x => x.Update(secondLayerOutput));
        }

        [TestMethod]
        public void UpdateShallReturnLastLayersOutput()
        {
            // Given
            float[] input = { 1, 2, 3 };
            float[] firstLayerOutput = { 2, 4, 5 };
            float[] secondLayerOutput = { 3, 8, 9, 6 };
            float[] thirdLayerOutput = { 3, 7, 9, 1 };

            Mock<IHiddenLayer> firstLayerMock = new Mock<IHiddenLayer>();
            Mock<IHiddenLayer> secondLayerMock = new Mock<IHiddenLayer>();
            Mock<IOutputLayer> thirdLayerMock = new Mock<IOutputLayer>();

            firstLayerMock.Setup(x => x.Update(input)).Returns(firstLayerOutput);
            secondLayerMock.Setup(x => x.Update(firstLayerOutput)).Returns(secondLayerOutput);
            thirdLayerMock.Setup(x => x.Update(secondLayerOutput)).Returns(thirdLayerOutput);

            List<IHiddenLayer> layers = new List<IHiddenLayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object
            };
            INet net = new Net(layers, thirdLayerMock.Object);

            // when
            var output = net.Update(input);

            // then
            Assert.AreEqual(thirdLayerOutput, output);
        }

        [TestMethod]
        public void BackpropagateShallBackpropagateToOutputLayer()
        {
            // Given
            float[] input = { 1, 2, 3 };
            float[] correctValues = Enumerable.Repeat((float)-1.0, 10).ToArray();
            correctValues[1] = (float)1.0;

            Mock<IHiddenLayer> firstLayerMock = new Mock<IHiddenLayer>();
            Mock<IHiddenLayer> secondLayerMock = new Mock<IHiddenLayer>();
            Mock<IOutputLayer> thirdLayerMock = new Mock<IOutputLayer>();

            List<IHiddenLayer> hiddenLayers = new List<IHiddenLayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object
            };
            INet net = new Net(hiddenLayers, thirdLayerMock.Object);

            // when
            net.Update(input);
            net.Backpropagate(correctValues);

            // then
            thirdLayerMock.Verify(x => x.Backpropagate(correctValues));
        }

        [TestMethod]
        public void BackpropagateShallBackpropagateToAllHiddenLayers()
        {
            // Given
            float[] input = { 1, 2, 3 };
            float[] correctValues = Enumerable.Repeat((float)-1.0, 10).ToArray();
            correctValues[1] = (float)1.0;

            Mock<IHiddenLayer> firstLayerMock = new Mock<IHiddenLayer>();
            Mock<IHiddenLayer> secondLayerMock = new Mock<IHiddenLayer>();
            Mock<IOutputLayer> thirdLayerMock = new Mock<IOutputLayer>();

            List<IHiddenLayer> hiddenLayers = new List<IHiddenLayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object
            };
            INet net = new Net(hiddenLayers, thirdLayerMock.Object);

            // when
            net.Update(input);
            net.Backpropagate(correctValues);

            // then
            secondLayerMock.Verify(x => x.Backpropagate(thirdLayerMock.Object));
            firstLayerMock.Verify(x => x.Backpropagate(secondLayerMock.Object));
        }
    }
}
