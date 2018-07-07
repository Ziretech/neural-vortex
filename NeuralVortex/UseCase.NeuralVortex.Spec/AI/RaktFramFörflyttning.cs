using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.AI;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.AI
{
    public class RaktFramFörflyttning : IRiktningsgenerator
    {
        private readonly Spelvärldsposition _riktning;

        public RaktFramFörflyttning(Spelvärldsposition riktning)
        {
            _riktning = riktning;
        }

        public Spelvärldsposition NästaRiktning => _riktning;
    }
}
