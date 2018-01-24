using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.Kartgenerering
{
    public class SpelvärldsskapareMock : ISpelvärldsskapare
    {
        public List<Spelvärldsposition> Dörrar { get; private set; }
        public List<Spelvärldsområde> AnropadesMedRum { get; private set; }

        public SpelvärldsskapareMock()
        {
            Dörrar = new List<Spelvärldsposition>();
            AnropadesMedRum = new List<Spelvärldsområde>();
        }

        public void SkapaDörr(Spelvärldsposition position)
        {
            Dörrar.Add(position);
        }

        public void SkapaRum(Spelvärldsområde område)
        {
            AnropadesMedRum.Add(område);
        }
    }
}
