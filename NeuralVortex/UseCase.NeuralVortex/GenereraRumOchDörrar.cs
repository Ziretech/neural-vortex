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
        private readonly ISpelvärldsskapare _skapare;
        private readonly IRumOchDörrarVäljare _väljare;
        private readonly Spelvärldsposition _förstaRummetPosition;

        public enum Riktning
        {
            Vänster,
            Nedåt,
            Höger,
            Uppåt
        }

        public GenereraRumOchDörrar(ISpelvärldsskapare skapare, IRumOchDörrarVäljare väljare)
        {
            _skapare = skapare ?? throw new ArgumentException("GenereraRumOchDörrar kan inte skapas utan Spelvärldsskapare");
            _väljare = väljare ?? throw new ArgumentException("GenereraRumOchDörrar kan inte skapas utan RumOchDörrarVäljare");
            _förstaRummetPosition = new Spelvärldsposition(1, 1);

        }

        public void Generera(int antalRum)
        {
            var yta = _väljare.VäljRumstorlek();
            _skapare.SkapaRum(new Spelvärldsområde(_förstaRummetPosition, yta));
            if(antalRum == 2)
            {
                var riktning = _väljare.VäljRiktning();
                if(riktning == Riktning.Höger)
                {
                    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(3, 1), yta));
                    _skapare.SkapaDörr(new Spelvärldsposition(2, 1));
                }
                else if(riktning == Riktning.Uppåt)
                {
                    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 3), yta));
                    _skapare.SkapaDörr(new Spelvärldsposition(1, 2));
                }
            }
        }

        //public void Generera()
        //{
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(5, 5)));
        //    _skapare.SkapaDörr(new Spelvärldsposition(6, 3));
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(7, 2), new Spelvärldsyta(4, 3)));
        //    _skapare.SkapaDörr(new Spelvärldsposition(11, 3));
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(12, 1), new Spelvärldsyta(3, 6)));
        //    _skapare.SkapaDörr(new Spelvärldsposition(8, 5));
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(7, 6), new Spelvärldsyta(4, 4)));
        //}
    }
}
