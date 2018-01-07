using System;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    internal class PositionskonverterareMock : IPositionskonverterare
    {
        public Skärmposition TillPunkt(Spelvärldsposition position)
        {
            return new Skärmposition(position.X, position.Y);
        }

        public Spelvärldsyta TillYta(Skärmyta yta)
        {
            throw new NotImplementedException();
        }
    }
}
