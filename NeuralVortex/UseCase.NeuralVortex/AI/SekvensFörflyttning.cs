using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.AI
{
    public class SekvensFörflyttning : IRiktningsgenerator
    {
        public Spelvärldsposition NästaRiktning => new Spelvärldsposition(1, 0);
    }
}
