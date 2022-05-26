using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace ANN_TDD
{
    [TestClass]
    public class NetTests
    {

        [TestMethod]
        public void UpdateShallUpdateFirstLayer()
        {
            Mock<ILayer> firstLayerMock = new Mock<ILayer>();
            
            List<ILayer> layers = new List<ILayer>()
            {
                firstLayerMock.Object
            };
            INet net = new Net(layers);

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

            Mock<ILayer> firstLayerMock = new Mock<ILayer>();
            Mock<ILayer> secondLayerMock = new Mock<ILayer>();

            firstLayerMock.Setup(x => x.Update(input)).Returns(firstLayerOutput);

            List<ILayer> layers = new List<ILayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object
            };
            INet net = new Net(layers);
                        
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

            Mock<ILayer> firstLayerMock = new Mock<ILayer>();
            Mock<ILayer> secondLayerMock = new Mock<ILayer>();
            Mock<ILayer> thirdLayerMock = new Mock<ILayer>();

            firstLayerMock.Setup(x => x.Update(input)).Returns(firstLayerOutput);
            secondLayerMock.Setup(x => x.Update(firstLayerOutput)).Returns(secondLayerOutput);

            List<ILayer> layers = new List<ILayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object,
                thirdLayerMock.Object
            };
            INet net = new Net(layers);

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

            Mock<ILayer> firstLayerMock = new Mock<ILayer>();
            Mock<ILayer> secondLayerMock = new Mock<ILayer>();
            Mock<ILayer> thirdLayerMock = new Mock<ILayer>();

            firstLayerMock.Setup(x => x.Update(input)).Returns(firstLayerOutput);
            secondLayerMock.Setup(x => x.Update(firstLayerOutput)).Returns(secondLayerOutput);
            thirdLayerMock.Setup(x => x.Update(secondLayerOutput)).Returns(thirdLayerOutput);

            List<ILayer> layers = new List<ILayer>()
            {
                firstLayerMock.Object,
                secondLayerMock.Object,
                thirdLayerMock.Object
            };
            INet net = new Net(layers);

            // when
            var output = net.Update(input);

            // then
            Assert.AreEqual(thirdLayerOutput, output);
        }
    }
}
