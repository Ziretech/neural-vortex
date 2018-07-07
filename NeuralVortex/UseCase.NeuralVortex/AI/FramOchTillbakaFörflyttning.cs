using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.AI;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.AI
{
    public class FramOchTillbakaFörflyttning : IRiktningsgenerator
    {
        private bool upp;

        public Spelvärldsposition NästaRiktning => (upp = !upp) ? new Spelvärldsposition(0, 1) : new Spelvärldsposition(0, -1);
    }
}
