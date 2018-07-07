using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace Adapter.Spelvärld
{
    public class Spelvärld : ISpelvärld
    {
        public Huvudkaraktär Huvudkaraktär { get; set; }
        public IGrafik MiljöGrafik { get; set; }
        public IEnumerable<Fiende> Fienden { get; set; }
        public Spelvärldsposition KameraPosition { get; set; }

        public Spelvärld()
        {
            KameraPosition = new Spelvärldsposition(0, 0);
            Fienden = new List<Fiende>();
        }
    }
}
