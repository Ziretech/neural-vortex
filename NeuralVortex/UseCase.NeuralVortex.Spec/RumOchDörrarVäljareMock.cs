using System.Collections.Generic;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    public class RumOchDörrarVäljareMock : IRumOchDörrarVäljare
    {
        public Spelvärldsyta[] RumStorlekar { get; set; }
        private int _antalRumstorlekarHämtade = 0;
        private int _antalRiktningarHämtade = 0;
        public Spelvärldsposition[][] Dörrpositioner { get; set; }
        public Spelvärldsposition[] Rumpositioner { get; set; }
        public GenereraRumOchDörrar.Riktning[] Riktningar { get; internal set; }
        public int[] Dörrplacering { get; internal set; }

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

        public GenereraRumOchDörrar.Riktning VäljRiktning()
        {
            return Riktningar[_antalRiktningarHämtade++];
        }
    }
}
