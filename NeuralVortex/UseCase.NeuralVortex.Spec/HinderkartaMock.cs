using System.Linq;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    public class HinderkartaMock : IHinderkarta
    {
        private readonly Spelvärldsposition[] _hinder;

        public HinderkartaMock(Spelvärldsposition[] hinder)
        {
            _hinder = hinder;
        }

        public bool Hindrar(Spelvärldsposition position)
        {
            return _hinder.Any(h => h.Equals(position));
        }

        // REFACTOR Använd NSubstitute istället
    }
}
