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
        private Skärmposition _kameraPosition;

        public Skärmposition Position => _kameraPosition;
        public Skärmområde Synlighetsområde { get; }
        public Skärmyta Dimensioner { get; set; }

        public Kamera(Skärmyta dimensioner, Skärmposition skärmposition = null)
        {
            if(dimensioner.Bredd < 1)
            {
                throw new ArgumentException($"Kamerans bredd på skärmytan kan inte vara mindre än 1 (skärmytans dimensioner: {dimensioner.Bredd}x{dimensioner.Höjd}).");
            }
            if (dimensioner.Höjd < 1)
            {
                throw new ArgumentException($"Kamerans höjd på skärmytan kan inte vara mindre än 1 (skärmytans dimensioner: {dimensioner.Bredd}x{dimensioner.Höjd}).");
            }
            Dimensioner = dimensioner;
            _kameraPosition = skärmposition ?? new Skärmposition(0, 0);
        }

        public void CentreraKameraMot(Skärmposition position)
        {
            _kameraPosition = new Skärmposition(position.X - Dimensioner.Bredd / 2, position.Y - Dimensioner.Höjd / 2);
        }

        public Skärmposition Transformera(Skärmposition skärmposition)
        {
            return skärmposition.Minus(_kameraPosition);
        }
    }
}
