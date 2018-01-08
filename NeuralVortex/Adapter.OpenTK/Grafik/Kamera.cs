using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Grafik
{
    public class Kamera : IKamera
    {
        public Skärmposition Position { get; private set; }
        public Skärmområde Synlighetsområde
        {
            get
            {
                return new Skärmområde(Position.X, Position.Y, Position.X + _dimensioner.Bredd - 1, Position.Y + _dimensioner.Höjd - 1);
            }
        }

        private Skärmyta _dimensioner;
        public Skärmyta Dimensioner
        {
            get
            {
                return _dimensioner;
            }
            set
            {
                ValideraDimensioner(value);
                _dimensioner = value;
            }
        }

        public Kamera(Skärmyta dimensioner, Skärmposition skärmposition = null)
        {
            ValideraDimensioner(dimensioner);
            Dimensioner = dimensioner;
            Position = skärmposition ?? new Skärmposition(0, 0);
        }

        public void CentreraKameraMot(Skärmposition position)
        {
            Position = new Skärmposition(position.X - Dimensioner.Bredd / 2, position.Y - Dimensioner.Höjd / 2);
        }

        public Skärmposition Transformera(Skärmposition skärmposition)
        {
            return skärmposition.Minus(Position);
        }

        private void ValideraDimensioner(Skärmyta dimensioner)
        {
            if (dimensioner.Bredd < 1)
            {
                throw new ArgumentException($"Kamerans bredd på skärmytan kan inte vara mindre än 1 (skärmytans dimensioner: {dimensioner.Bredd}x{dimensioner.Höjd}).");
            }
            if (dimensioner.Höjd < 1)
            {
                throw new ArgumentException($"Kamerans höjd på skärmytan kan inte vara mindre än 1 (skärmytans dimensioner: {dimensioner.Bredd}x{dimensioner.Höjd}).");
            }
        }
    }
}
