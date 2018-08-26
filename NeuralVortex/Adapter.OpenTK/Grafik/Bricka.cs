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
        public Skärmyta Dimensioner { get; private set; }

        public Bricka(IGrafikkommandon gl, Skärmposition texturPosition, Skärmyta dimensioner)
        {
            _gl = gl ?? throw new ArgumentException("Bricka kan inte skapas utan grafikkommando.");
            _texturPosition = texturPosition ?? throw new ArgumentException("Bricka kan inte skapas utan texturposition.");
            Dimensioner = dimensioner ?? throw new ArgumentException("Bricka kan inte skapas utan dimensioner.");
        }

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
            var texturPosition = _texturPosition.Plus(område.Position);
            _gl.KopieraTexturrektangelTillRityta(
                texturPosition.X, texturPosition.Y,
                position.X, position.Y,
                område.Yta.Bredd, område.Yta.Höjd);
        }
    }
}
