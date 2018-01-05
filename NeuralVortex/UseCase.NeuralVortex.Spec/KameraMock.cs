using System;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class KameraMock : IKamera
    {
        public Skärmyta ReturneratSynlighetsområde { private get; set; }
        public Skärmposition CentreradMot { get; private set; }

        public void CentreraKameraMot(Skärmposition position)
        {
            CentreradMot = position;
        }

        public Skärmyta Synlighetsområde()
        {
            return ReturneratSynlighetsområde;
        }
    }
}
