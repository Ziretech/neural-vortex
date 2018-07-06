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

        private enum Riktning
        {
            Upp,
            Ner,
            Höger,
            Vänster
        }

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

            var riktning = TangentensFörflyttningAvKaraktären(tangent);
            if(riktning.HasValue)
            {
                _spelvärld.Huvudkaraktär.Position = BeräknaNyPosition(riktning.Value, _spelvärld.Huvudkaraktär.Position);
            }

            return SpeletsFortsättning.Fortsätt;
        }

        private Riktning? TangentensFörflyttningAvKaraktären(Tangent tangent)
        {
            switch(tangent)
            {
                case Tangent.Upp:
                    return Riktning.Upp;
                case Tangent.Ner:
                    return Riktning.Ner;
                case Tangent.Höger:
                    return Riktning.Höger;
                case Tangent.Vänster:
                    return Riktning.Vänster;
            }
            return null;
        }

        private Spelvärldsposition BeräknaNyPosition(Riktning riktning, Spelvärldsposition tidigarePosition)
        {
            Spelvärldsposition nyPosition = null;
            switch(riktning)
            {
                case Riktning.Upp:
                    nyPosition = new Spelvärldsposition(tidigarePosition.X, tidigarePosition.Y + 1);
                    break;
                case Riktning.Ner:
                    nyPosition = new Spelvärldsposition(tidigarePosition.X, tidigarePosition.Y - 1);
                    break;
                case Riktning.Vänster:
                    nyPosition = new Spelvärldsposition(tidigarePosition.X - 1, tidigarePosition.Y);
                    break;
                case Riktning.Höger:
                    nyPosition = new Spelvärldsposition(tidigarePosition.X + 1, tidigarePosition.Y);
                    break;
            }

            if(nyPosition != null)
            {
                if(_hinderkarta == null || !_hinderkarta.Hindrar(nyPosition))
                {
                    return nyPosition;
                }                
            }
            return tidigarePosition;
        }
    }
}
