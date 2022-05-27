using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ANN_TDD
{
    [TestClass]
    public class IdentifierTests
    {
        [DataTestMethod]
        [DataRow(1, new float[] { (float)0.12, (float)0.9, (float)0.123, (float)0.221, (float)0.341, (float)0.21, (float)0.13, (float)0.22, (float)0.31, (float)-0.8 })]
        [DataRow(2, new float[] { (float)0.12, (float)0.1, (float)0.923, (float)0.221, (float)0.341, (float)0.21, (float)0.13, (float)0.22, (float)0.31, (float)-0.8 })]
        public void ShallIdentifyNumber(int correctLabel, float[] netOutput)
        {
            // the only relevant thing is that the output (from the net), relating to the correct number, is the highest

            // given
            float[] pixels = new float[] { 1, 34, 1 }; // the actual pixels are not relevant for this test

            Mock<INet> mockNet = new Mock<INet>();
            mockNet.Setup(x => x.Update(pixels)).Returns(netOutput);

            IIdentifier identifier = new Identifier(mockNet.Object);

            // when
            int actual = identifier.Identify(pixels);

            // then
            Assert.AreEqual(correctLabel, actual);
        }
    }
}
