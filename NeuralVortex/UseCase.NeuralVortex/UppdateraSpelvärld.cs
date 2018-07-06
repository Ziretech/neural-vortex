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
        private ISpelvärld _spelvärld;
        private IKamera _kamera;
        private IHinderkarta _hinderkarta;

        public UppdateraSpelvärld(ISpelvärld spelvärld, IKamera kamera, IHinderkarta hinderkarta = null)
        {
            _spelvärld = spelvärld;
            _kamera = kamera;
            _hinderkarta = hinderkarta;
        }

        public SpeletsFortsättning Uppdatera(Tangent tangent)
        {
            if(tangent == Tangent.Escape)
            {
                return SpeletsFortsättning.Avsluta;
            }

            _spelvärld.Huvudkaraktär.Position = BeräknaNyPosition(Förflyttningsriktning(tangent), _spelvärld.Huvudkaraktär.Position);

            //foreach(var fiende in _spelvärld.Fienden)
            //{
            //    fiende.Position = BeräknaNyPosition(new Spelvärldsposition(0, 1), fiende.Position);
            //}

            return SpeletsFortsättning.Fortsätt;
        }

        private Spelvärldsposition Förflyttningsriktning(Tangent tangent)
        {
            switch(tangent)
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

            if(PassageTillåtenTillPosition(nyPosition))
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
