using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace ConsoleApp
{
    internal class Positionskonverterare : IPositionskonverterare
    {
        private readonly int _brickbredd;
        private readonly int _brickhöjd;

        public Positionskonverterare(int brickbredd, int brickhöjd)
        {
            _brickbredd = brickbredd;
            _brickhöjd = brickhöjd;
        }

        public Skärmposition TillPunkt(Spelvärldsposition position)
        {
            throw new System.NotImplementedException();
        }

        public Skärmyta TillYta(Spelvärldsposition position)
        {
            throw new System.NotImplementedException();
        }

        public Spelvärldsyta TillYta(Skärmyta yta)
        {
            throw new System.NotImplementedException();
        }
    }
}