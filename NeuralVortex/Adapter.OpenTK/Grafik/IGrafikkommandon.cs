using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OpenTK.Grafik
{
    public interface IGrafikkommandon
    {
        void Aktivera2DTexturering();
        void AktiveraBlandning();
        void VäljAlphakanalBlandning();
        int GenereraTextur();
        void VäljAktivTextur(int texturId);
        void VäljNärmasteFärgVidTexturförminskning();
        void VäljNärmasteFärgVidTexturförstoring();
        void VäljTexturmatris();
        void NollställMatris();
        void Skalningsmatris(double breddfaktor, double höjdfaktor);
        void VäljModellmatris();
        void VäljProjektionmatris();
        void OrtogonalProjektion(double vänster, double höger, double nere, double uppe, double nära, double borta);
        void Visningsområde(int x, int y, int bredd, int höjd);
        void TömRityta();
        void DefinieraFyrkanter();
        void AvslutaDefinitioner();
        void Texturkoordinat(int x, int y);
        void Hörnkoordinat(int x, int y);
    }
}
