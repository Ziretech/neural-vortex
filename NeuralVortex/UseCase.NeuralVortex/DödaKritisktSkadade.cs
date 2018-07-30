using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    internal class DödaKritisktSkadade : IDödaKritisktSkadade
    {
        private ISpelvärld _spelvärld;

        public DödaKritisktSkadade(ISpelvärld spelvärld)
        {
            _spelvärld = spelvärld;
        }

        public SpeletsFortsättning Döda()
        {
            return SpeletsFortsättning.Fortsätt;
        }
    }
}
