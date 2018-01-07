using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public interface IPositionskonverterare
    {
        Skärmposition TillPunkt(Spelvärldsposition position);
        Spelvärldsområde TillOmråde(Skärmområde område);
    }
}
