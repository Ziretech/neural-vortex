using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class DödaKritisktSkadade : IDödaKritisktSkadade
    {
        private ISpelvärld _spelvärld;

        public DödaKritisktSkadade(ISpelvärld spelvärld)
        {
            _spelvärld = spelvärld ?? throw new ArgumentException("DödaKritisktSkadade kan inte skapas utan spelvärld.");
        }

        public SpeletsFortsättning Döda()
        {
            if (_spelvärld.Huvudkaraktär != null && _spelvärld.Huvudkaraktär.ÄrKritisktSkadad)
            {
                return SpeletsFortsättning.Avsluta;
            }

            foreach(var fiende in _spelvärld.Fienden)
            {
                if(fiende.ÄrKritisktSkadad)
                {
                    _spelvärld.DödaFiende(fiende);
                }                
            }            
            
            return SpeletsFortsättning.Fortsätt;
        }
    }
}
