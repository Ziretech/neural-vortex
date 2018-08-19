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
        private readonly Kamera _kamera; // REFACTOR Lägga till Transformera till IKamera så att interfacet kan användas här istället? För att underlätta mockning i testerna.
        private readonly Skärmposition _centrum;
        public Skärmyta Dimensioner { get; private set; }

        public Bricka(IGrafikkommandon gl, Kamera kamera, Skärmposition texturPosition, Skärmyta dimensioner, Skärmposition centrum)
        {
            _gl = gl ?? throw new ArgumentException("Bricka kan inte skapas utan grafikkommando.");
            _texturPosition = texturPosition ?? throw new ArgumentException("Bricka kan inte skapas utan texturposition.");
            Dimensioner = dimensioner ?? throw new ArgumentException("Bricka kan inte skapas utan dimensioner.");
            _kamera = kamera;
            _centrum = centrum;
        }

        public Bricka(IGrafikkommandon gl, Kamera kamera, Skärmposition texturPosition, Skärmyta dimensioner) : this(gl, kamera, texturPosition, dimensioner, new Skärmposition(0, 0)) { }
        public Bricka(IGrafikkommandon gl, Skärmposition texturPosition, Skärmyta dimensioner) : this(gl, null, texturPosition, dimensioner, new Skärmposition(0, 0)) { }
        public Bricka(IGrafikkommandon gl, Skärmposition texturPosition, Skärmyta dimensioner, Skärmposition centrum) : this(gl, null, texturPosition, dimensioner, centrum) { }


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
            var centreradPosition = position.Plus(_centrum);
            var transformeradPosition = _kamera == null ? centreradPosition : _kamera.Transformera(centreradPosition);
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

        public void VisaCenterBotten()
        {
            var differens = _kamera.Dimensioner.Bredd - Dimensioner.Bredd;
            var position = new Skärmposition(differens / 2, 0);
            KopieraTexturrektangelTillRityta(_texturPosition, position, Dimensioner);
        }

        public void VisaCenterBotten(Andel andel)
        {
            var bredd = andel.Av(Dimensioner.Bredd);
            if (bredd > 0)
            {
                var differens = _kamera.Dimensioner.Bredd - Dimensioner.Bredd;
                var position = new Skärmposition(differens / 2, 0);

                KopieraTexturrektangelTillRityta(_texturPosition, position, new Skärmyta(bredd, Dimensioner.Höjd));
            }
        }

        // REFACTOR Bricka och liknande objekt borde inte ha någonting med Spelvärld (och därför Kamera) att göra, den borde bara rita ut sina rektanglar...
        // Men vem hanterar konverteringen då? Bör man kolla över hur hela renderingen fungerar?
        // Just nu säger UC bara att ett (Grafikadapter) objekt ska visas, och sedan får den själv lita ut var och hur.
        // Men en annan approach är att låta grafikadaptern vara dummare och låta logiken finnas någon annanstans.
        // Brickan vet hur den visar sig, men inte var (på skärmen) den ska göra det. Det borde isåfall vara argumentet in till den.
        // Spelvärldsobjekt som huvudkaraktären har en spelvärldsposition och ett grafikobjekt kopplat till sig. Genom att mata in spelvärldspositionen till en spelvärldskamera
        // (som känner till spelvärld/skärmkonverteringen och positioneringen av kameran) så kan UC få tag i skärmkoordinaten och låta kameran visa den.
        // Var finns kamerans logik? Datat kommer från Spelvärlds/grafikadaptrarna, men själva logiken hör hemma i UC (Entitet?)
    }
}
