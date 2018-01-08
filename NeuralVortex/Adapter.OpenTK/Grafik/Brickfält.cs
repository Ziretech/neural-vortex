using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Grafik
{
    public class Brickfält : IGrafik
    {
        private readonly IGrafikkommandon _gl;
        private readonly Kamera _kamera;
        private readonly IPositionskonverterare _konverterare;
        private readonly Bricka[] _definitioner;
        private readonly int _kartbredd;
        private readonly int _karthöjd;
        private readonly int[] _karta;

        public Brickfält(IGrafikkommandon grafikkommandon, Kamera kamera, IPositionskonverterare konverterare, Bricka[] definitioner, int kartbredd, int[] karta)
        {
            _gl = grafikkommandon;
            _kamera = kamera;
            _definitioner = definitioner;
            _kartbredd = kartbredd;
            _karta = karta;
            _karthöjd = karta.Count() / kartbredd;
            _konverterare = konverterare;
        }

        public void Visa(Skärmposition position)
        {
            var område = _konverterare.TillOmråde(_kamera.Synlighetsområde);

            for(var y = område.Botten; y <= Math.Min(område.Topp, _karthöjd - 1); y++)
            {
                for (var x = område.Vänster; x <= Math.Min(område.Höger, _kartbredd - 1); x++)
                {
                    var kartindex = x + y * _kartbredd;
                    _definitioner[_karta[kartindex]].Visa(_konverterare.TillPunkt(new Spelvärldsposition(x, y)));
                }
            }
        }
    }
}
