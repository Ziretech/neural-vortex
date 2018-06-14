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
    public class RumOchDörrarVäljare : IRumOchDörrarVäljare
    {
        public Spelvärldsposition[] VäljDörrpositioner(Spelvärldsområde rumområde)
        {
            throw new NotImplementedException();
        }

        public Spelvärldsposition VäljRumposition(Spelvärldsyta yta, Spelvärldsposition valdDörrposition)
        {
            throw new NotImplementedException();
        }

        public Spelvärldsyta VäljRumstorlek()
        {
            return new Spelvärldsyta(5, 5);
        }
    }
}
