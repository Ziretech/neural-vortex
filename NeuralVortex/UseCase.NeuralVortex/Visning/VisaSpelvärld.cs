using Entity.NeuralVortex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Visning
{
    public class VisaSpelvärld
    {
        private ISpelvärld _spelvärld;
        private Kamera _kamera;

        public VisaSpelvärld(ISpelvärld spelvärld, Rektangel ritytansStorlek, Spelvärldsposition ritytansPosition)
        {
            _spelvärld = spelvärld;
            _kamera = new Kamera(ritytansPosition.X, ritytansPosition.Y, ritytansStorlek.Bredd, ritytansStorlek.Höjd);
        }

        public void Visa()
        {
            var huvudkaraktär = _spelvärld.Huvudkaraktär;
            var x = _kamera.BeräknaXPosition(huvudkaraktär.Position.X);
            var y = _kamera.BeräknaYPosition(huvudkaraktär.Position.Y);
            huvudkaraktär.Grafik.Visa(new Skärmposition(x, y));
        }
    }
}
