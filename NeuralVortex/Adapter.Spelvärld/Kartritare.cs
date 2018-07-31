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
    public class Kartritare : IKartritare
    {
        private Spelvärldsyta _spelvärldsyta;
        public Karta Karta { get; private set; }

        private const int GOLV_INDEX = 1;
        private const int DÖRR_INDEX = 2;

        public Kartritare(Spelvärldsyta spelvärldsyta)
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

            var index = new int[_spelvärldsyta.Bredd * _spelvärldsyta.Höjd];
            Karta = new Karta(_spelvärldsyta.Bredd, _spelvärldsyta.Höjd, index);
        }

        public void SkapaDörr(Spelvärldsposition position)
        {
            if (position.X >= _spelvärldsyta.Bredd || 
                position.X < 0 ||
                position.Y >= _spelvärldsyta.Höjd ||
                position.Y < 0)
                throw new ArgumentException("Dörr kan inte placeras utanför kartans område.");

            Karta.Indexar[position.X + position.Y * _spelvärldsyta.Bredd] = DÖRR_INDEX;
        }

        public void SkapaYta(Spelvärldsområde område)
        {
            if (område == null)
                throw new ArgumentException("Rum måste ha ett område.");
            if (område.Vänster == område.Höger)
                throw new ArgumentException("Rum måste ha en bredd > 0.");
            if (område.Botten == område.Topp)
                throw new ArgumentException("Rum måste ha en höjd > 0.");
            if (!new Spelvärldsområde(new Spelvärldsposition(0, 0), _spelvärldsyta).Omsluter(område))
                throw new ArgumentException($"Rum {område.ToString()} måste placeras inom kartan {_spelvärldsyta.ToString()}.");

            for (var x = område.Vänster; x < område.Höger; x++)
            {
                for (var y = område.Botten; y < område.Topp; y++)
                {
                    Karta.Indexar[x + y * _spelvärldsyta.Bredd] = GOLV_INDEX;
                }
            }
        }
    }
}
