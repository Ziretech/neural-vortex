using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class FlyttaVarelser : IFlyttaVarelser
    {
        private readonly ISpelvärld _spelvärld;
        private readonly IHinderkarta _hinderkarta;

        public FlyttaVarelser(ISpelvärld spelvärld, IHinderkarta hinderkarta)
        {
            _spelvärld = spelvärld;
            _hinderkarta = hinderkarta;
        }

        public void Flytta(Tangent tangent)
        {
            if (_spelvärld.Huvudkaraktär != null)
            {
                _spelvärld.Huvudkaraktär.Position = BeräknaNyPosition(Förflyttningsriktning(tangent), _spelvärld.Huvudkaraktär.Position);
            }

            foreach (var fiende in _spelvärld.Fienden)
            {
                fiende.Position = BeräknaNyPosition(fiende.Riktningsgenerator.NästaRiktning, fiende.Position);
            }
        }

        private Spelvärldsposition Förflyttningsriktning(Tangent tangent)
        {
            switch (tangent)
            {
                case Tangent.Upp:
                    return new Spelvärldsposition(0, 1);
                case Tangent.Ner:
                    return new Spelvärldsposition(0, -1);
                case Tangent.Höger:
                    return new Spelvärldsposition(1, 0);
                case Tangent.Vänster:
                    return new Spelvärldsposition(-1, 0);
            }
            return new Spelvärldsposition(0, 0);
        }

        private Spelvärldsposition BeräknaNyPosition(Spelvärldsposition riktning, Spelvärldsposition tidigarePosition)
        {
            Spelvärldsposition nyPosition = tidigarePosition.Plus(riktning);

            if (PassageTillåtenTillPosition(nyPosition))
            {
                return nyPosition;
            }
            return tidigarePosition;
        }

        private bool PassageTillåtenTillPosition(Spelvärldsposition position)
        {
            return _hinderkarta == null || !_hinderkarta.Hindrar(position);
        }
    }
}
