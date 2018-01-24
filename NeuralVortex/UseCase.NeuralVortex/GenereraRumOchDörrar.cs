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

        public GenereraRumOchDörrar(ISpelvärldsskapare skapare, IRumOchDörrarVäljare väljare)
        {
            _skapare = skapare ?? throw new ArgumentException("GenereraRumOchDörrar kan inte skapas utan Spelvärldsskapare");
            _väljare = väljare ?? throw new ArgumentException("GenereraRumOchDörrar kan inte skapas utan RumOchDörrarVäljare");
        }

        public void Generera()
        {
            if(!_väljare.ÄrKartanFärdig())
            {
                //var rumområde = new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(3, 3));
                var rumområde = new Spelvärldsområde(1, 1, 3, 3);
                _skapare.SkapaRum(rumområde);
            }            
        }
    }
}
