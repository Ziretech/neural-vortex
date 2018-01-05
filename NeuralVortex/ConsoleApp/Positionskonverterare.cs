using System;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace ConsoleApp
{
    internal class Positionskonverterare : IPositionskonverterare
    {
        private readonly Skärmyta _brickyta;

        public Positionskonverterare(Skärmyta brickyta)
        {
            if(brickyta.Bredd < 1)
            {
                throw new ArgumentException($"Bredden för brickyta för positionskonverterare får inte vara mindre än 1 (angiven yta {brickyta.Bredd}x{brickyta.Höjd}).");
            }
            if (brickyta.Höjd < 1)
            {
                throw new ArgumentException($"Höjden för brickyta för positionskonverterare får inte vara mindre än 1 (angiven yta {brickyta.Bredd}x{brickyta.Höjd}).");
            }
            _brickyta = brickyta;
        }

        public Skärmposition TillPunkt(Spelvärldsposition position)
        {
            return new Skärmposition(position.X * _brickyta.Bredd, position.Y * _brickyta.Höjd);
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