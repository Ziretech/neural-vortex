using Adapter.OpenTK.Grafik;
using System;
using System.Collections.Generic;

namespace Adapter.OpenTK.Spec.Grafik
{
    public class GrafikkommandonMock : IGrafikkommandon
    {            
        private FyrkantVerifierare _aktuellTexturverifierare;
        private FyrkantVerifierare _aktuellHörnverifierare;

        public List<FyrkantVerifierare> Texturverifierare { get; private set; }
        public List<FyrkantVerifierare> Hörnverifierare { get; private set; }
            

        public GrafikkommandonMock()
        {
            Texturverifierare = new List<FyrkantVerifierare>();
            Hörnverifierare = new List<FyrkantVerifierare>();
        }

        public void DefinieraFyrkanter()
        {
            _aktuellHörnverifierare = new FyrkantVerifierare();
            _aktuellTexturverifierare = new FyrkantVerifierare();
        }
            
        public void Texturkoordinat(int x, int y)
        {
            if(_aktuellTexturverifierare.AntalHörn == 4)
            {
                Texturverifierare.Add(_aktuellTexturverifierare);
                _aktuellTexturverifierare = new FyrkantVerifierare();
            }
            _aktuellTexturverifierare.VerifieraHörn(x, y);
        }
            
        public void Hörnkoordinat(int x, int y)
        {
            if (_aktuellHörnverifierare.AntalHörn == 4)
            {
                Hörnverifierare.Add(_aktuellHörnverifierare);
                _aktuellHörnverifierare = new FyrkantVerifierare();
            }
            _aktuellHörnverifierare.VerifieraHörn(x, y);
        }

        public void AvslutaDefinitioner()
        {
            if (_aktuellTexturverifierare.AntalHörn == 4)
            {
                Texturverifierare.Add(_aktuellTexturverifierare);
                _aktuellTexturverifierare = null;
            }

            if (_aktuellHörnverifierare.AntalHörn == 4)
            {
                Hörnverifierare.Add(_aktuellHörnverifierare);
                _aktuellHörnverifierare = null;
            }
        }


        public void Aktivera2DTexturering()
        {
            throw new NotImplementedException();
        }

        public void AktiveraBlandning()
        {
            throw new NotImplementedException();
        }

        public int GenereraTextur()
        {
            throw new NotImplementedException();
        }

        public void NollställMatris()
        {
            throw new NotImplementedException();
        }

        public void OrtogonalProjektion(double vänster, double höger, double nere, double uppe, double nära, double borta)
        {
            throw new NotImplementedException();
        }

        public void Skalningsmatris(double breddfaktor, double höjdfaktor)
        {
            throw new NotImplementedException();
        }

        public void TömRityta()
        {
            throw new NotImplementedException();
        }

        public void Visningsområde(int x, int y, int bredd, int höjd)
        {
            throw new NotImplementedException();
        }

        public void VäljAktivTextur(int texturId)
        {
            throw new NotImplementedException();
        }

        public void VäljAlphakanalBlandning()
        {
            throw new NotImplementedException();
        }

        public void VäljModellmatris()
        {
            throw new NotImplementedException();
        }

        public void VäljNärmasteFärgVidTexturförminskning()
        {
            throw new NotImplementedException();
        }

        public void VäljNärmasteFärgVidTexturförstoring()
        {
            throw new NotImplementedException();
        }

        public void VäljProjektionmatris()
        {
            throw new NotImplementedException();
        }

        public void VäljTexturmatris()
        {
            throw new NotImplementedException();
        }
    }
}