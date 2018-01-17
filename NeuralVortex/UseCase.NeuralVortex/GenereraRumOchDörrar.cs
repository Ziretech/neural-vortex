using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class GenereraRumOchDörrar
    {
        private ISpelvärldsskapare _skapare;

        public GenereraRumOchDörrar(ISpelvärldsskapare skapare)
        {
            _skapare = skapare;
        }

        public void Generera()
        {
        }
    }
}
