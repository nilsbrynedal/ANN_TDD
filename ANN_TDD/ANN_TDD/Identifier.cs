using System.Linq;

namespace ANN_TDD
{
    public class Identifier : IIdentifier
    {
        private readonly INet net;

        public Identifier(INet net)
        {
            this.net = net;
        }

        public int Identify(float[] pixles)
        {
            var output = net.Update(pixles).ToList();
            return output.IndexOf(output.Max());
        }
    }
}