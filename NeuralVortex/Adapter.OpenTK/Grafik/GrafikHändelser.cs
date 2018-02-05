﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Grafik
{
    public class GrafikHändelser : ILaddare, IStorleksÄndrare, IUppdaterare, IVisare
    {
        private IGrafikkommandon _gl;
        private IBild _tileset;
        private IBuffertväxlare _buffertväxlare;
        private VisaSpelvärld _visaSpelvärld;
        private Kamera _kamera;
        private double _scaleFactor;

        public GrafikHändelser(IGrafikkommandon grafikkommandon, IBild tileset, IBuffertväxlare buffertväxlare, VisaSpelvärld visaSpelvärld, Kamera kamera)
        {
            _gl = grafikkommandon;
            _tileset = tileset;
            _buffertväxlare = buffertväxlare;
            _visaSpelvärld = visaSpelvärld;
            _kamera = kamera;
            _scaleFactor = 4.0;
        }

        public void Ladda(object avsändare, EventArgs händelse)
        {
            _gl.Aktivera2DTexturering();
            _gl.AktiveraBlandning();
            _gl.VäljAlphakanalBlandning();

            var textur = new Textur(_gl, _tileset);
            textur.Aktivera();
        }

        public void Uppdatera(object avsändare, EventArgs händelse)
        {
            // uc
        }

        public void Visa(object avsändare, EventArgs händelse)
        {
            _gl.TömRityta();            
            _visaSpelvärld.Visa();
            _buffertväxlare.VäxlaBuffert();
        }

        public void ÄndraStorlek(int bredd, int höjd)
        {
            _kamera.Dimensioner = new Skärmyta(bredd, höjd);

            _gl.VäljProjektionmatris();
            _gl.NollställMatris();
            _gl.OrtogonalProjektion(0.0, bredd / _scaleFactor, 0.0, höjd / _scaleFactor, 0.0, 4.0);
            _gl.VäljModellmatris();
            _gl.Visningsområde(0, 0, bredd, höjd);            
        }        
    }
}
