using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Grafik
{
    public class Bricka : IGrafik, IGradvisGrafik
    {
        private readonly IGrafikkommandon _gl;
        private readonly Skärmposition _texturPosition;
        private readonly Kamera _kamera;

        public Bricka(IGrafikkommandon gl, Kamera kamera, Skärmposition texturPosition, Skärmyta dimensioner)
        {
            _gl = gl;
            _texturPosition = texturPosition;
            Dimensioner = dimensioner;
            _kamera = kamera;
        }

        public Bricka(IGrafikkommandon gl, Skärmposition texturPosition, Skärmyta dimensioner)
        {
            _gl = gl;
            _texturPosition = texturPosition;
            Dimensioner = dimensioner;
        }

        public Skärmyta Dimensioner { get; private set; }

        public void Visa(Skärmposition position)
        {
            Visa(position, new Skärmområde(Dimensioner));
        }

        public void Visa(Skärmposition position, Andel andel)
        {
            var bredd = andel.Av(Dimensioner.Bredd);
            if(bredd > 0)
            {
                Visa(position, new Skärmområde(new Skärmyta(bredd, Dimensioner.Höjd)));
            }            
        }

        private void Visa(Skärmposition position, Skärmområde område)
        {
            var transformeradPosition = _kamera == null ? position : _kamera.Transformera(position);
            KopieraTexturrektangelTillRityta(_texturPosition.Plus(område.Position), transformeradPosition, område.Yta);
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
