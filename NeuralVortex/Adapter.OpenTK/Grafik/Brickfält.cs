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
        private readonly Kamera _kamera;
        private readonly IPositionskonverterare _konverterare;
        private readonly Bricka[] _definitioner;
        private readonly int _kartbredd;
        private readonly int _karthöjd;
        private readonly int[] _karta;
        private readonly Skärmyta _brickstorlek;

        public Brickfält(Bricka[] definitioner, int[] karta, int kartbredd, Skärmyta brickstorlek)
        {
            _definitioner = definitioner;
            _karta = karta;
            _kartbredd = kartbredd;
            _brickstorlek = brickstorlek;
            _karthöjd = karta.Count() / kartbredd;
        }

        public Skärmyta Dimensioner
        {
            get
            {
                return _brickstorlek.MultipliceratMed(new Skärmyta(_kartbredd, _karthöjd));
            }
        }

        public void Visa(Skärmposition position)
        {
            for(var y = 0; y < _karthöjd; y++)
            {
                for (var x = 0; x < _kartbredd; x++)
                {
                    var kartindex = x + y * _kartbredd;
                    var relativPosition = new Skärmposition(x * _brickstorlek.Bredd, y * _brickstorlek.Höjd);
                    _definitioner[_karta[kartindex]].Visa(position.Plus(relativPosition));
                }
            }
        }
    }
}
