using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Kontroll;

namespace Adapter.OpenTK.Kontroll
{
    public class KontrollHändelser : ITangentmottagare
    {
        private IAvslutare _avslutare;
        private UppdateraSpelvärld _uppdateraSpelvärld;

        public KontrollHändelser(UppdateraSpelvärld uppdateraSpelvärld, IAvslutare avslutare)
        {
            _uppdateraSpelvärld = uppdateraSpelvärld;
            _avslutare = avslutare;
        }

        public void TangentTrycksNed(Tangent tangent)
        {
            var tillstånd = _uppdateraSpelvärld.Uppdatera(tangent);
            if(tillstånd == SpeletsFortsättning.Avsluta)
            {
                _avslutare.Avsluta();
            }
        }
    }
}
