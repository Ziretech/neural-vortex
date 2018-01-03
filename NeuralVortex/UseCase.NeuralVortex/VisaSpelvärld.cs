using Entity.NeuralVortex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class VisaSpelvärld
    {
        private readonly ISpelvärld _spelvärld;
        private readonly Rektangel _brickstorlek;

        public VisaSpelvärld(ISpelvärld spelvärld, Rektangel brickstorlek)
        {
            _spelvärld = spelvärld;
            _brickstorlek = brickstorlek;
        }

        public void Visa(Rektangel ritytansStorlek)
        {
            var ritytansPosition = _spelvärld.KameraPosition;
            var kamera = new Kamera(ritytansPosition.X, ritytansPosition.Y, ritytansStorlek.Bredd, ritytansStorlek.Höjd, _brickstorlek.Bredd, _brickstorlek.Höjd);

            var huvudkaraktär = _spelvärld.Huvudkaraktär;
            if (huvudkaraktär != null)
            {
                var x = kamera.BeräknaXPosition(huvudkaraktär.Position.X);
                var y = kamera.BeräknaYPosition(huvudkaraktär.Position.Y);
                huvudkaraktär.Grafik.Visa(new Skärmposition(x, y));
            }

            var miljögrafik = _spelvärld.MiljöGrafik;
            if(miljögrafik != null)
            {
                var yta = new Yta(kamera.Topp, kamera.Botten, kamera.Vänster, kamera.Höger);
                miljögrafik.Visa(yta);
            }

            var fienden = _spelvärld.Fienden;
            if(fienden != null)
            {
                foreach(var fiende in fienden)
                {
                    fiende.Grafik.Visa(new Skärmposition(
                        kamera.BeräknaXPosition(fiende.Position.X), 
                        kamera.BeräknaYPosition(fiende.Position.Y)));
                }
            }
        }
    }
}
