using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spelvärld
{
    public interface ISpelvärld
    {
        Huvudkaraktär Huvudkaraktär { get; set; }

        IGrafik MiljöGrafik { get; set; }

        IEnumerable<Fiende> Fienden { get; set; }
    }
}
