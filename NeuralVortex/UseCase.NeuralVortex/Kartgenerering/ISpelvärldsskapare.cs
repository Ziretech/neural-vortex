using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Kartgenerering
{
    public interface ISpelvärldsskapare
    {
        void SkapaRum(Spelvärldsområde område);
        void SkapaDörr(Spelvärldsposition position);
    }
}
