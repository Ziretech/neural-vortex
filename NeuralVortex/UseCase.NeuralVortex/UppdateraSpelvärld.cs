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

        public UppdateraSpelvärld(IFlyttaVarelser flyttaVarelser)
        {
            _flyttaVarelser = flyttaVarelser;
        }

        public SpeletsFortsättning Uppdatera(Tangent tangent)
        {
            if(tangent == Tangent.Escape)
            {
                return SpeletsFortsättning.Avsluta;
            }

            _flyttaVarelser.Flytta(tangent);

            return SpeletsFortsättning.Fortsätt;
        }
    }
}
