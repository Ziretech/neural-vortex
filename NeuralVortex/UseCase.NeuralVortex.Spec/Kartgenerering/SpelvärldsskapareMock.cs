using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.Kartgenerering
{
    public class SpelvärldsskapareMock : IKartritare
    {
        public List<Spelvärldsposition> AnropadesMedDörr { get; private set; }
        public List<Spelvärldsområde> AnropadesMedRum { get; private set; }

        private int _antalSteg;

        public SpelvärldsskapareMock(int antalSteg)
        {
            _antalSteg = antalSteg;
            AnropadesMedDörr = new List<Spelvärldsposition>();
            AnropadesMedRum = new List<Spelvärldsområde>();
        }

        public void SkapaDörr(Spelvärldsposition position)
        {
            AnropadesMedDörr.Add(position);
        }

        public void SkapaRum(Spelvärldsområde område)
        {
            AnropadesMedRum.Add(område);
        }

        public bool ÄrKartanFärdig()
        {
            _antalSteg--;

            return _antalSteg < 1;
        }
    }
}
