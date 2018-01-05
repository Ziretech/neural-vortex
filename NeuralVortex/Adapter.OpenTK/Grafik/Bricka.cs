using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Grafik
{
    public class Bricka : IGrafik
    {
        private readonly IGrafikkommandon _gl;
        private readonly int _texturX;
        private readonly int _texturY;
        private readonly int _bredd;
        private readonly int _höjd;

        public Bricka(IGrafikkommandon gl, int texturX, int texturY, int bredd, int höjd)
        {
            _gl = gl;
            _texturX = texturX;
            _texturY = texturY;
            _bredd = bredd;
            _höjd = höjd;
        }

        public void Visa(Skärmposition position)
        {
            KopieraTexturrektangelTillRityta(_texturX, _texturY, position.X, position.Y, _bredd, _höjd);
        }

        public void Visa(Brickposition position)
        {
            throw new NotImplementedException();
        }

        private void KopieraTexturrektangelTillRityta(int texturX, int texturY, int ritytaX, int ritytaY, int bredd, int höjd)
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
