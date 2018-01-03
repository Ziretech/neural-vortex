using System;
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
        private IAvslutare _avslutare;
        private IGrafikkommandon _gl;
        private IBild _tileset;
        private IBuffertväxlare _buffertväxlare;
        private VisaSpelvärld _visaSpelvärld;
        private int _bredd;
        private int _höjd;

        public GrafikHändelser(IAvslutare avslutare, IGrafikkommandon grafikkommandon, IBild tileset, IBuffertväxlare buffertväxlare, VisaSpelvärld visaSpelvärld)
        {
            _avslutare = avslutare;
            _gl = grafikkommandon;
            _tileset = tileset;
            _buffertväxlare = buffertväxlare;
            _visaSpelvärld = visaSpelvärld;
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

            //KopieraTexturrektangelTillRityta(0, 0, 0, 0, 32, 32);
            _visaSpelvärld.Visa(new Rektangel(_bredd, _höjd));

            _buffertväxlare.VäxlaBuffert();
        }

        public void ÄndraStorlek(int bredd, int höjd)
        {
            _bredd = bredd;
            _höjd = höjd;

            _gl.VäljProjektionmatris();
            _gl.NollställMatris();
            _gl.OrtogonalProjektion(0.0, bredd / 2.0, 0.0, höjd / 2.0, 0.0, 4.0);
            _gl.VäljModellmatris();
            _gl.Visningsområde(0, 0, bredd, höjd);            
        }        
    }
}
