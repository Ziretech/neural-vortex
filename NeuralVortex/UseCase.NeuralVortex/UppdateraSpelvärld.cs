using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class UppdateraSpelvärld
    {
        private readonly IFlyttaVarelser _flyttaVarelser;
        private readonly IUtdelaSkada _utdelaSkada;

        public UppdateraSpelvärld(IFlyttaVarelser flyttaVarelser, IUtdelaSkada utdelaSkada)
        {
            _flyttaVarelser = flyttaVarelser;
            _utdelaSkada = utdelaSkada;
        }

        public SpeletsFortsättning Uppdatera(Tangent tangent)
        {
            if(tangent == Tangent.Escape)
            {
                return SpeletsFortsättning.Avsluta;
            }

            if(_flyttaVarelser != null) _flyttaVarelser.Flytta(tangent);
            if(_utdelaSkada != null) _utdelaSkada.Utdela();

            return SpeletsFortsättning.Fortsätt;
        }
    }
}
