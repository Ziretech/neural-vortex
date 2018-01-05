using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class VisaSpelvärld
    {
        private readonly ISpelvärld _spelvärld;
        private readonly Rektangel _brickstorlek;

        public VisaSpelvärld(ISpelvärld spelvärld, Rektangel brickstorlek)
        {
            _spelvärld = spelvärld;
            _brickstorlek = brickstorlek;
        }

        public void Visa(Rektangel ritytansStorlek)
        {
            var huvudkaraktär = _spelvärld.Huvudkaraktär;
            if (huvudkaraktär != null)
            {
                huvudkaraktär.Grafik.Visa(KonverteraTillBrickposition(huvudkaraktär.Position));
            }

            var miljögrafik = _spelvärld.MiljöGrafik;
            if(miljögrafik != null)
            {
                miljögrafik.Visa();
            }

            var fienden = _spelvärld.Fienden;
            if(fienden != null)
            {
                foreach(var fiende in fienden)
                {
                    fiende.Grafik.Visa(KonverteraTillBrickposition(fiende.Position));
                }
            }
        }

        private Brickposition KonverteraTillBrickposition(Spelvärldsposition position)
        {
            return new Brickposition(position.X, position.Y);
        }
    }
}
