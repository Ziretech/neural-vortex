using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Kontroll
{
    public interface IHinderkarta
    {
        bool Hindrar(Spelvärldsposition position);
    }
}
