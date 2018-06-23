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
        private List<Spelvärldsområde> _rum;
        private List<Spelvärldsposition> _dörrar;

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
            _rum = new List<Spelvärldsområde>();
            _dörrar = new List<Spelvärldsposition>();
        }

        public void Generera(int antalRum)
        {
            var yta = _väljare.VäljRumstorlek();
            SkapaRum(_förstaRummetPosition, yta);
            while(antalRum > 1)
            {
                var valtRum = _rum.Last();

                var riktning = _väljare.VäljRiktning();
                if(riktning == Riktning.Höger)
                {
                    SkapaRum(new Spelvärldsposition(valtRum.Vänster + 1 + 1, valtRum.Botten), yta);
                    SkapaDörr(new Spelvärldsposition(valtRum.Vänster + 1, valtRum.Botten));
                }
                else if(riktning == Riktning.Uppåt)
                {
                    SkapaRum(new Spelvärldsposition(valtRum.Vänster, valtRum.Botten + 1 + 1), yta);
                    SkapaDörr(new Spelvärldsposition(valtRum.Vänster, valtRum.Botten + 1));
                }
                antalRum--;
            }
        }

        private void SkapaRum(Spelvärldsposition position, Spelvärldsyta yta)
        {
            var rum = new Spelvärldsområde(position, yta);
            _skapare.SkapaRum(rum);
            _rum.Add(rum);
        }
        private void SkapaDörr(Spelvärldsposition position)
        {
            _skapare.SkapaDörr(position);
            _dörrar.Add(position);
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
