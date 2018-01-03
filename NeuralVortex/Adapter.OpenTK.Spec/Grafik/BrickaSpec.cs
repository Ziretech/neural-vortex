using Adapter.OpenTK.Grafik;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec
{
    [TestFixture]
    public class GrafikSpec
    {
        [Test]
        public void Bricka_borde_visa_en_bild_på_angiven_position()
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, 1, 2, 10, 20);
            bricka.Visa(new Skärmposition(20, 30));

            Assert.That(glMock.Texturverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Texturverifierare[0].StämmerHörn1(1, 22));
            Assert.That(glMock.Texturverifierare[0].StämmerHörn2(11, 2));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(20, 30));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn2(30, 50));
        }

        class FyrkantVerifierare
        {
            private int _hörn1x;
            private int _hörn1y;
            private int _hörn2x;
            private int _hörn2y;

            public int AntalHörn { get; set; }

            public void VerifieraHörn(int x, int y)
            {
                if(AntalHörn == 0)
                {
                    _hörn1x = x;
                    _hörn1y = y;
                } else if(AntalHörn == 1)
                {
                    Assert.That(_hörn1y, Is.EqualTo(y));
                    _hörn2x = x;
                } else if(AntalHörn == 2)
                {
                    Assert.That(_hörn2x, Is.EqualTo(x));
                    _hörn2y = y;
                } else if(AntalHörn == 3)
                {
                    Assert.That(_hörn1x, Is.EqualTo(x));
                    Assert.That(_hörn2y, Is.EqualTo(y));                    
                }
                else
                {
                    Assert.Fail("Fler än fyra hörn kan inte definieras för en fyrkant.");
                }

                AntalHörn++;
            }

            public bool StämmerHörn1(int x, int y)
            {
                return _hörn1x == x && _hörn1y == y;
            }

            public bool StämmerHörn2(int x, int y)
            {
                return _hörn2x == x && _hörn2y == y;
            }
        }

        class GrafikkommandonMock : IGrafikkommandon
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
}