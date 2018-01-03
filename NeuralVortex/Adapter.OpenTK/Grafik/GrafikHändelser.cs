using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OpenTK.Grafik
{
    public class GrafikHändelser : ILaddare, IStorleksÄndrare, IUppdaterare, IVisare
    {
        private IAvslutare _avslutare;
        private IGrafikkommandon _gl;
        private IBild _tileset;
        private IBuffertväxlare _buffertväxlare;

        public GrafikHändelser(IAvslutare avslutare, IGrafikkommandon grafikkommandon, IBild tileset, IBuffertväxlare buffertväxlare)
        {
            _avslutare = avslutare;
            _gl = grafikkommandon;
            _tileset = tileset;
            _buffertväxlare = buffertväxlare;
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

            KopieraTexturrektangelTillRityta(0, 0, 0, 0, 32, 32);

            _buffertväxlare.VäxlaBuffert();
        }

        public void ÄndraStorlek(int bredd, int höjd)
        {
            _gl.VäljProjektionmatris();
            _gl.NollställMatris();
            _gl.OrtogonalProjektion(0.0, bredd / 2.0, 0.0, höjd / 2.0, 0.0, 4.0);
            _gl.VäljModellmatris();
            _gl.Visningsområde(0, 0, bredd, höjd);            
        }

        public void KopieraTexturrektangelTillRityta(int texturX, int texturY, int ritytaX, int ritytaY, int bredd, int höjd)
        {
            var t1 = new Vektor(texturX, texturY);
            var t2 = new Vektor(texturX + bredd, texturY + höjd);
            var s1 = new Vektor(ritytaX, ritytaY);
            var s2 = new Vektor(ritytaX + bredd, ritytaY + höjd);

            _gl.DefinieraFyrkanter();
            _gl.Texturkoordinat(t1.X, t2.Y);
            _gl.Hörnkoordinat(s1.X, s1.Y);

            _gl.Texturkoordinat(t2.X, t2.Y);
            _gl.Hörnkoordinat(s2.X, s1.Y);

            _gl.Texturkoordinat(t2.X, t1.Y);
            _gl.Hörnkoordinat(s2.X, s2.Y);

            _gl.Texturkoordinat(t1.X, t1.Y);
            _gl.Hörnkoordinat(s1.X, s2.Y);
            _gl.AvslutaDefinitioner();
        }        
    }
}
