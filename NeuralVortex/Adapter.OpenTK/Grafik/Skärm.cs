using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Grafik
{
    public class Skärm : ISkärm
    {
        public Skärmposition PositionCentreradIBotten(Skärmyta dimensioner)
        {
            return new Skärmposition(0, 0);
        }
    }
}
