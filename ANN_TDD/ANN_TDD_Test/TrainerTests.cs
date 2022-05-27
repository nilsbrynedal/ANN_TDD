using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace ANN_TDD
{
    /// <summary>
    /// Tests for Trainer
    /// </summary>
    [TestClass]
    public class TrainerTests
    {

        [TestMethod]
        public void TrainShallProvideNetWithCorrectData()
        {
            Mock<INet> netMock = new Mock<INet>(MockBehavior.Strict);

            float[] pixles1 = new float[] { (float)1.0, (float)0.1 };
            float[] pixles2 = new float[] { (float)2.0, (float)0.2 };

            List<Data> data = new List<Data>()
            {
                new Data(1, pixles1),
                new Data(2, pixles2),
            };

            float[] correctValues1 = new float[] { (float)-1.0, (float)1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0 };
            float[] correctValues2 = new float[] { (float)-1.0, (float)-1.0, (float)1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0, (float)-1.0 };

            MockSequence sequence = new MockSequence();
            sequence.Cyclic = false;
            netMock.InSequence(sequence).Setup(x => x.Update(pixles1)).Returns(new float[] { (float)0.2 });
            netMock.InSequence(sequence).Setup(x => x.Backpropagate(correctValues1));
            netMock.InSequence(sequence).Setup(x => x.Update(pixles2)).Returns(new float[] { (float)0.2 });
            netMock.InSequence(sequence).Setup(x => x.Backpropagate(correctValues2));

            ITrainer trainer = new Trainer();
            trainer.Train(netMock.Object, data);

            netMock.Verify(x => x.Update(pixles1));
            netMock.Verify(x => x.Backpropagate(correctValues1));
            netMock.Verify(x => x.Update(pixles2));
            netMock.Verify(x => x.Backpropagate(correctValues2));
        }

        //[TestMethod]
        //public void ShallCalculateOutputNeuronsErrorTerms()
        //{
        //    ITrainer trainer = new Trainer();

        //    Mock<ILayer> outputLayerMock = new Mock<ILayer>();


        //    List<Data> data = new List<Data>()
        //    {

        //    };

        //    trainer.Train(data);

        //    outputLayerMock.Verify(x => x.)
        //}
    }
}
