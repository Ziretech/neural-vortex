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
        private Skärmyta _skärmyta;

        public Skärmposition PositionCentreradIBotten(Skärmyta dimensioner)
        {
            int x = (_skärmyta.Bredd - dimensioner.Bredd) / 2;
            return new Skärmposition(x, 0);
        }

        public void ÄndraStorlek(Skärmyta skärmyta)
        {
            _skärmyta = skärmyta;
        }
    }
}
