using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ANN_TDD
{
    [TestClass]
    public class BackpropagationTest
    {
        /// <summary>
        /// Tests that given the same inputs, repeated backpropagation should get 
        /// the output closer and closer to the desired output.
        /// TODO This test must be made harder. Right now it is enough that the output 
        /// layer is learning to pass the test.
        /// </summary>
        [TestMethod]
        public void ShallImproveResult()
        {
            // given
            INetFactory factory = new NetFactory();
            INet net = factory.CreateNet(3, 2, 3);

            float[] correctOutput = new float[] { (float)1.0, (float) - 1.0 };
            float[] inputs = new float[] { (float)-0.1, (float)0.21, (float)0.0 };

            // when
            float previousError = CalculateError(correctOutput, net.Update(inputs));

            for (int i = 0; i < 100; i++)
            {
                net.Backpropagate(correctOutput);
                
                float newError = CalculateError(correctOutput, net.Update(inputs));

                // then
                Assert.IsTrue(newError < previousError); // the error shall always improve

                previousError = newError;
            }
        }

        private static float CalculateError(float[] correctOutput, float[] output)
        {
            float previousError = 0;
            for (int j = 0; j < output.Length; j++)
            {
                previousError += Math.Abs(output[j] - correctOutput[j]);
            }

            return previousError;
        }
    }
}
