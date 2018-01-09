using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;

namespace Adapter.Spelvärld
{
    public class Hinderkarta : IHinderkarta
    {
        public Hinderkarta(bool[] hinder, int kartbredd)
        {

        }

        public bool Hindrar(Spelvärldsposition position)
        {
            return false;
        }
    }
}
