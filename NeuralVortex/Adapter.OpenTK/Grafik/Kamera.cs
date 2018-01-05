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
        public Skärmyta Synlighetsområde { get; set; }

        public Kamera(Skärmyta skärmyta, Skärmposition skärmposition = null)
        {
            if(skärmyta.Bredd < 1)
            {
                throw new ArgumentException($"Kamerans bredd på skärmytan kan inte vara mindre än 1 (skärmytans dimensioner: {skärmyta.Bredd}x{skärmyta.Höjd}).");
            }
            if (skärmyta.Höjd < 1)
            {
                throw new ArgumentException($"Kamerans höjd på skärmytan kan inte vara mindre än 1 (skärmytans dimensioner: {skärmyta.Bredd}x{skärmyta.Höjd}).");
            }
            Synlighetsområde = skärmyta;
            _kameraPosition = skärmposition ?? new Skärmposition(0, 0);
        }

        public void CentreraKameraMot(Skärmposition position)
        {
            _kameraPosition = new Skärmposition(position.X - Synlighetsområde.Bredd / 2, position.Y - Synlighetsområde.Höjd / 2);
        }

        public Skärmposition Transformera(Skärmposition skärmposition)
        {
            return skärmposition.Minus(_kameraPosition);
        }
    }
}
