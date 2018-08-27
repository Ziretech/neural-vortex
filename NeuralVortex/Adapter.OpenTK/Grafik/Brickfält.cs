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
        private readonly int[] _karta;
        private readonly Skärmyta _brickstorlek;
        private readonly Skärmyta _kartstorlek;

        public Brickfält(Bricka[] definitioner, int[] karta, int kartbredd, Skärmyta brickstorlek)
        {
            _definitioner = definitioner;
            _karta = karta;
            _brickstorlek = brickstorlek;
            _kartstorlek = new Skärmyta(kartbredd, karta.Count() / kartbredd);
        }

        public Skärmyta Dimensioner
        {
            get
            {
                return _brickstorlek.MultipliceratMed(_kartstorlek);
            }
        }

        public void Visa(Skärmposition position)
        {
            for(var y = 0; y < _kartstorlek.Höjd; y++)
            {
                for (var x = 0; x < _kartstorlek.Bredd; x++)
                {
                    var kartindex = x + y * _kartstorlek.Bredd;
                    var relativPosition = new Skärmposition(x * _brickstorlek.Bredd, y * _brickstorlek.Höjd);
                    _definitioner[_karta[kartindex]].Visa(position.Plus(relativPosition));
                }
            }
        }
    }
}
