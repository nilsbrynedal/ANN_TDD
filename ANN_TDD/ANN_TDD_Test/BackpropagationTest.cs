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
        /// This test is not so hard. Right now it is enough that the output 
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


        [TestMethod]
        public void ShallHandleXOr()
        {
            // given
            INetFactory factory = new NetFactory();
            INet net = factory.CreateNet(2, 1, 2, (float)0.1);

            // when
            float previousError = float.MaxValue;

            for (int i = 0; i < 100; i++)
            {
                float currentError = 0;

                currentError += Run(new float[] { (float)1.0, (float)0.0 }, new float[] { (float)1.0 }, net);
                currentError += Run(new float[] { (float)0.0, (float)1.0 }, new float[] { (float)1.0 }, net);

                currentError += Run(new float[] { (float)1.0, (float)1.0 }, new float[] { (float)0.0 }, net);
                currentError += Run(new float[] { (float)0.0, (float)0.0 }, new float[] { (float)0.0 }, net);

                // then
                Assert.IsTrue(previousError > currentError);
                previousError = currentError;
            }
        }

        /// <summary>
        /// Runs backpropagation
        /// </summary>
        /// <param name="input"></param>
        /// <param name="correctOutput"></param>
        /// <param name="net"></param>
        /// <returns>The error of the net</returns>
        private float Run(float[] input, float[] correctOutput, INet net)
        {
            float error = CalculateError(correctOutput, net.Update(input));
            net.Backpropagate(correctOutput);
            return error;
        }
    }
}
