using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.AI
{
    public interface IRiktningsgenerator
    {
        Spelvärldsposition NästaRiktning { get; }
    }
}
