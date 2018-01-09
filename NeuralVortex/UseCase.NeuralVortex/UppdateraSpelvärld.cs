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

            FlyttaKaraktär(tangent);

            return SpeletsFortsättning.Fortsätt;
        }

        public void FlyttaKaraktär(Tangent tangent)
        {
            var tidigarePosition = _spelvärld.Huvudkaraktär.Position;
            Spelvärldsposition nyPosition = null;
            switch(tangent)
            {
                case Tangent.Upp:
                    _spelvärld.Huvudkaraktär.Position = new Spelvärldsposition(tidigarePosition.X, tidigarePosition.Y + 1);
                    break;
                case Tangent.Ner:
                    _spelvärld.Huvudkaraktär.Position = new Spelvärldsposition(tidigarePosition.X, tidigarePosition.Y - 1);
                    break;
                case Tangent.Vänster:
                    _spelvärld.Huvudkaraktär.Position = new Spelvärldsposition(tidigarePosition.X - 1, tidigarePosition.Y);
                    break;
                case Tangent.Höger:
                    _spelvärld.Huvudkaraktär.Position = new Spelvärldsposition(tidigarePosition.X + 1, tidigarePosition.Y);
                    break;
            }


        }
    }
}
