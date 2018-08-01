using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class VisaStatus : IVisa
    {
        private IGrafik _hälsomätarram;
        private IKamera _kamera;

        public VisaStatus(IKamera kamera, IGrafik hälsomätarram)
        {
            _kamera = kamera;
            _hälsomätarram = hälsomätarram;
        }

        public void Visa()
        {
            var skärmbredd = _kamera.Dimensioner.Bredd;
            var mätarbredd = _hälsomätarram.Dimensioner.Bredd;
            var differens = skärmbredd - mätarbredd;
            _hälsomätarram.Visa(new Skärmposition(differens / 2, 0));
        }
    }
}
