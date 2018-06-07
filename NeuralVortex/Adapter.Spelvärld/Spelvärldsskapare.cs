using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace Adapter.Spelvärld
{
    public class Spelvärldsskapare : ISpelvärldsskapare
    {
        private Spelvärldsyta _spelvärldsyta;
        private List<Spelvärldsområde> _rum;
        private List<Spelvärldsposition> _dörr;

        public Spelvärldsskapare(Spelvärldsyta spelvärldsyta)
        {
            _spelvärldsyta = spelvärldsyta ?? throw new ArgumentException("Spelvärldsskapare kan inte skapas utan spelvärldsyta.");
            if(_spelvärldsyta.Bredd < 1)
            {
                throw new ArgumentException("Spelvärldsskapares spelvärldsyta måste ha minst 1 i bredd.");
            }
            if(_spelvärldsyta.Höjd < 1)
            {
                throw new ArgumentException("Spelvärldsskapares spelvärldsyta måste ha minst 1 i höjd.");
            }

            _rum = new List<Spelvärldsområde>();
            _dörr = new List<Spelvärldsposition>();
        }

        public void SkapaDörr(Spelvärldsposition position)
        {
            _dörr.Add(position);
        }

        public void SkapaRum(Spelvärldsområde område)
        {
            if (område == null)
                throw new ArgumentException("Rum måste ha ett område.");
            if (område.Botten < 0)
                throw new ArgumentException($"Rum {område.ToString()} måste placeras inom kartan {_spelvärldsyta.ToString()}.");
            _rum.Add(område);
        }

        public bool ÄrKartanFärdig()
        {
            throw new NotImplementedException();
        }

        public int[] ByggKarta()
        {
            var karta = new int[_spelvärldsyta.Bredd * _spelvärldsyta.Höjd];
            foreach(var rum in _rum)
            {
                for (var x = rum.Vänster; x < rum.Höger; x++)
                {
                    for (var y = rum.Botten; y < rum.Topp; y++)
                    {
                        karta[x + y * _spelvärldsyta.Bredd] = 1;
                    }
                }
            }
            foreach(var dörr in _dörr)
            {
                karta[dörr.X + dörr.Y * _spelvärldsyta.Bredd] = 1;
            }
            return karta;
        }
    }
}
