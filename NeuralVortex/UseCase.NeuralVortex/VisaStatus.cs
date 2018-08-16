﻿using System;
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

        public VisaStatus(IKamera kamera, IGrafik hälsomätarram, IGradvisGrafik hälsomätare)
        {
            _kamera = kamera;
            _hälsomätarram = hälsomätarram;
            _hälsomätare = hälsomätare;
        }

        public void Visa()
        {
            // FIXA Denna del av koden (UC) ska inte känna till bredder och pixlar!
            var skärmbredd = _kamera.Dimensioner.Bredd;
            var mätarbredd = _hälsomätarram.Dimensioner.Bredd;
            var differens = skärmbredd - mätarbredd;
            var position = new Skärmposition(differens / 2, 0);
            _hälsomätarram.Visa(position);

            _hälsomätare.Visa(position, new Andel(.5));
        }
    }
}