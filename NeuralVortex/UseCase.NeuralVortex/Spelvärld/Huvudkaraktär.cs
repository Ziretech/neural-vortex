using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class Huvudkaraktär
    {
        public IGrafik Grafik { get; set; }

        public Spelvärldsposition Position { get; set; }
    }
}
