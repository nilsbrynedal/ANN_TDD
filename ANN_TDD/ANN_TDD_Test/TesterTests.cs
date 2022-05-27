using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ANN_TDD
{
    [TestClass]
    public class TesterTests
    {
        [TestMethod]
        public void ShallRunTestCorrectly()
        {
            ITester tester = new Tester();

            float[] input1 = new float[] { (float)1.0, (float)1.2};
            float[] input2 = new float[] { (float)2.0, (float)1.2 };
            float[] input3 = new float[] { (float)3.0, (float)1.2 };

            List<Data> data = new List<Data>()
            {
                new Data(1, input1),
                new Data(2, input2),
                new Data(3, input3)
            };

            // given an identifier that answers correctly 2 out of 3 tries
            Mock<IIdentifier> mock = new Mock<IIdentifier>();
            mock.Setup(x => x.Identify(input1)).Returns(1); // in this case the identifier aswers correcly
            mock.Setup(x => x.Identify(input2)).Returns(2); // in this case the identifier aswers correcly
            mock.Setup(x => x.Identify(input3)).Returns(4); // in this case the identifier aswers wrong

            // when testing it
            float result = tester.Test(mock.Object, data);

            // then we expect 2/3 as result
            Assert.AreEqual(2.0 / 3.0, result, 0.01);
        }

        [TestMethod]
        public void ShallRunTestCorrectly2()
        {
            ITester tester = new Tester();

            float[] input1 = new float[] { (float)1.0, (float)1.2 };
            float[] input2 = new float[] { (float)2.0, (float)1.2 };
            float[] input3 = new float[] { (float)3.0, (float)1.2 };

            List<Data> data = new List<Data>()
            {
                new Data(1, input1),
                new Data(2, input2),
                new Data(3, input3)
            };

            // given an identifier that answers correctly 2 out of 3 tries
            Mock<IIdentifier> mock = new Mock<IIdentifier>();
            mock.Setup(x => x.Identify(input1)).Returns(9); // in this case the identifier aswers wrong
            mock.Setup(x => x.Identify(input2)).Returns(2); // in this case the identifier aswers correcly
            mock.Setup(x => x.Identify(input3)).Returns(4); // in this case the identifier aswers wrong

            // when testing it
            float result = tester.Test(mock.Object, data);

            // then we expect 2/3 as result
            Assert.AreEqual(1.0 / 3.0, result, 0.01);
        }
    }
}
