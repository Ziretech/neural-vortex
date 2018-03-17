using System.Collections.Generic;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    public class RumOchDörrarVäljareMock : IRumOchDörrarVäljare
    {
        public Spelvärldsyta[] RumStorlekar { get; set; }
        private int _antalRumstorlekarHämtade = 0;
        public Spelvärldsposition[][] Dörrpositioner { get; set; }
        public Spelvärldsposition[] Rumpositioner { get; set; }

        public Spelvärldsposition[] VäljDörrpositioner(Spelvärldsområde rumområde)
        {
            return Dörrpositioner[0];
        }

        public Spelvärldsposition VäljRumposition(Spelvärldsyta yta, Spelvärldsposition valdDörrposition)
        {
            return Rumpositioner[0];
        }

        public Spelvärldsyta VäljRumstorlek()
        {
            return RumStorlekar[_antalRumstorlekarHämtade++];
        }
    }
}
