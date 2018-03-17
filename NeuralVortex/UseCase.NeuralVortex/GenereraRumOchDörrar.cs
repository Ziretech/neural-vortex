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
            var position = new Spelvärldsposition(1, 1);
            var yta = _väljare.VäljRumstorlek();
            var rumområde = new Spelvärldsområde(position, yta);
            _skapare.SkapaRum(rumområde);

            if(!_skapare.ÄrKartanFärdig())
            {
                var dörrpositioner = _väljare.VäljDörrpositioner(rumområde);
                var valdDörrposition = dörrpositioner[0];
                _skapare.SkapaDörr(valdDörrposition);

                yta = _väljare.VäljRumstorlek();
                position = _väljare.VäljRumposition(yta, valdDörrposition);

                rumområde = new Spelvärldsområde(position, yta);
                _skapare.SkapaRum(rumområde);
            }

            return;
        }
    }
}
