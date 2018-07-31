using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class VisaSpelvärld : IVisa
    {
        private readonly ISpelvärld _spelvärld;
        private readonly IPositionskonverterare _konvertera;

        public VisaSpelvärld(ISpelvärld spelvärld, IPositionskonverterare konvertera)
        {
            _spelvärld = spelvärld;
            _konvertera = konvertera;
        }

        public void Visa()
        {
            var miljögrafik = _spelvärld.MiljöGrafik;
            if(miljögrafik != null)
            {
                miljögrafik.Visa(new Skärmposition(0, 0));
            }

            var fienden = _spelvärld.Fienden;
            if (fienden != null)
            {
                foreach (var fiende in fienden)
                {
                    fiende.Grafik.Visa(_konvertera.TillPunkt(fiende.Position));
                }
            }

            var huvudkaraktär = _spelvärld.Huvudkaraktär;
            if (huvudkaraktär != null)
            {
                huvudkaraktär.Grafik.Visa(_konvertera.TillPunkt(huvudkaraktär.Position));
            }
        }
    }
}
