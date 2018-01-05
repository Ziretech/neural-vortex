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
        private readonly Skärmposition _texturPosition;
        private readonly Skärmyta _dimensioner;
        private readonly Kamera _kamera;

        public Bricka(IGrafikkommandon gl, Kamera kamera, Skärmposition texturPosition, Skärmyta dimensioner)
        {
            _gl = gl;
            _texturPosition = texturPosition;
            _dimensioner = dimensioner;
            _kamera = kamera;
        }

        public void Visa(Skärmposition position)
        {
            KopieraTexturrektangelTillRityta(_texturPosition, _kamera.Transformera(position), _dimensioner);
        }

        private void KopieraTexturrektangelTillRityta(Skärmposition texturPosition, Skärmposition brickansPosition, Skärmyta yta)
        {
            var texturPosition2 = texturPosition.Plus(yta);
            var brickansPosition2 = brickansPosition.Plus(yta);

            _gl.DefinieraFyrkanter();
            _gl.Texturkoordinat(texturPosition.X, texturPosition2.Y);
            _gl.Hörnkoordinat(brickansPosition.X, brickansPosition.Y);

            _gl.Texturkoordinat(texturPosition2.X, texturPosition2.Y);
            _gl.Hörnkoordinat(brickansPosition2.X, brickansPosition.Y);

            _gl.Texturkoordinat(texturPosition2.X, texturPosition.Y);
            _gl.Hörnkoordinat(brickansPosition2.X, brickansPosition2.Y);

            _gl.Texturkoordinat(texturPosition.X, texturPosition.Y);
            _gl.Hörnkoordinat(brickansPosition.X, brickansPosition2.Y);
            _gl.AvslutaDefinitioner();
        }
    }
}
