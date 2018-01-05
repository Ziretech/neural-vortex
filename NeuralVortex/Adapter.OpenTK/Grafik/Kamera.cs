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
        private Skärmyta _skärmyta;

        public Skärmposition Position => _kameraPosition;

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
            _skärmyta = skärmyta;
            _kameraPosition = skärmposition ?? new Skärmposition(0, 0);
        }

        public void CentreraKameraMot(Skärmposition position)
        {
            _kameraPosition = new Skärmposition(position.X - _skärmyta.Bredd / 2, position.Y - _skärmyta.Höjd / 2);
        }

        public Skärmyta Synlighetsområde()
        {
            throw new NotImplementedException();
        }

        internal void ÄndraStorlekPåSynlighetsområde(int bredd, int höjd)
        {
            throw new NotImplementedException();
        }

        public Skärmposition Transformera(Skärmposition skärmposition)
        {
            return skärmposition.Minus(_kameraPosition);
        }
    }
}
