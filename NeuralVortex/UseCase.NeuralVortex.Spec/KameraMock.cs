using System;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class KameraMock : IKamera
    {
        public Skärmposition CentreradMot { get; private set; }

        public Skärmområde Synlighetsområde => throw new NotImplementedException();

        public void CentreraKameraMot(Skärmposition position)
        {
            CentreradMot = position;
        }
    }
}
