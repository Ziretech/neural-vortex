using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Kartgenerering
{
    public interface IRumOchDörrarVäljare
    {
        Spelvärldsyta VäljRumstorlek();
        Spelvärldsposition[] VäljDörrpositioner(Spelvärldsområde rumområde);
        Spelvärldsposition VäljRumposition(Spelvärldsyta yta, Spelvärldsposition valdDörrposition);
    }
}
