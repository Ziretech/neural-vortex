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
        private IGradvisGrafik _hälsomätare;
        private Huvudkaraktär _huvudkaraktär;

        public VisaStatus(IKamera kamera, IGrafik hälsomätarram, IGradvisGrafik hälsomätare, Huvudkaraktär huvudkaraktär)
        {
            _kamera = kamera;
            _hälsomätarram = hälsomätarram;
            _hälsomätare = hälsomätare;
            _huvudkaraktär = huvudkaraktär;
        }

        public void Visa()
        {
            // FIXA Denna del av koden (UC) ska inte känna till bredder och pixlar!
            //var position = _kamera.PositionVidBottenCentrum(_hälsomätarram);
            //var skärmbredd = _kamera.Dimensioner.Bredd;
            //var mätarbredd = _hälsomätarram.Dimensioner.Bredd;
            //var differens = skärmbredd - mätarbredd;
            //var position = new Skärmposition(differens / 2, 0);
            //_hälsomätarram.Visa(position);
            _hälsomätarram.VisaCenterBotten();

            //_hälsomätare.Visa(position, new Andel(.5));
            _hälsomätare.VisaCenterBotten(new Andel(_huvudkaraktär.Hälsa, _huvudkaraktär.MaxHälsa));
        }
    }
}
